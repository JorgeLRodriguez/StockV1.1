using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Contracts
{
    interface IPermitsService
    {
        public bool Existe(Component c, int id);
        public Array GetAllPermission();
        public Component GuardarComponente(Component p, bool esfamilia);
        public void GuardarFamilia(Family c);
        public IList<Patente> GetAllPatentes();
        public IList<Family> GetAllFamilias();
        public IList<Component> GetAll(string familia);
        public void FillUserComponents(User u);
        public void FillFamilyComponents(Family familia);
    }
}
