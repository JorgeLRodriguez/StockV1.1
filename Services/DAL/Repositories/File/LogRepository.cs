using Services.DAL.Contracts;
using Services.Domain.Logger;
using Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services.DAL.Repositories.File
{
    public class LogRepository : ILogRepository
    {
        #region Singleton
        private static LogRepository logRepository;

        private static readonly object locker = new();
        public static LogRepository GetInstance()
        {
            if (logRepository == null)
            {
                lock (locker)
                {
                    if (logRepository == null)
                    {
                        logRepository = new LogRepository();
                    }
                }
            }
            return logRepository;
        }
        #endregion
        //public Event[] AvailableEvents
        //{
        //    get
        //    {
        //        var EventProperties = typeof(Event).GetFields();
        //        return EventProperties
        //            .Select(propertie => new Event
        //            {
        //                ID = (int)propertie.GetRawConstantValue(),
        //                Description = propertie.Name
        //            })
        //            .ToArray();
        //    }
        //}
        public IEnumerable<Log> GetAllEntriesInLog()
        {
            List<Log> list = new();
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(GlobalConfig.Instance.LogPath, FileMode.Open)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Enum.TryParse(line.Substring(line.IndexOf("[") + 1, line.IndexOf("]") - line.IndexOf("[") - 1).Replace("Severity", "").Trim(), out Severity sev);
                        Log log = new Log()
                        {
                            Message = line.Substring(line.IndexOf("]") + 1, line.Length - line.IndexOf("]") - 1).Replace(":", "").Trim(),
                            Severity = sev
                        };
                        list.Add(log);
                    }
                }
                return list;
            }
            catch
            {
                throw;
            }
        }
        public void Save(Log Log)
        {
            try
            {
                using StreamWriter streamWriter = new(GlobalConfig.Instance.LogPath, true);
                streamWriter.WriteLine($"{DateTime.Now:dd-MM-yyyy hh:mm:ss} [Severity { Log.Severity}] : { Log.Message }");
            }
            catch
            {
                throw;
            }
        }
    }
}