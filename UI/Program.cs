using BLL;
using BLL.Factory;
using Services.BLL.Contracts;
using Services.Factory;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
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
            var ServiciosAplicacion = ApplicationServices.GetInstance();
            Factory BussinessLayer = Factory.Current;
            ServiciosAplicacion.GetGlobalConfig.LogPath = Settings.Default.LogPath;
            ServiciosAplicacion.GetGlobalConfig.RestoreBackup = Settings.Default.RestoreBackup;
            var TraductorUsuario = ServiciosAplicacion.GetUserTranslator;
            ConfigureDefaultLanguage(TraductorUsuario);
            if (!ComprobarIntegridadDelSistema(TraductorUsuario)) return;
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogIn(ServiciosAplicacion));
        }
        public static void ConfigureDefaultLanguage(IUserTranslator traductorUsuario)
        {
            var codigoIdiomaPorDefecto = Settings.Default.Language;
            var idiomaPorDefecto =
                traductorUsuario.SupportedLanguages.Single(
                    i => i.ISOCode.Equals(codigoIdiomaPorDefecto, StringComparison.InvariantCultureIgnoreCase));
            traductorUsuario.PreferredLanguage = idiomaPorDefecto;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(codigoIdiomaPorDefecto);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(codigoIdiomaPorDefecto);
        }
        public static bool ComprobarIntegridadDelSistema(IUserTranslator traductorUsuario)
        {
            try
            {
                var integridadSistema = new SystemIntegrity(Settings.Default.Corrupted);
                integridadSistema.ComprobarIntegridad();
            }
            catch (SystemIntegrity.SistemaCorruptoException ex)
            {
                MessageBox.Show(traductorUsuario.Translate(ex.ConstanteError), traductorUsuario.Translate("Stock"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
