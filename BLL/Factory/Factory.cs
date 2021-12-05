using BLL.Contracts;
using BLL.Services;
using System;

namespace BLL.Factory
{
    public class Factory : IFactory
    {
        #region Singleton
        private readonly static Factory _instance = new();
        public static Factory Current
        {
            get
            {
                return _instance;
            }
        }
        private Factory()
        {
            ArticleService = new ArticleService();
            ClientService = new ClientService();
            VoucherService = new VoucherService();
            CSVService = new CSVService();
            DepositService = new DepositService();
            AddresseeService = new AddresseeService();
        }
        #endregion

        public IAddresseeService AddresseeService { get; }
        public IArticleService ArticleService { get ; } 
        public IClientService ClientService { get; }
        public ICSVService CSVService { get; }
        public IDepositService DepositService { get; }
        public IVoucherService VoucherService { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
