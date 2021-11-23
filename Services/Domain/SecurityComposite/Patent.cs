using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.SecurityComposite
{
    public class Patent : Component
    {
        public override IList<Component> Hijos
        {
            get
            {
                return new List<Component>();
            }

        }

        public override void AgregarHijo(Component c)
        {

        }

        public override void VaciarHijos()
        {

        }
    }
}
