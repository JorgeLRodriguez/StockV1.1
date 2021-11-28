using Services.BLL.Contracts;
using Services.DAL.Repositories.SqlServer;
using Services.Domain.SecurityComposite;
using System.Collections.Generic;

namespace Services.BLL.Services
{
    class UserService : IUserService
    {
        UserRepository userRepository;
        public UserService()
        {
            userRepository = UserRepository.Current;
        }
        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }
        public void SavePermission(User u)
        {
            userRepository.SavePermit(u);
        }
    }
}
