using Services.BLL.Contracts;
using Services.DAL.Repositories.SqlServer;
using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    class UsuarioService : IUsuarioService
    {
        UsuariosRepository _usuarios;
        public UsuarioService()
        {
            _usuarios = new UsuariosRepository();
        }

        public List<User> GetAll()
        {
            return _usuarios.GetAll();
        }

        public void GuardarPermisos(User u)
        {
            _usuarios.GuardarPermisos(u);
        }
    }
}
