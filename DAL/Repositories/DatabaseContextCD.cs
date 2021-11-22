using DAL.Contracts;
using Domain.Integrity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class DatabaseContextCD : DbContext
    {
        private readonly ICDCalculatorRepository _calculadoraDigitosVerificadores;
        protected DatabaseContextCD(string cnnString, ICDCalculatorRepository calculadoraDigitosVerificadores)
            : base(cnnString)
        {
            _calculadoraDigitosVerificadores = calculadoraDigitosVerificadores;
        }
        #region "Sobrescritura de los métodos "Save" que es el punto central en donde pueden modificarse las entidades"
        protected int DefaultSaveChanges()
        {
            return base.SaveChanges();
        }
        public override int SaveChanges()
        {
            var tipoDeEntidadesAfectadas = this.RecalcularDigitosVerificadores();
            var cantidadEntidadesAfectadas = this.DefaultSaveChanges();
            this.ActualizarDigitosVerificadoresVerticales(tipoDeEntidadesAfectadas);
            return cantidadEntidadesAfectadas;
        }
        protected Task<int> DefaultSaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var tipoDeEntidadesAfectadas = this.RecalcularDigitosVerificadores();
            var cantidadEntidadesAfectadas = this.DefaultSaveChangesAsync(cancellationToken);
            this.ActualizarDigitosVerificadoresVerticales(tipoDeEntidadesAfectadas);
            return cantidadEntidadesAfectadas;
        }
        #endregion
        private Type[] RecalcularDigitosVerificadores()
        {
            var grupoDeEntidadesAfectadas = new List<Type>();
            var entidadesMarcadasParaAgregar = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            var entidadesMarcadasParaEliminar = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted);
            var entidadesMarcadasParaModificar = this.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);

            this.RecalcularDigitosVerificadoresHorizontales(grupoDeEntidadesAfectadas, entidadesMarcadasParaAgregar.Concat(entidadesMarcadasParaModificar)); //Afectan cada Digito Horizontal
            this.RecalcularDigitosVerificadoresVerticales(grupoDeEntidadesAfectadas, entidadesMarcadasParaEliminar); //Afectan solo al Digito Vertical
            return grupoDeEntidadesAfectadas.Distinct().ToArray();
        }
        private void RecalcularDigitosVerificadoresHorizontales(IList<Type> grupoDeEntidadesAfectadas, IEnumerable<DbEntityEntry> entries)
        {
            foreach (var dbEntityEntry in entries)
            {
                if (dbEntityEntry.Entity is IHorizontalCheckDigit entidadConDigitoVerificador)
                {
                    entidadConDigitoVerificador.DVH = _calculadoraDigitosVerificadores.CalculateCheckDigitForEntity(entidadConDigitoVerificador);
                    var entityType = ObtenerTipoDeEntidad(entidadConDigitoVerificador);
                    grupoDeEntidadesAfectadas.Add(entityType);
                }
            }
        }
        private void RecalcularDigitosVerificadoresVerticales(IList<Type> grupoDeEntidadesAfectadas, IEnumerable<DbEntityEntry> entries)
        {
            foreach (var dbEntityEntry in entries)
            {
                if (dbEntityEntry.Entity is IHorizontalCheckDigit entidadConDigitoVerificador)
                    grupoDeEntidadesAfectadas.Add(ObtenerTipoDeEntidad(entidadConDigitoVerificador));
            }
        }
        private void ActualizarDigitosVerificadoresVerticales(Type[] affectedTypes)
        {
            var context = this;
            if (affectedTypes.Any())
            {
                foreach (var affectedGroupType in affectedTypes)
                {
                    var entityName = affectedGroupType.FullName;
                    var checksum = this.CalculateChecksumForEntityType(context, affectedGroupType);
                    var digitoVerificadorVerticalDbSet = context.Set<VerticalCheckDigit>();
                    var vcd = digitoVerificadorVerticalDbSet.Find(entityName);
                    if (vcd == null)
                    {
                        vcd = digitoVerificadorVerticalDbSet.Create();
                        digitoVerificadorVerticalDbSet.Add(vcd);
                    }

                    vcd.Entity = entityName;
                    vcd.Checksum = checksum;
                }
                //Vuelvo a grabar los cambios de los dígitos verificadores verticales
                context.DefaultSaveChanges();
            }
        }
        private static Type ObtenerTipoDeEntidad(IHorizontalCheckDigit entidadConDigitoVerificador)
        {
            return System.Data.Entity.Core.Objects.ObjectContext.GetObjectType(entidadConDigitoVerificador.GetType());
        }
        private byte[] CalculateChecksumForEntityType(DbContext context, Type entityType)
        {
            var crcs = new List<byte[]>();
            foreach (IHorizontalCheckDigit entity in context.Set(entityType))
                crcs.Add(entity.DVH);

            var verticalChecksum = _calculadoraDigitosVerificadores.CalculateCheckDigitFromMultipleDigits(crcs);
            return verticalChecksum;
        }
    }
}
