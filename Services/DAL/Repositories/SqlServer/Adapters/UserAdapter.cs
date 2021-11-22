using Services.DAL.Contracts;
using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Repositories.SqlServer.Adapters
{
    internal class UserAdapter : IEntityAdapter<User>
    {
        #region Singleton
        private readonly static UserAdapter _instance = new UserAdapter();
        public static UserAdapter Current
        {
            get
            {
                return _instance;
            }
        }
        private UserAdapter()
        {
        }
        #endregion
        public User Adapt(object[] values)
        {
            return new User()
            {
                ID = Guid.Parse(values[(int)Columns.ID].ToString()),
                Name = values[(int)Columns.Name].ToString(),
                Password = values[(int)Columns.Password].ToString()
            };
        }
        private enum Columns
        {
            ID,
            Name,
            Password
        }
    }
}
