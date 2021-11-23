using Services.DAL.Contracts;
using Services.DAL.Repositories.SqlServer.Adapters;
using Services.DAL.Repositories.Tools;
using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Services.DAL.Repositories.SqlServer
{
    class FamilyRepository : IFamilyRepository
    {
        #region Singleton
        private readonly static FamilyRepository _instance = new FamilyRepository();
        public static FamilyRepository Current
        {
            get
            {
                return _instance;
            }
        }
        private FamilyRepository()
        {
        }
        #endregion
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Permits_Permits] ([ID_FatherPermit] ,[ID_ChildPermit]) VALUES (@ID_FatherPermit,@ID_ChildPermit)";
        }
        private string DeleteStatement
        {
            get => "DELETE FROM Permit_Permit WHERE ID_Father_Permit=@ID";
        }
        private string SelectAllStatement
        {
            get => "select * from Permits p where p.Permit is null";
        }
        #endregion
        public IList<Family> GetAll()
        {
            var list = new List<Family>();
            using var dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text);
            while (dr.Read())
            {
                object[] values = new object[dr.FieldCount];
                dr.GetValues(values);
                Family f = new Family();
                f = FamilyAdapter.Current.Adapt(values);
                list.Add(f);
            }
            return list;
        }
        public void Save(Family f)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(DeleteStatement, System.Data.CommandType.Text, new SqlParameter[]{new SqlParameter ("@ID",f.ID)});

                foreach (var item in f.Hijos)
                {
                    SqlParameter[] parameters = new SqlParameter[2];
                    parameters[0] = new SqlParameter("@ID_FatherPermit", f.ID);
                    parameters[1] = new SqlParameter("@ID_ChildPermit", item.ID);
                    SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void FillFamilyComponents(Family familia)
        {
            familia.VaciarHijos();
            foreach (var item in ComponentRepository.Current.GetAll("=" + familia.ID))
            {
                familia.AgregarHijo(item);
            }
        }
    }
}
