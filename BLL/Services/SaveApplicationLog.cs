using Services.Domain.Logger;
using Services.Factory;
using Services.Services.Security;
using System;
using System.Diagnostics;

namespace BLL.Services
{
    internal class SaveApplicationLog
    {
        public void SaveException(Exception ex)
        {
            if (ex.StackTrace.Contains("ModelValidator")) throw ex;
            ApplicationServices.GetInstance().GetLogService.SaveLog (new Log() 
            { 
                Event_ID = 7, 
                Message = new StackTrace().GetFrame(1).GetMethod().Name + " - " + ex.Message + " " + (ex.InnerException == null ? "" : ex.InnerException.Message), 
                Severity = Severity.Critical, 
                User = ServicesUser.Instance.UserLogged, 
                DateTime = DateTime.Now 
            }, 
            TypeLog.File);
            throw new Exception("ErrorGenerico");
        }
        public void SaveLog(int eventType, Severity severity, string message)
        {
            ApplicationServices.GetInstance().GetLogService.SaveLog (new Log() 
            { 
                ID = Guid.NewGuid(), 
                Event_ID = eventType, 
                Severity = severity, 
                DateTime = DateTime.Now, 
                Message = message, 
                User = ServicesUser.Instance.UserLogged 
            }, 
            TypeLog.SQL);
        }
    }
}