using Domain;

namespace BLL.Contracts
{
    public interface IDepositService : IGetAllService<Deposit>, ICreateService<Deposit>, IUpdateService<Deposit>, IDeleteService<Deposit>
    {

    }
}
