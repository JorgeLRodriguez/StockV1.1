using Services.Domain.SecurityComposite;

namespace Services.BLL.Contracts
{
    public interface ISesionService
    {
        public void Login(User u);
        public void Logout();
    }
}
