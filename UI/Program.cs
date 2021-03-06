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
            var applicationServices = ApplicationServices.GetInstance();
            Factory.GetInstance();
            applicationServices.GetGlobalConfig.LogPath = Settings.Default.LogPath;
            applicationServices.GetGlobalConfig.RestoreBackup = Settings.Default.RestoreBackup;
            var UserTranslator = applicationServices.GetUserTranslator;
            ConfigureDefaultLanguage(UserTranslator);
            if (!CheckSystemIntegrity(UserTranslator)) return;
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogIn());
        }
        public static void ConfigureDefaultLanguage(IUserTranslator userTranslator)
        {
            var DefaultISOCode = Settings.Default.Language;
            var DefaultLanguage =
                userTranslator.SupportedLanguages.Single(
                    i => i.ISOCode.Equals(DefaultISOCode, StringComparison.InvariantCultureIgnoreCase));
            userTranslator.PreferredLanguage = DefaultLanguage;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(DefaultISOCode);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(DefaultISOCode);
        }
        public static bool CheckSystemIntegrity(IUserTranslator userTranslator)
        {
            try
            {
                var systemIntegrity = new SystemIntegrity(Settings.Default.Corrupted);
                systemIntegrity.CheckIntegrity();
            }
            catch (SystemIntegrity.CorruptSystemException ex)
            {
                MessageBox.Show(userTranslator.Translate(ex.ConstantError), userTranslator.Translate("Stock"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
