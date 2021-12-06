using BLL.Contracts;
using BLL.Services;
using System;

namespace BLL.Factory
{
    public class Factory : IFactory
    {
        #region Singleton
        private static Factory _instance;

        private static readonly object locker = new();
        public static Factory GetInstance()
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    if (_instance == null)
                    {
                        _instance = new Factory();
                    }
                }
            }
            return _instance;
        }
        private Factory()
        {
            ArticleService = new ArticleService();
            ClientService = new ClientService();
            VoucherService = new VoucherService();
            CSVService = new CSVService();
            DepositService = new DepositService();
            AddresseeService = new AddresseeService();
            PalletService = new PalletService();
        }
        #endregion
        public IAddresseeService AddresseeService { get; }
        public IArticleService ArticleService { get ; } 
        public IClientService ClientService { get; }
        public ICSVService CSVService { get; }
        public IDepositService DepositService { get; }
        public IVoucherService VoucherService { get; }
        public IPalletService PalletService { get; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
