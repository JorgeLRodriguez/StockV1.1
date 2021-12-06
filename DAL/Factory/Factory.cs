using DAL.Contracts;
using DAL.Repositories;
using Domain;

namespace DAL.Factory
{
    public sealed class Factory
    {
        #region Singleton
        private readonly static Factory _instance = new();
        private readonly DatabaseContext _db;
        public static Factory Current
        {
            get
            {
                return _instance;
            }
        }
        private Factory()
        {
            _db = new DatabaseContext();
            CDCalculatorRepository = new CDCalculatorRepository();
            ArticleRepository = new GenericRepository<Article>(_db);
            ClientRepository = new GenericRepository<Client>(_db);
            NumeratorRepository = new GenericRepository<Numerator>(_db);
            IntegrityCDCalculatorRepository = new IntegrityCDCalculatorRepository(_db);
            VoucherRepository = new VoucherRepository(_db);
            CSVRepository = new GenericRepository<CSV>(_db);
            DepositRepository = new GenericRepository<Deposit>(_db);
            PalletRepository = new GenericRepository<Pallet>(_db);
        }
        #endregion
        public ICDCalculatorRepository CDCalculatorRepository { get; }
        public IGenericRepository<Article> ArticleRepository { get; }
        public IGenericRepository<Client> ClientRepository { get; }
        public IGenericRepository<Numerator> NumeratorRepository { get; }
        public IGenericRepository<CSV> CSVRepository { get; }
        public IIntegrityCDCalculatorRepository IntegrityCDCalculatorRepository { get; }
        public IVoucherRepository VoucherRepository { get; }
        public IGenericRepository<Deposit> DepositRepository { get; }
        public IGenericRepository<Pallet> PalletRepository { get; }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
