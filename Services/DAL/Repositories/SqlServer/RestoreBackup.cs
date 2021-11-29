using Services.DAL.Contracts;
using Services.DAL.Repositories.Tools;
using Services.Services;

namespace Services.DAL.Repositories.SqlServer
{
    class RestoreBackup : IRestoreBackup
    {
        #region Singleton
        private readonly static RestoreBackup _instance = new RestoreBackup();
        public static RestoreBackup Current
        {
            get
            {
                return _instance;
            }
        }
        private RestoreBackup()
        {
        }
        #endregion
        #region Statements
        private string BackupStatement
        {
            get => "BACKUP DATABASE [Stockk] TO  DISK = '"+GlobalConfig.Instance.RestoreBackup+"'";
        }
        private string RestoreStatement
        {
            get => "USE MASTER ALTER DATABASE [Stockk] Set SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE [Stockk] FROM  DISK = '" + GlobalConfig.Instance.RestoreBackup + "'; ALTER DATABASE [Stockk] SET Multi_USER";
        }
        #endregion
        public void Backup()
        {
            try
            {
                SqlHelper.ExecuteNonQuery(BackupStatement, System.Data.CommandType.Text);
            }
            catch
            {
                throw;
            }
        }
        public void Restore()
        {
            try
            {
                SqlHelper.ExecuteNonQuery(RestoreStatement, System.Data.CommandType.Text);
            }
            catch
            {
                throw;
            }
        }
    }
}
