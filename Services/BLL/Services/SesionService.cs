using Services.BLL.Contracts;
using Services.DAL.Repositories.SqlServer;
using Services.Domain.SecurityComposite;
using Services.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    public class SesionService : ISesionService
    {
        public void Login(User u)
        {

            if (String.IsNullOrEmpty(u.Name) || String.IsNullOrEmpty(u.Password))
                throw new ApplicationException("AtLogInEmptyorNull");

            try
            {
                u = UserRepository.Current.Login(u.Name,u.Password);
                if (u != null)
                {
                    //(new PermisosRepository()).FillUserComponents(u);
                    UserRepository.Current.FillUserComponents(u);
                    ServicesUser.GetInstance.Login(u);
                    return;
                }
                else

                //if (usuarioActual == null)
                {
                    //Registro el intento fallido de Login
                    //BitacoraModel.Default.RegistrarEnBitacora(Evento.UsuarioFalloIngresandoCredenciales, Severidad.Advertencia,
                    //    nombreUsuario);
                }
            }
            catch (Exception ex)
            {
                //Log.Save(this, ex);
                throw ex;
            }
            throw new Exception("AtLogInIncorrecto");
        }
        public void Logout()
        {
            ServicesUser.GetInstance.Logout();
        }
    }
}