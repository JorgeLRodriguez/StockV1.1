using Domain.Integrity;
using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class SystemIntegrity
    {
        private readonly bool _isCorrupted;
        public class CorruptSystemException : Exception
        {
            public string ConstantError { get; set; }
            public string[] AffectedEntities { get; set; }
            public CorruptSystemException(IEnumerable<string> affectedEntities)
            {
                ConstantError = "ErrorSistemaCorrupto";
                AffectedEntities = affectedEntities.ToArray();
            }
        }
        public SystemIntegrity(bool isCorrupted)
        {
            _isCorrupted = isCorrupted;
        }
        public void CheckIntegrity()
        {
            var corruptedEntityNames = new List<string>();
            var typeEntityWithCheckDigit = typeof(IHorizontalCheckDigit);
            var typesSupportedWithCheckDigit = this.ListCompatibleTypes(typeEntityWithCheckDigit);
            foreach (var entityType in typesSupportedWithCheckDigit)
            {
                if (DAL.Factory.Factory.Current.IntegrityCDCalculatorRepository.ComprobarIntegridad(entityType))
                    corruptedEntityNames.Add(entityType.FullName);
            }
            if (_isCorrupted || corruptedEntityNames.Any())
                throw new CorruptSystemException(corruptedEntityNames);
        }
        private IEnumerable<Type> ListCompatibleTypes(Type expectedType)
        {
            return typeof(User).Assembly
                .GetTypes()
                .Where(entityType => entityType.IsClass
                                     && !entityType.IsAbstract
                                     && expectedType.IsAssignableFrom(entityType));
        }
    }
}