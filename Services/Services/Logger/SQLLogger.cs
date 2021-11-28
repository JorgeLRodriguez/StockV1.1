using Services.DAL.Repositories.SqlServer;
using Services.Domain.Logger;
using System.Collections.Generic;

namespace Services.Services.Logger
{
    public class SQLLogger : ILogger
    {
        #region Singleton
        private static SQLLogger logger;
        private static readonly object locker = new();
        public static SQLLogger GetInstance()
        {
            if (logger == null)
            {
                lock (locker)
                {
                    if (logger == null)
                    {
                        logger = new SQLLogger();
                    }
                }
            }
            return logger;
        }
        private SQLLogger()
        {
        }
        #endregion
        public List<Log> GetAll()
        {
            return LogRepository.Current.GetAllEntriesInLog() as List<Log>;
        }
        public void Store(Log log)
        {
            LogRepository.Current.Save(log);
        }
    }
}