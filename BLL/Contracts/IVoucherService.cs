﻿using Domain;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IVoucherService
    {
        Voucher Create(Voucher voucher);
        RejectionType[] GetTipoRechazo();
        IEnumerable<Voucher> GetScanVoucher();
        IEnumerable<Voucher> GetPickingVoucher();
        IEnumerable<Voucher> GetTransferVoucher();
        void Update(Voucher voucher);
    }
}
