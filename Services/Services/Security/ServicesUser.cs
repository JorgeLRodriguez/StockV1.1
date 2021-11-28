using Services.Domain.SecurityComposite;

namespace Services.Services.Security
{
    public class ServicesUser
    {
        static ServicesUser _sesion;
        User _user = default;
        public static ServicesUser GetInstance
        {
            get
            {
                if (_sesion == null) _sesion = new ServicesUser();
                return _sesion;
            }
        }
        public bool IsLoggedIn()
        {
            return _user != null;
        }
        bool isInRole(Component c, PermitType permiso, bool existe)
        {
            if (c.Permit.Equals(permiso))
                existe = true;
            else
            {
                foreach (var item in c.Hijos)
                {
                    existe = isInRole(item, permiso, existe);
                    if (existe) return true;
                }
            }

            return existe;
        }
        public bool IsInRole(PermitType permiso)
        {
            bool existe = false;
            foreach (var item in _user.Permissions)
            {
                if (item.Permit.Equals(permiso))
                    return true;
                else
                {
                    existe = isInRole(item, permiso, existe);
                    if (existe) return true;
                }

            }
            return existe;
        }
        public void Logout()
        {
            _sesion._user = null;
        }
        public void Login(User u)
        {
            _sesion._user = u;
        }
        private ServicesUser()
        {
        }
        public User UserLogged
        {
            get { return _user; }
            private set { _user = value; }
        }
    }
}
