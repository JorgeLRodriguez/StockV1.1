using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Integrity
{
    /// <summary>
    /// Marca un campo de la entidad como dato sensible a nivel de negocio
    /// </summary>
    
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SensitiveData : Attribute
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string Value { get; set; }
    }
}
