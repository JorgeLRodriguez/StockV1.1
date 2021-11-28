using Services.DAL.Contracts;
using Services.Domain.Logger;
using System;

namespace Services.DAL.Repositories.SqlServer.Adapters
{
    public class LogAdapter : IEntityAdapter <Log>
    {
        #region Singleton
        private readonly static LogAdapter _instance = new LogAdapter();
        public static LogAdapter Current
        {
            get
            {
                return _instance;
            }
        }
        private LogAdapter()
        {
        }
        #endregion
        public Log Adapt(object[] values)
        {
            return new Log()
            {
                ID = Guid.Parse(values[(int)Columns.ID].ToString()),
                Event_ID = Convert.ToInt32(values[(int)Columns.ID].ToString()),
                User = UserRepository.Current.GetByID(Guid.Parse(values[(int)Columns.User_ID].ToString())),
                Message = values[(int)Columns.Message].ToString(),
                DateTime = DateTime.Parse(values[(int)Columns.Created].ToString()),
                Severity = (Severity)Enum.Parse(typeof(Severity), values[(int)Columns.Severity].ToString())

            };
        }
        private enum Columns
        {
            ID,
            Event_ID,
            Severity,
            Message,
            User_ID,
            Created
        }
    }
}