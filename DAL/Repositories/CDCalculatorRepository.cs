using DAL.Contracts;
using Domain.Integrity;
using Services.Services.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class CDCalculatorRepository : ICDCalculatorRepository
    {
        private readonly Hash _hash = new();
        public byte[] CalculateCheckDigitForEntity(IHorizontalCheckDigit entity)
        {
            var seed = new StringBuilder();
            var tipoEntidad = entity.GetType();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(tipoEntidad))
            {
                var fieldMarkedForRc = propertyDescriptor.Attributes
                    .OfType<SensitiveData>()
                    .FirstOrDefault();

                if (fieldMarkedForRc != null)
                {
                    //TODO: Verificar el orden del armado de la semilla, mientras sea la misma version de la clase no importa
                    var propertyValueSerialized = Convert.ToString(propertyDescriptor.GetValue(entity) ?? string.Empty);
                    seed.Append(propertyValueSerialized);
                }
            }
            return _hash.CreateHash(seed.ToString());
        }
        public byte[] CalculateCheckDigitFromMultipleDigits(IEnumerable<byte[]> crcs)
        {
            return _hash.CreateHash(crcs);
        }

        public bool IsValid(IHorizontalCheckDigit entity)
        {
            var calculatedHash = this.CalculateCheckDigitForEntity(entity);
            var currentHash = entity.DVH ?? new byte[0];
            return calculatedHash.SequenceEqual(currentHash);
        }
    }
}
