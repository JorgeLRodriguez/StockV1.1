using Services.Domain.Logger;
using System;
using System.Collections.Generic;

namespace Services.BLL.Contracts
{
    public interface ILogService
    {
        Event[] GetAllAvailableEvents();
        IEnumerable<Log> GetAllLogs();
        IEnumerable<Log> GetAllLogs(DateTime from, DateTime to, Event e);
        void SaveLog(Log log, TypeLog type);
    }
}