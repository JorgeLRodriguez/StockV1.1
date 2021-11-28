using Services.DAL.Repositories.File;
using Services.Domain.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Logger
{
    public class FileLogger : ILogger
    {
        #region Singleton
        private static FileLogger logger;
        private static readonly object locker = new();
        public static FileLogger GetInstance()
        {
            if (logger == null)
            {
                lock (locker)
                {
                    if (logger == null)
                    {
                        logger = new FileLogger();
                    }
                }
            }
            return logger;
        }
        private FileLogger()
        {
        }
        #endregion
        public List<Log> GetAll()
        {
            return LogRepository.GetInstance().GetAllEntriesInLog() as List<Log>;
        }
        public void Store(Log log)
        {
            LogRepository.GetInstance().Save(log);
        }
    }
}
