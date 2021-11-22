using System;

namespace Services.DAL.Contracts
{
    public interface IGenericRepository<T>
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        T GetOne(Guid id);
    }
}
