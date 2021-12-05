using System;

namespace Services.Services
{
    public class GlobalConfig
    {
        #region "Singleton"
        private static readonly Lazy<GlobalConfig> DefaultInstance = new(() => new GlobalConfig());
        public static GlobalConfig Instance
        {
            get { return DefaultInstance.Value; }
        }
        #endregion

        /// <summary>
        /// Devuelve o establece el path donde se guardará el log de errores.
        /// </summary>
        public string LogPath { get; set; }
        public string RestoreBackup { get; set; }
    }
}
