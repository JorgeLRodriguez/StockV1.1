using Services.BLL.Contracts;
using Services.DAL.Repositories.SqlServer;
using Services.Domain.Logger;
using Services.Domain.SecurityComposite;
using Services.Services.Security;
using System;

namespace Services.BLL.Services
{
    public class SesionService : ISesionService
    {
        public void Login(User u)
        {
            if (String.IsNullOrEmpty(u.Name) || String.IsNullOrEmpty(u.Password))
                throw new ApplicationException("AtLogInEmptyorNull");
            string username = u.Name;
            try
            {
                u = UserRepository.Current.Login(u.Name,u.Password);
                if (u != null)
                {
                    UserRepository.Current.FillUserComponents(u);
                    ServicesUser.GetInstance.Login(u);
                    LogService.GetInstance().SaveLog(new Log() { ID = Guid.NewGuid(), DateTime = DateTime.Now, Severity = Severity.Informative, Event_ID = Event.UsuarioIngresoAlSistema, Message = u.Name, User = u }, TypeLog.SQL);
                    return;
                }
                else
                {
                    LogService.GetInstance().SaveLog(new Log() { ID = Guid.NewGuid(), DateTime = DateTime.Now, Severity = Severity.Warning, Event_ID = Event.UsuarioFalloIngresandoCredenciales, Message = username, User = new User() { ID = Guid.Empty} }, TypeLog.SQL);
                }
            }
            catch (Exception ex)
            {
                LogService.GetInstance().SaveLog(new Log() { ID = Guid.NewGuid(), DateTime = DateTime.Now, Severity = Severity.Warning, Event_ID = Event.ErrorDeSistema, Message = ex.Message }, TypeLog.File);
                throw new Exception (ex.Message);
            }
            throw new Exception("AtLogInIncorrecto");
        }
        public void Logout()
        {
            ServicesUser.GetInstance.Logout();
        }
    }
}