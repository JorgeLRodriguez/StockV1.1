using Domain;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IPalletService : IGetAllService<Pallet>, ICreateService<Pallet>, IUpdateService<Pallet>, IDeleteService<Pallet>
    {
        List<Pallet> GetByDep(Deposit deposit);
    }
}