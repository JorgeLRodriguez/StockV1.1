using Services.BLL.Contracts;
using Services.BLL.Services;
using Services.Services;
using Services.Services.ModelValidator;
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
        private readonly static ApplicationServices _instance = new();
        public static ApplicationServices Current
        {
            get
            {
                return _instance;
            }
        }
        private ApplicationServices()
        {
            GetUserTranslator = UserTranslator.Current;
            GetGlobalConfig = GlobalConfig.Instance;
            GetSesionService = new SesionService();
            GetLogService = LogService.GetInstance();
        }
        #endregion
        public IUserTranslator GetUserTranslator { get; }
        public ILanguageSubscriber GetLanguageSubscriber { get; }
        public ISesionService GetSesionService { get; }
        public ILogService GetLogService { get; set; }
        public GlobalConfig GetGlobalConfig { get; }
    }
}
