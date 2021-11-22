using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.SecurityComposite
{
    public class Family : Component
    {
        private IList<Component> _hijos;
        public Family()
        {
            _hijos = new List<Component>();
        }

        public override IList<Component> Hijos
        {
            get
            {
                return _hijos.ToArray();
            }

        }

        public override void VaciarHijos()
        {
            _hijos = new List<Component>();
        }
        public override void AgregarHijo(Component c)
        {
            _hijos.Add(c);
        }
    }
}
