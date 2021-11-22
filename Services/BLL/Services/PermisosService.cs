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
    class PermisosService : IPermitsService
    {
        PermisosRepository _permisos;
        public PermisosService()
        {
            _permisos = new PermisosRepository();
        }

        public bool Existe(Component c, int id)
        {
            bool existe = false;

            if (c.ID.Equals(id))
                existe = true;
            else

                foreach (var item in c.Hijos)
                {

                    existe = Existe(item, id);
                    if (existe) return true;
                }

            return existe;

        }


        public Array GetAllPermission()
        {
            return _permisos.GetAllPermission();
        }


        public Component GuardarComponente(Component p, bool esfamilia)
        {
            return _permisos.GuardarComponente(p, esfamilia);
        }


        public void GuardarFamilia(Family c)
        {
            _permisos.GuardarFamilia(c);
        }

        public IList<Patente> GetAllPatentes()
        {
            return _permisos.GetAllPatentes();
        }

        public IList<Family> GetAllFamilias()
        {
            return _permisos.GetAllFamilias();
        }

        public IList<Component> GetAll(string familia)
        {
            return _permisos.GetAll(familia);

        }

        public void FillUserComponents(User u)
        {
            _permisos.FillUserComponents(u);

        }

        public void FillFamilyComponents(Family familia)
        {
            _permisos.FillFamilyComponents(familia);
        }
    }
}
