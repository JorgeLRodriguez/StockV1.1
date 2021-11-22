using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Contracts
{
    interface IUsuarioService
    {
        public List<User> GetAll();
        public void GuardarPermisos(User u);
    }
}
