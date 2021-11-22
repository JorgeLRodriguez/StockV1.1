﻿using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Security
{
    public class ServicesUser
    {
        static ServicesUser _sesion;
        User _usuario;

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
            return _usuario != null;
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
            foreach (var item in _usuario.Permisos)
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
            _sesion._usuario = null;
        }


        public void Login(User u)
        {
            _sesion._usuario = u;

        }

        private ServicesUser()
        {

        }
    }
}
