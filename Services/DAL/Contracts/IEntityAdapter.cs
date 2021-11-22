namespace Services.DAL.Contracts
{
    internal interface IEntityAdapter<T>
    {
        T Adapt(object[] values);
    }
}
