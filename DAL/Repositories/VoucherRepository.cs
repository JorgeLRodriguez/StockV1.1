using DAL.Contracts;
using Domain;
using System.Linq;

namespace DAL.Repositories
{
    class VoucherRepository : GenericRepository<Voucher>,  IVoucherRepository
    {
        private readonly DatabaseContext _db;
        public VoucherRepository(DatabaseContext db) : base(db)
        {
            _db = db;
        }
        public RejectionType[] GetRejectionTypes()
        {
            //Enumero por reflexión los tipos de rechazo disponibles en el sistema
            var properties = typeof(RejectionType).GetFields();
            return properties
                .Select(property => new RejectionType
                {
                    ID = (int)property.GetRawConstantValue(),
                    Description = property.Name
                })
                .ToArray();
        }
    }
}
