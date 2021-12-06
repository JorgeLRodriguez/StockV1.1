using System;

namespace BLL.Contracts
{
    public interface IDeleteService <T>
    {
        void Delete(Guid ID);
    }
}
