using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Contracts
{
    interface IPermisosService
    {
        public bool Existe(Componente c, int id);
        public Array GetAllPermission();
        public Componente GuardarComponente(Componente p, bool esfamilia);
        public void GuardarFamilia(Familia c);
        public IList<Patente> GetAllPatentes();
        public IList<Familia> GetAllFamilias();
        public IList<Componente> GetAll(string familia);
        public void FillUserComponents(User u);
        public void FillFamilyComponents(Familia familia);
    }
}
