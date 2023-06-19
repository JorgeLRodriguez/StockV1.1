using Domain;

namespace BLL.Contracts
{
    public interface IProvinceService : IGetAllService<Province>, ICreateService<Province>, IUpdateService<Province>, IDeleteService<Province>
    {
    }
}
