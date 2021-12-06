namespace BLL.Contracts
{
    public interface IUpdateService <T>
    {
        void Update(T entity);
    }
}
