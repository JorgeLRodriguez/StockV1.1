using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    interface IComponentRepository
    {
        IList<Component> GetAll(string familia);
        Component SaveComponent(Component p, bool isFamily);
    }
}
