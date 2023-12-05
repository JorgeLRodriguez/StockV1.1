using Domain;

namespace BLL.Contracts
{
    public interface ILocalityService : IGetbyIDService<Locality>, IGetAllService<Locality>, ICreateService<Locality>, IUpdateService<Locality>, IDeleteService<Locality>
    {
    }
}
