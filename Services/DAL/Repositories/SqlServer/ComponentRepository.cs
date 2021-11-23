using Services.DAL.Contracts;
using Services.DAL.Repositories.SqlServer.Adapters;
using Services.DAL.Repositories.Tools;
using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Services.DAL.Repositories.SqlServer
{
    class ComponentRepository : IComponentRepository
    {
        #region Singleton
        private readonly static ComponentRepository _instance = new ComponentRepository();
        public static ComponentRepository Current
        {
            get
            {
                return _instance;
            }
        }
        private ComponentRepository()
        {
        }
        #endregion
        #region Statements
        private string SelectAllStatement
        {
            get => $@"with recursivo as (
                        select sp2.id_permiso_padre, sp2.id_permiso_hijo  from permiso_permiso SP2
                        where sp2.id_permiso_padre @where --acá se va variando la familia que busco
                        UNION ALL 
                        select sp.id_permiso_padre, sp.id_permiso_hijo from permiso_permiso sp 
                        inner join recursivo r on r.id_permiso_hijo= sp.id_permiso_padre
                        )
                        select r.id_permiso_padre,r.id_permiso_hijo,p.id,p.nombre, p.permiso
                        from recursivo r 
                        inner join permiso p on r.id_permiso_hijo = p.id 
						
                        ";
        }
        private string SaveStatement
        {
            get => "INSERT INTO [dbo].[Permits] ([ID] ,[Name], [Permit]) VALUES (@ID,@Name,@Permit)";       
        }
        #endregion
        public IList<Component> GetAll(string family)
        {
            var where = "is NULL";
            var list = new List<Component>();

            if (!String.IsNullOrEmpty(family)) where = family;
            using (var dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text, new SqlParameter[] { new SqlParameter("@where", where) }))
            {
                while (dr.Read())
                {
                    Guid Father_ID = new();
                    if (dr["ID_FatherPermit"] != DBNull.Value) Father_ID = dr.GetGuid(dr.GetOrdinal("ID_FatherPermit"));

                    var Permit = string.Empty;
                    if (dr["Permit"] != DBNull.Value) Permit = dr.GetString(dr.GetOrdinal("Permit"));

                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);

                    Component c;

                    if (string.IsNullOrEmpty(Permit)) c = FamilyAdapter.Current.Adapt(values);
                    else c = PatentAdapter.Current.Adapt(values);

                    if (!string.IsNullOrEmpty(Permit)) c.Permit = (PermitType)Enum.Parse(typeof(PermitType), Permit);

                    var father = GetComponent(Father_ID, list);

                    if (father == null)
                    {
                        list.Add(c);
                    }
                    else
                    {
                        father.AgregarHijo(c);
                    }
                }
                return list;
            }
        }
        private Component GetComponent(Guid id, IList<Component> list)
        {
            Component component = list != null ? list.Where(i => i.ID.Equals(id)).FirstOrDefault() : null;
            if (component == null && list != null)
            {
                foreach (var c in list)
                {
                    var l = GetComponent(id, c.Hijos);
                    if (l != null && l.ID == id) return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Hijos);
                }
            }
            return component;
        }
        public Component SaveComponent(Component c, bool isFamily)
        {
            try
            {
                var ID = Guid.NewGuid();
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@ID", ID);
                parameters[1] = new SqlParameter("@Name", c.Name);
                if (isFamily)
                    parameters[2] = new SqlParameter("@Permit", DBNull.Value);
                else
                    parameters[2] = new SqlParameter("@Name", c.Permit.ToString());

                SqlHelper.ExecuteNonQuery(SaveStatement, System.Data.CommandType.Text, parameters);

                c.ID = ID;
                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}