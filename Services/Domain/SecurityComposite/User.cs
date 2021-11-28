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
            _permissions = new List<Component>();
        }
        List<Component> _permissions;
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Component> Permissions
        {
            get
            {
                return _permissions;
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
