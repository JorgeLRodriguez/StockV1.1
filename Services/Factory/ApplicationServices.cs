using Services.BLL.Contracts;
using Services.BLL.Services;
using Services.DAL.Contracts;
using Services.DAL.Repositories.SqlServer;
using Services.Services;
using Services.Services.Security;

namespace Services.Factory
{
    public class ApplicationServices
    {
        #region Singleton
        private static ApplicationServices _instance;

        private static readonly object locker = new();
        public static ApplicationServices GetInstance()
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    if (_instance == null)
                    {
                        _instance = new ApplicationServices();
                    }
                }
            }
            return _instance;
        }
        private ApplicationServices()
        {
            GetGlobalConfig = GlobalConfig.Instance;
            GetServicesUser = ServicesUser.Instance;
            GetRestoreBackup = RestoreBackup.Instance;
            GetUserTranslator = new UserTranslator();
            GetSesionService = new SesionService();
            GetLogService = new LogService(GetUserTranslator);
        }
        #endregion
        public IUserTranslator GetUserTranslator { get; }
        public ILanguageSubscriber GetLanguageSubscriber { get; }
        public ISesionService GetSesionService { get; }
        public ILogService GetLogService { get; set; }
        public IRestoreBackup GetRestoreBackup { get; set; }
        public GlobalConfig GetGlobalConfig { get; }
        public ServicesUser GetServicesUser { get; }
    }
}
