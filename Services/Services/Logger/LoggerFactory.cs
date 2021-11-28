using Services.Domain.Logger;

namespace Services.Services.Logger
{
    internal sealed class LoggerFactory
    {
        #region Singleton
        private static LoggerFactory logger;

        private static readonly object locker = new();
        public static LoggerFactory GetInstance()
        {
            if (logger == null)
            {
                lock (locker)
                {
                    if (logger == null)
                    {
                        logger = new LoggerFactory();
                    }
                }
            }
            return logger;
        }
        #endregion
        public ILogger GetTypeLog(TypeLog _typeLog)
        {
            return _typeLog switch
            {
                TypeLog.SQL => SQLLogger.GetInstance(),
                TypeLog.File => FileLogger.GetInstance(),
                _ => null,
            };
        }
    }
}
