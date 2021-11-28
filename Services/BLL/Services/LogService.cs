using Services.BLL.Contracts;
using Services.DAL.Contracts;
using Services.DAL.Repositories.SqlServer;
using Services.Domain.Logger;
using Services.Domain.SecurityComposite;
using Services.Services.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    class LogService : ILogService
    {
        private readonly IUserTranslator userTranslator;
        #region Singleton
        private static LogService logger;

        private static readonly object locker = new();
        public static LogService GetInstance()
        {
            if (logger == null)
            {
                lock (locker)
                {
                    if (logger == null)
                    {
                        logger = new LogService();
                    }
                }
            }
            return logger;
        }
        private LogService()
        {
            userTranslator = UserTranslator.Current;
        }
        #endregion
        public Event[] GetAllAvailableEvents()
        {
            var EventProperties = typeof(Event).GetFields();
            return EventProperties
                .Select(propertie => new Event
                {
                    ID = (int)propertie.GetRawConstantValue(),
                    Description = userTranslator.Translate(propertie.Name)
                })
                .ToArray();
        }
        public IEnumerable<Log> GetAllLogs()
        {
            try
            {
                IEnumerable<Log> list =
                    LoggerFactory.GetInstance().GetTypeLog(TypeLog.SQL).GetAll().Union(LoggerFactory.GetInstance().GetTypeLog(TypeLog.File).GetAll()).OrderByDescending(x => x.DateTime);
                foreach (var item in list)
                {
                    var eventID = item.Event.ID;
                    var field = typeof(Event).GetFields(BindingFlags.Public | BindingFlags.Static)
                        .Single(f => (int)f.GetValue(null) == eventID);

                    item.Event.Description = this.TranslateEvent(field.Name);
                }
                return list;
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
        public IEnumerable<Log> GetAllLogs(DateTime from, DateTime to, Event e)
        {
            if (e != null && e.ID < 0)
                e = null;

            return this.GetAllLogs()
                .Where(l => l.DateTime >= from && l.DateTime <= to)
                .Where(l => e == null || e.ID.Equals(l.Event.ID));
        }
        public void SaveLog(Log log, TypeLog type)
        {
            LoggerFactory.GetInstance().GetTypeLog(type).Store(log);
        }
        private string TranslateEvent(string e)
        {
            return userTranslator.Translate("Evento" + e);
        }
    }
}
