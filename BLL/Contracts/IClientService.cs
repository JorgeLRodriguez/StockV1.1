using Domain;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IClientService
    {
        IEnumerable<Client> Get();
        Client GetByCuit(string cuit);
    }
}
