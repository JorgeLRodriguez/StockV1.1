using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain;

namespace DAL.Repositories
{
    public class DatabaseContext : DbContext
    {
        private static DatabaseContext _instance;
        public DatabaseContext() : base("name=DefaultConnection"){}
        public static DatabaseContext Instance()
        {
            return _instance = _instance ?? new DatabaseContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual IDbSet<Cliente> Cliente { get; set; }
        public IDbSet<Articulo> Articulo { get; set; }
        public IDbSet<Comprobante> Comprobante { get; set; }
        public IDbSet<ComprobanteDetalle> ComprobanteDetalle { get; set; }
        public IDbSet<Numerador> Numerador { get; set; }
        public IDbSet<Etiqueta> Etiqueta { get; set; }    
        public IDbSet<Destinatario> Destinatario { get; set; }
        public IDbSet<Deposito> Deposito { get; set; }
    }
}
