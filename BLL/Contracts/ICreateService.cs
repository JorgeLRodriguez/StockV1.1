namespace BLL.Contracts
{
    public interface ICreateService <T>
    {
        T Create(T entity);
    }
}
