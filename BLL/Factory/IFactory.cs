using BLL.Contracts;
using System;

namespace BLL.Factory
{
    public interface IFactory : IDisposable
    {
        IAddresseeService AddresseeService { get; }
        IArticleService ArticleService { get; }
        IClientService ClientService { get; }
        ICSVService CSVService { get; }
        IDepositService DepositService { get; }
        IVoucherService VoucherService { get; }
        IPalletService PalletService { get; }
        IProvinceService ProvinceService { get; }
    }
}
