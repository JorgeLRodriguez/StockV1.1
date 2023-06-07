using Domain;

namespace BLL.Contracts
{
    public interface IAisleService : ICreateService<Aisle>, IUpdateService<Aisle>, IDeleteService <Aisle>, IGetAllService<Aisle>
    {
    }
}
