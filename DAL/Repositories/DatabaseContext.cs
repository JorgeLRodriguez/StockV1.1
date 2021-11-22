using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain;

namespace DAL.Repositories
{
    public class DatabaseContext : DatabaseContextCD
    {
        private static DatabaseContext _instance;
        public DatabaseContext() : base(ConfigurationManager.ConnectionStrings["cnn"].ToString(), new CDCalculatorRepository()) {}
        public static DatabaseContext Instance()
        {
            return _instance = _instance ?? new DatabaseContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual IDbSet<Client> Cliente { get; set; }
        public IDbSet<Article> Articulo { get; set; }
        public IDbSet<Voucher> Comprobante { get; set; }
        public IDbSet<VoucherDetail> ComprobanteDetalle { get; set; }
        public IDbSet<Numerator> Numerador { get; set; }
        public IDbSet<Label> Etiqueta { get; set; }    
        public IDbSet<Addressee> Destinatario { get; set; }
        public IDbSet<Deposit> Deposito { get; set; }
    }
}
