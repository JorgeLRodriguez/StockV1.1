using Services.Domain.SecurityComposite;

namespace Services.BLL.Contracts
{
    interface ISesionService
    {
        public void Login(Usuario u);
        public void Logout();
    }
}
