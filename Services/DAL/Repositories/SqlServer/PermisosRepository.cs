using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Repositories.SqlServer
{
    class PermisosRepository
    {
        //private string GetConnectionString()
        //{
        //    return ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        //}
        //public Array GetAllPermission()
        //{
        //    return Enum.GetValues(typeof(PermitType));
        //}
        //public IList<Patent> GetAllPatentes()
        //{

        //    var cnn = new SqlConnection(GetConnectionString());
        //    cnn.Open();
        //    var cmd = new SqlCommand();
        //    cmd.Connection = cnn;

        //    var sql = $@"select * from permiso p where p.permiso is not null;";

        //    cmd.CommandText = sql;

        //    var reader = cmd.ExecuteReader();

        //    var lista = new List<Patent>();

        //    while (reader.Read())
        //    {


        //        var id = reader.GetGuid(reader.GetOrdinal("ID"));
        //        var nombre = reader.GetString(reader.GetOrdinal("Name"));
        //        var permiso = reader.GetString(reader.GetOrdinal("Permit"));


        //        Patent c = new Patent();

        //        c.ID = id;
        //        c.Name = nombre;
        //        c.Permit = (PermitType)Enum.Parse(typeof(PermitType), permiso);
        //        lista.Add(c);

        //    }
        //    reader.Close();
        //    cnn.Close();
        //    return lista;
        //}
        //private Component GetComponent(Guid id, IList<Component> lista)
        //{

        //    Component component = lista != null ? lista.Where(i => i.ID.Equals(id)).FirstOrDefault() : null;

        //    if (component == null && lista != null)
        //    {
        //        foreach (var c in lista)
        //        {

        //            var l = GetComponent(id, c.Hijos);
        //            if (l != null && l.ID == id) return l;
        //            else
        //            if (l != null)
        //                return GetComponent(id, l.Hijos);

        //        }
        //    }



        //    return component;



        //}
        //public Component GuardarComponente(Component p, bool esfamilia)
        //{
        //    try
        //    {
        //        var cnn = new SqlConnection(GetConnectionString());
        //        cnn.Open();
        //        var cmd = new SqlCommand();
        //        cmd.Connection = cnn;
        //        var sql = $@"insert into permiso (nombre,permiso) values (@nombre,@permiso);  SELECT ID AS LastID FROM permiso WHERE ID = @@Identity;       ";
        //        cmd.CommandText = sql;
        //        cmd.Parameters.Add(new SqlParameter("nombre", p.Name));
        //        if (esfamilia)
        //            cmd.Parameters.Add(new SqlParameter("permiso", DBNull.Value));
        //        else
        //            cmd.Parameters.Add(new SqlParameter("permiso", p.Permit.ToString()));

        //        var ID = cmd.ExecuteScalar();
        //        p.ID = (Guid)ID;
        //        return p;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //public IList<Component> GetAll(string familia)
        //{


        //    var where = "is NULL";

        //    if (!String.IsNullOrEmpty(familia))
        //    {
        //        where = familia;
        //    }

        //    var cs = new SqlConnectionStringBuilder();
        //    cs.IntegratedSecurity = true;
        //    cs.DataSource = ".";
        //    cs.InitialCatalog = "upf";
        //    var cnn = new SqlConnection(cs.ConnectionString);
        //    cnn.Open();
        //    var cmd = new SqlCommand();
        //    cmd.Connection = cnn;

        //    var sql = $@"with recursivo as (
        //                select sp2.id_permiso_padre, sp2.id_permiso_hijo  from permiso_permiso SP2
        //                where sp2.id_permiso_padre {where} --acá se va variando la familia que busco
        //                UNION ALL 
        //                select sp.id_permiso_padre, sp.id_permiso_hijo from permiso_permiso sp 
        //                inner join recursivo r on r.id_permiso_hijo= sp.id_permiso_padre
        //                )
        //                select r.id_permiso_padre,r.id_permiso_hijo,p.id,p.nombre, p.permiso
        //                from recursivo r 
        //                inner join permiso p on r.id_permiso_hijo = p.id 
						
        //                ";

        //    cmd.CommandText = sql;

        //    var reader = cmd.ExecuteReader();

        //    var lista = new List<Component>();

        //    while (reader.Read())
        //    {
        //        Guid id_padre = new();
        //        if (reader["id_permiso_padre"] != DBNull.Value)
        //        {
        //            id_padre = reader.GetGuid(reader.GetOrdinal("id_permiso_padre"));
        //        }

        //        var ID = reader.GetGuid(reader.GetOrdinal("ID"));
        //        var nombre = reader.GetString(reader.GetOrdinal("nombre"));

        //        var permiso = string.Empty;
        //        if (reader["permiso"] != DBNull.Value)
        //            permiso = reader.GetString(reader.GetOrdinal("permiso"));


        //        Component c;

        //        if (string.IsNullOrEmpty(permiso))//usamos este campo para identificar. Solo las patentes van a tener un permiso del sistema relacionado
        //            c = new Family();

        //        else
        //            c = new Patent();

        //        c.ID = ID;
        //        c.Name = nombre;
        //        if (!string.IsNullOrEmpty(permiso))
        //            c.Permit = (PermitType)Enum.Parse(typeof(PermitType), permiso);

        //        var padre = GetComponent(id_padre, lista);

        //        if (padre == null)
        //        {
        //            lista.Add(c);
        //        }
        //        else
        //        {
        //            padre.AgregarHijo(c);
        //        }



        //    }
        //    reader.Close();
        //    cnn.Close();


        //    return lista;
        //}
        //public void GuardarFamilia(Family c)
        //{
        //    try
        //    {
        //        var cnn = new SqlConnection(GetConnectionString());
        //        cnn.Open();
        //        var cmd = new SqlCommand();
        //        cmd.Connection = cnn;
        //        var sql = $@"delete from permiso_permiso where id_permiso_padre=@id;       ";
        //        cmd.CommandText = sql;
        //        cmd.Parameters.Add(new SqlParameter("ID", c.ID));
        //        cmd.ExecuteNonQuery();
        //        foreach (var item in c.Hijos)
        //        {
        //            cmd = new SqlCommand();
        //            cmd.Connection = cnn;


        //            sql = $@"insert into permiso_permiso (id_permiso_padre,id_permiso_hijo) values (@id_permiso_padre,@id_permiso_hijo) ";

        //            cmd.CommandText = sql;
        //            cmd.Parameters.Add(new SqlParameter("id_permiso_padre", c.ID));
        //            cmd.Parameters.Add(new SqlParameter("id_permiso_hijo", item.ID));

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public IList<Family> GetAllFamilias()
        //{

        //    var cnn = new SqlConnection(GetConnectionString());
        //    cnn.Open();
        //    var cmd = new SqlCommand();
        //    cmd.Connection = cnn;

        //    var sql = $@"select * from permiso p where p.permiso is  null;";

        //    cmd.CommandText = sql;

        //    var reader = cmd.ExecuteReader();

        //    var lista = new List<Family>();

        //    while (reader.Read())
        //    {


        //        var ID = reader.GetGuid(reader.GetOrdinal("ID"));
        //        var Name = reader.GetString(reader.GetOrdinal("Name"));


        //        Family c = new Family();

        //        c.ID = ID;
        //        c.Name = Name;
        //        lista.Add(c);

        //    }
        //    reader.Close();
        //    cnn.Close();


        //    return lista;
        //}
        //public void FillUserComponents(User u)
        //{

        //    var cnn = new SqlConnection(GetConnectionString());
        //    cnn.Open();

        //    var cmd2 = new SqlCommand();
        //    cmd2.Connection = cnn;
        //    cmd2.CommandText = $@"select p.* from usuarios_permisos up inner join permiso p on up.id_permiso=p.id where id_usuario=@id;";
        //    cmd2.Parameters.AddWithValue("ID", u.ID);

        //    var reader = cmd2.ExecuteReader();
        //    u.Permisos.Clear();
        //    while (reader.Read())
        //    {

        //        var idp = reader.GetGuid(reader.GetOrdinal("ID"));
        //        var nombrep = reader.GetString(reader.GetOrdinal("Name"));

        //        var permisop = String.Empty;
        //        if (reader["Permit"] != DBNull.Value)
        //            permisop = reader.GetString(reader.GetOrdinal("Permit"));

        //        Component c1;
        //        if (!String.IsNullOrEmpty(permisop))
        //        {
        //            c1 = new Patent();
        //            c1.ID = idp;
        //            c1.Name = nombrep;
        //            c1.Permit = (PermitType)Enum.Parse(typeof(PermitType), permisop);
        //            u.Permisos.Add(c1);
        //        }
        //        else
        //        {
        //            c1 = new Family();
        //            c1.ID = idp;
        //            c1.Name = nombrep;

        //            var f = GetAll("=" + idp);

        //            foreach (var familia in f)
        //            {
        //                c1.AgregarHijo(familia);
        //            }
        //            u.Permisos.Add(c1);
        //        }



        //    }
        //    reader.Close();

        //}
        //public void FillFamilyComponents(Family familia)
        //{
        //    familia.VaciarHijos();
        //    foreach (var item in GetAll("=" + familia.ID))
        //    {
        //        familia.AgregarHijo(item);
        //    }
        //}
    }
}
