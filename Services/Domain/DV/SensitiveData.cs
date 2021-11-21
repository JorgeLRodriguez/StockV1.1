using System;

namespace Services.Domain.DV
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SensitiveData : Attribute
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string Value { get; set; }
    }
}