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
    class PermitsService : IPermitsService
    {
        public PermitsService()
        {
        }
        public bool Exists(Component c, int id)
        {
            bool existe = false;
            if (c.ID.Equals(id))
                existe = true;
            else
                foreach (var item in c.Hijos)
                {
                    existe = Exists(item, id);
                    if (existe) return true;
                }
            return existe;
        }
        public Array GetAllPermission()
        {
            return PermitsRepository.Current.GetAll();
        }
        public Component GuardarComponente(Component p, bool esfamilia)
        {
            return ComponentRepository.Current.SaveComponent(p, esfamilia);
        }
        public void GuardarFamilia(Family c)
        {
            FamilyRepository.Current.Save(c);
        }
        public IList<Patent> GetAllPatentes()
        {
            return PatentRepository.Current.GetAll();
        }
        public IList<Family> GetAllFamilias()
        {
            return FamilyRepository.Current.GetAll();
        }
        public IList<Component> GetAll(string familia)
        {
            return ComponentRepository.Current.GetAll(familia);
        }
        public void FillUserComponents(User u)
        {
            UserRepository.Current.FillUserComponents(u);

        }
        public void FillFamilyComponents(Family familia)
        {
            FamilyRepository.Current.FillFamilyComponents(familia);
        }
    }
}
