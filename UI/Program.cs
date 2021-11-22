using Services.BLL.Contracts;
using Services.BLL.Services;
using Services.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms;

namespace UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);





            ConfigurarLogPath();
            var ServiciosAplicacion = ApplicationServices.Current;
            var TraductorUsuario = ServiciosAplicacion.GetUserTranslator;
            ConfigureDefaultLanguage(TraductorUsuario);
            if (!ComprobarIntegridadDelSistema(TraductorUsuario))
                return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn(ServiciosAplicacion));
        }
        public static void ConfigureDefaultLanguage(IUserTranslator traductorUsuario)
        {
            var codigoIdiomaPorDefecto = "en-US";
            var idiomaPorDefecto =
                traductorUsuario.SupportedLanguages.Single(
                    i => i.ISOCode.Equals(codigoIdiomaPorDefecto, StringComparison.InvariantCultureIgnoreCase));
            traductorUsuario.PreferredLanguage = idiomaPorDefecto;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(codigoIdiomaPorDefecto);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(codigoIdiomaPorDefecto);
        }
        public static bool ComprobarIntegridadDelSistema(IUserTranslator traductorUsuario)
        {
            //try
            //{
            //    var integridadSistema = new IntegridadSistema(Settings.Default.Corrupto);
            //    integridadSistema.ComprobarIntegridad();
            //}
            //catch (IntegridadSistema.SistemaCorruptoException ex)
            //{
            //    MessageBox.Show(traductorUsuario.Traducir(ex.ConstanteError), traductorUsuario.Traducir(ConstantesTexto.Stock),
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            return true;
        }
        public static void ConfigurarLogPath()
        {
            //GlobalConfig.Instance.LogPath = Settings.Default.LogPath;
        }
    }
}
