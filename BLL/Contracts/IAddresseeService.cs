using Domain;
using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IAddresseeService
    {
        Addressee Create(Addressee addressee);
        void Update(Addressee addressee);
        void Delete(Guid ID);
        IEnumerable<Addressee> Get();
    }
}
