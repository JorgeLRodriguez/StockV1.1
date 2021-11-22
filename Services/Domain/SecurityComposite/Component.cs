using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.SecurityComposite
{
    public abstract class Component
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public abstract IList<Component> Hijos { get; }
        public abstract void AgregarHijo(Component c);
        public abstract void VaciarHijos();
        public PermitType Permit { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
