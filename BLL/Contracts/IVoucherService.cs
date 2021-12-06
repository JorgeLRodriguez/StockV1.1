using Domain;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IVoucherService : ICreateService<Voucher>, IUpdateService<Voucher>
    {
        RejectionType[] GetRejectionTypes();
        IEnumerable<Voucher> GetScanVoucher();
        IEnumerable<Voucher> GetPickingVoucher();
        IEnumerable<Voucher> GetTransferVoucher();
    }
}
