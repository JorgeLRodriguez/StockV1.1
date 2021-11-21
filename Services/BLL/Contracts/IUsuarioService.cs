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
        public List<Usuario> GetAll();
        public void GuardarPermisos(Usuario u);
    }
}
