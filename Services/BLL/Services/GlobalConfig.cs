using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BLL.Services
{
    public class GlobalConfig
    {
        #region "Singleton"

        private static readonly Lazy<GlobalConfig> DefaultInstance = new Lazy<GlobalConfig>(() => new GlobalConfig());

        public static GlobalConfig Instance
        {
            get { return DefaultInstance.Value; }
        }

        #endregion

        /// <summary>
        /// Devuelve o establece el path donde se guardará el log de errores.
        /// </summary>
        public string LogPath { get; set; }
    }
}