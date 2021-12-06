using Domain;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IClientService : IGetAllService<Client>
    {
        Client GetByCuit(string cuit);
    }
}