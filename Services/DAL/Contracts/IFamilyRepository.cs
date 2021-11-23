using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    interface IFamilyRepository
    {
        void Save(Family f);
        IList<Family> GetAll();
        void FillFamilyComponents(Family familia);
    }
}
