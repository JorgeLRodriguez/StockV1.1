using Services.DAL.Contracts;
using Services.DAL.Repositories.SqlServer.Adapters;
using Services.DAL.Repositories.Tools;
using Services.Domain.Logger;
using Services.Services.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Services.DAL.Repositories.SqlServer
{
    public class LogRepository : ILogRepository
    {
        #region Singleton
        private readonly static LogRepository _instance = new();
        public static LogRepository Current
        {
            get
            {
                return _instance;
            }
        }
        private LogRepository()
        {
        }
        #endregion
        #region Statements
        private static string SelectAllStatement
        {
            get => "SELECT [ID] ,[Event_ID] ,[Severity] ,[Menssage] ,[User_ID] ,[Created] FROM [dbo].[Log]";
        }
        private static string SaveStatement
        {
            get => "INSERT INTO [dbo].[Log] ([ID] ,[Event_ID] ,[Severity] ,[Message] ,[User_ID] ,[Created]) VALUES (@ID,@Event_ID,@Severity,@Message,@User_ID,@Created)";
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
            var list = new List<Log>();
            using var dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text);
            while (dr.Read())
            {
                object[] values = new object[dr.FieldCount];
                dr.GetValues(values);
                list.Add(LogAdapter.Current.Adapt(values));
            }
            return list;
        }
        public void Save(Log Log)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(SaveStatement, System.Data.CommandType.Text, new SqlParameter[]
                {
                    new SqlParameter("@ID", Log.ID),
                    new SqlParameter("@Event_ID",Log.Event_ID),
                    new SqlParameter("@Severity",Log.Severity),
                    new SqlParameter("@Message",Log.Message),
                    new SqlParameter("@User_ID",Log.User.ID),
                    new SqlParameter("@Created",Log.DateTime)
                });
            }
            catch
            {
                throw;
            }
        }
    }
}
