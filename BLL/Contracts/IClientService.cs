using Domain;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IClientService : IGetAllService<Client>, ICreateService<Client>, IUpdateService<Client>, IDeleteService<Client>
    {
        Client GetByCuit(string cuit);
    }
}