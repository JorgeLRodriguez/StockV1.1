using Services.BLL.Contracts;
using Services.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Factory
{
    public class ApplicationServices
    {
        #region Singleton
        private readonly static ApplicationServices _instance = new ApplicationServices();
        public static ApplicationServices Current
        {
            get
            {
                return _instance;
            }
        }
        private ApplicationServices()
        {
            GetUserTranslator = new UserTranslator();
            GetGlobalConfig = GlobalConfig.Instance;
        }
        #endregion
        public IUserTranslator GetUserTranslator { get; }
        public ILanguageSubscriber GetLanguageSubscriber { get; }
        public GlobalConfig GetGlobalConfig { get; }
    }
}
