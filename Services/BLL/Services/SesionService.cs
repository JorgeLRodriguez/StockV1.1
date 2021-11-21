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
    class SesionService : ISesionService
    {
        public void Login(Usuario u)
        {
            (new PermisosRepository()).FillUserComponents(u);
            ServicesUser.GetInstance.Login(u);
        }
        public void Logout()
        {
            ServicesUser.GetInstance.Logout();
        }
    }
}
