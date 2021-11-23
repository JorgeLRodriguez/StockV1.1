using Services.DAL.Contracts;
using Services.DAL.Repositories.SqlServer.Adapters;
using Services.DAL.Repositories.Tools;
using Services.Domain.SecurityComposite;
using System.Collections.Generic;

namespace Services.DAL.Repositories.SqlServer
{
    class PatentRepository : IPatentRepository
    {
        #region Singleton
        private readonly static PatentRepository _instance = new PatentRepository();
        public static PatentRepository Current
        {
            get
            {
                return _instance;
            }
        }
        private PatentRepository()
        {
        }
        #endregion
        #region Statements
        private string SelectAllStatement
        {
            get => "SELECT [ID] ,[Name] ,[Permit] FROM [dbo].[Permits] WHERE Permit is not null";
        }
        #endregion
        public IList<Patent> GetAll()
        {
            var list = new List<Patent>();
            using (var dr = SqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
            {
                while (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);
                    Patent patent = new();
                    patent = PatentAdapter.Current.Adapt(values);
                    list.Add(patent);
                }
            }
            return list;
        }
    }
}