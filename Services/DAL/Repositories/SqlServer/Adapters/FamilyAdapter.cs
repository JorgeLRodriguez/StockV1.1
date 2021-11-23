using Services.DAL.Contracts;
using Services.Domain.SecurityComposite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Repositories.SqlServer.Adapters
{
    internal class FamilyAdapter : IEntityAdapter<Family>
    {
        #region Singleton
        private readonly static FamilyAdapter _instance = new FamilyAdapter();
        public static FamilyAdapter Current
        {
            get
            {
                return _instance;
            }
        }
        private FamilyAdapter()
        {
        }
        #endregion
        public Family Adapt(object[] values)
        {
            return new Family()
            {
                ID = Guid.Parse(values[(int)Columns.ID].ToString()),
                Name = values[(int)Columns.Name].ToString()
            };
        }
        private enum Columns
        {
            ID,
            Name
        }
    }
}