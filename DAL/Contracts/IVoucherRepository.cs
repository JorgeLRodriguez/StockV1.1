using Domain;

namespace DAL.Contracts
{
    public interface IVoucherRepository : IGenericRepository<Voucher>
    {
        RejectionType[] GetRejectionTypes();
    }
}
