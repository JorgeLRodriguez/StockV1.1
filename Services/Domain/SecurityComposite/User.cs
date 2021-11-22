using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.SecurityComposite
{
    public class User
    {
        public User()
        {
            _permisos = new List<Component>();
        }
        List<Component> _permisos;
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Component> Permisos
        {
            get
            {
                return _permisos;
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
