using Services.DAL.Contracts;
using Services.DAL.Repositories.SqlServer.Adapters;
using Services.DAL.Repositories.Tools;
using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
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
        private string LogInStatement
        {
            get => "SELECT [ID] ,[Name] ,[Password] FROM [dbo].[User] WHERE [Name] = @name AND [Password] = @password";
        }
        private string FillComponentsStatement
        {
            get => "select p.* from User_Permits up inner join Permits p on up.Permits_ID=p.ID where User_ID=@ID";
        }
        private string GetByIDStatement
        {
            get => "SELECT [ID] ,[Name] FROM [dbo].[User] WHERE [ID] = @ID";
        }
        private string GetAllStatement
        {
            get => "SELECT [ID] ,[Name] ,[Password] FROM [dbo].[User]";
        }
        private string InsertPermissionStatement
        {
            get => $@"INSERT INTO [dbo].[User_Permits] ([User_ID] ,[Permits_ID]) VALUES (@User_ID ,@Permit_ID)";
        }
        private string DeletePermissionsSatatement
        {
            get => "DELETE FROM [dbo].[User_Permits] WHERE User_ID = @User_ID";
        }
        #endregion     
        public User Login(string name, string password)
        {
            User User = default;
            using (var dr = SqlHelper.ExecuteReader(LogInStatement, System.Data.CommandType.Text,
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
                u.Permissions.Clear();
                while (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);

                    if (dr["Permit"] != DBNull.Value)
                    {
                        u.Permissions.Add(PatentAdapter.Current.Adapt(values));
                    }
                    else
                    {
                        var f = FamilyAdapter.Current.Adapt(values);

                        var c = ComponentRepository.Current.GetAll("=" + f.ID);

                        foreach (var family in c)
                        {
                            f.AgregarHijo(family);
                        }
                        u.Permissions.Add(f);
                    }
                }
            }
        }
        public User GetByID(Guid ID)
        {
            using (var dr = SqlHelper.ExecuteReader(GetByIDStatement, System.Data.CommandType.Text,
                                                    new SqlParameter[] { new SqlParameter("@ID", ID)}))
            {
                if (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);
                    return UserAdapter.Current.Adapt(values);
                }
            }
            return null;
        }
        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            using (var dr = SqlHelper.ExecuteReader(GetAllStatement, System.Data.CommandType.Text))
            {
                while (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);
                    list.Add(UserAdapter.Current.Adapt(values));
                }
            }
            return list;
        }
        public void SavePermit(User u)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(DeletePermissionsSatatement, System.Data.CommandType.Text, new SqlParameter[] { new SqlParameter("@ID", u.ID) });

                foreach (var item in u.Permissions)
                {
                    SqlHelper.ExecuteNonQuery(InsertPermissionStatement, System.Data.CommandType.Text, new SqlParameter[] { new SqlParameter("@ID", u.ID) });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}