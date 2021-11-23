using Services.DAL.Contracts;
using Services.Domain.SecurityComposite;
using System;

namespace Services.DAL.Repositories.SqlServer.Adapters
{
    internal class PatentAdapter : IEntityAdapter <Patent>
    {
        #region Singleton
        private readonly static PatentAdapter _instance = new PatentAdapter();
        public static PatentAdapter Current
        {
            get
            {
                return _instance;
            }
        }
        private PatentAdapter()
        {
        }
        #endregion
        public Patent Adapt(object[] values)
        {
            return new Patent()
            {
                ID = Guid.Parse(values[(int)Columns.ID].ToString()),
                Name = values[(int)Columns.Name].ToString(),
                Permit = (PermitType)Enum.Parse(typeof(PermitType), values[(int)Columns.Permit].ToString())
            };
        }
        private enum Columns
        {
            ID,
            Name,
            Permit
        }
    }
}