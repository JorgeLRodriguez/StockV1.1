using DAL.Factory;
using Domain.Integrity;
using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class SystemIntegrity
    {
        private readonly bool _estaCorrupto;
        public class SistemaCorruptoException : Exception
        {
            public string ConstanteError { get; set; }
            public string[] EntidadesAfectadas { get; set; }
            public SistemaCorruptoException(IEnumerable<string> entidadesAfectadas)
            {
                this.ConstanteError = "ErrorSistemaCorrupto";
                this.EntidadesAfectadas = entidadesAfectadas.ToArray();
            }
        }
        //TODO: Este constructor esta solo a modo de ejemplo
        public SystemIntegrity(bool estaCorrupto)
        {
            _estaCorrupto = estaCorrupto;
        }
        public void ComprobarIntegridad()
        {
            var corruptedEntityNames = new List<string>();
            var tipoEntidadConDigitoVerificador = typeof(IHorizontalCheckDigit);
            var tiposSoportadosConDigitoVerificador = this.EnumerarTiposCompatibles(tipoEntidadConDigitoVerificador);
            foreach (var tipoEntidad in tiposSoportadosConDigitoVerificador)
            {
                if (DAL.Factory.Factory.Current.IntegrityCDCalculatorRepository.ComprobarIntegridad(tipoEntidad))
                    corruptedEntityNames.Add(tipoEntidad.FullName);
            }
            //Reviento si al menos existe una entidad corrupta
            if (_estaCorrupto || corruptedEntityNames.Any())
                throw new SistemaCorruptoException(corruptedEntityNames);
        }
        private IEnumerable<Type> EnumerarTiposCompatibles(Type tipoEsperado)
        {
            return typeof(User).Assembly
                .GetTypes()
                .Where(entityType => entityType.IsClass
                                     && !entityType.IsAbstract
                                     && tipoEsperado.IsAssignableFrom(entityType));
        }
    }
}