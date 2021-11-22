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
    }
}
