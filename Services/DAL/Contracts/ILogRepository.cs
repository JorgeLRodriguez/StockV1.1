using Services.Domain.Logger;
using System.Collections.Generic;

namespace Services.DAL.Contracts
{
    public interface ILogRepository
    {
        //Event[] AvailableEvents { get; }
        IEnumerable<Log> GetAllEntriesInLog();
        void Save(Log Log);
    }
}