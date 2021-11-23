using Services.DAL.Contracts;
using Services.DAL.Repositories.SqlServer.Adapters;
using Services.DAL.Repositories.Tools;
using Services.Domain.SecurityComposite;
using System;
using System.Data.SqlClient;

namespace Services.DAL.Repositories.SqlServer
{
    public class UserRepository : IUserRepository
    {
        #region Singleton
        private readonly static UserRepository _instance = new UserRepository();
        public static UserRepository Current
        {
            get
            {
                return _instance;
            }
        }
        private UserRepository()
        {
        }
        #endregion
        #region Statements
        private string SelectOneStatement
        {
            get => "SELECT [ID] ,[Name] ,[Password] FROM [dbo].[User] WHERE [Name] = @name AND [Password] = @password";
        }
        private string FillComponentsStatement
        {
            get => "select p.* from User_Permits up inner join Permits p on up.Permits_ID=p.ID where User_ID=@ID";
        }
        #endregion
        public User Login(string name, string password)
        {
            User User = default;
            using (var dr = SqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text,
                                                    new SqlParameter[] { new SqlParameter("@name", name)
                                                    , new SqlParameter("@password", password)})) 
            {
                if (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);
                    User = UserAdapter.Current.Adapt(values);
                }
            }
            return User;
        }
        public void FillUserComponents(User u)
        {
            using (var dr = SqlHelper.ExecuteReader(FillComponentsStatement, System.Data.CommandType.Text, new SqlParameter[] { new SqlParameter("@ID", u.ID) }))
            {
                u.Permisos.Clear();
                while (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);

                    if (dr["Permit"] != DBNull.Value)
                    {
                        u.Permisos.Add(PatentAdapter.Current.Adapt(values));
                    }
                    else
                    {
                        var f = FamilyAdapter.Current.Adapt(values);

                        var c = ComponentRepository.Current.GetAll("=" + f.ID);

                        foreach (var family in c)
                        {
                            f.AgregarHijo(family);
                        }
                        u.Permisos.Add(f);
                    }
                }
            }
        }
    }
}
