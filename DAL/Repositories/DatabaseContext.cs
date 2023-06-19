using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain;
using Domain.Integrity;

namespace DAL.Repositories
{
    public class DatabaseContext : DatabaseContextCD
    {
        private static DatabaseContext _instance;
        public DatabaseContext() : base(ConfigurationManager.ConnectionStrings["cnn"].ToString(), new CDCalculatorRepository())
        {
            Database.SetInitializer<DatabaseContext>(null);
        }
        public static DatabaseContext Instance()
        {
            return _instance ??= new DatabaseContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual IDbSet<Client> Client { get; set; }
        public IDbSet<Article> Article { get; set; }
        public IDbSet<Voucher> Voucher { get; set; }
        public IDbSet<VoucherDetail> VoucherDetail { get; set; }
        public IDbSet<Numerator> Numerator { get; set; }
        public IDbSet<Label> Label { get; set; }
        public IDbSet<Addressee> Addressee { get; set; }
        public IDbSet<Deposit> Deposit { get; set; }
        public IDbSet<VerticalCheckDigit> VerticalCheckDigit { get; set; }
        public IDbSet<CSV> CSV { get; set; }
        public IDbSet<Locality> Locality { get; set; }
        public IDbSet<Province> Province { get; set; }
    }
}
