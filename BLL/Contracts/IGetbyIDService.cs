using System;

namespace BLL.Contracts
{
    public interface IGetbyIDService <T>
    {
        T GetByID(Guid ID);
    }
}
