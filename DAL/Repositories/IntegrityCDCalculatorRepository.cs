using DAL.Contracts;
using Domain.Integrity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    internal class IntegrityCDCalculatorRepository : IIntegrityCDCalculatorRepository
    {
        private readonly DatabaseContext _context;
        private readonly ICDCalculatorRepository _calculadoraDv;
        public IntegrityCDCalculatorRepository(DatabaseContext context)
        {
            _context = context;
            _calculadoraDv = new CDCalculatorRepository();
        }
        public bool ComprobarIntegridad(Type tipoEntidad)
        {
            var entityDbSet = (IQueryable)_context.Set(tipoEntidad);
            return this.IsEntityCorrupted(entityDbSet, tipoEntidad);
        }
        private bool IsEntityCorrupted(IQueryable entityDbSet, Type entityType)
        {
            var crcs = new List<byte[]>();
            foreach (IHorizontalCheckDigit entity in entityDbSet.AsNoTracking())
            {
                //Aborto si ya encontre un registro corrupto
                if (!_calculadoraDv.IsValid(entity))
                    return true;

                crcs.Add(entity.DVH);
            }
            //Si nunca grabe entidades de este tipo, ni tampoco tengo un DVV, puede darse este caso y no debe fallar
            var digitoVerificadorVerticalGuardado = _context.Set<VerticalCheckDigit>().Find(entityType.FullName);
            if (digitoVerificadorVerticalGuardado == null && crcs.Count == 0)
                return false;
            //Calculo el hash vertical con todos los CRC individuales y lo comparo con lo que tengo almacenado
            var verticalChecksum = _calculadoraDv.CalculateCheckDigitFromMultipleDigits(crcs);
            return !verticalChecksum.SequenceEqual(digitoVerificadorVerticalGuardado.Checksum);
        }
    }
}
