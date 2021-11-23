using Services.DAL.Contracts;
using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Repositories.SqlServer
{
    public class PermitsRepository : IPermitsRepository
    {
        #region Singleton
        private readonly static PermitsRepository _instance = new PermitsRepository();
        public static PermitsRepository Current
        {
            get
            {
                return _instance;
            }
        }
        private PermitsRepository()
        {
        }
        #endregion
        public Array GetAll()
        {
            return Enum.GetValues(typeof(PermitType));
        }
    }
}
