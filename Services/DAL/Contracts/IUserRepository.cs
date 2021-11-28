using Services.Domain.SecurityComposite;
using Services.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    public interface IUserRepository
    {
        User Login(string name, string password);
        User GetByID(Guid ID);
        List<User> GetAll();
        void SavePermit(User u);
    }
}
