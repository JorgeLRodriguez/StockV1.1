using Services.BLL.Contracts;
using Services.Domain.Language;
using Services.Factory;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmConfig : Form, ILanguageSubscriber
    {
        private readonly IUserTranslator _userTranslator;
        private static frmConfig _instance = null;
        public frmConfig()
        {
            InitializeComponent();
            _userTranslator = ApplicationServices.GetInstance().GetUserTranslator;
            this.LinkToTranslationServices(_userTranslator);
        }
        public static frmConfig GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmConfig();
            return _instance;
        }
        public void LanguageChanged(Language newLanguage)
        {
            btnLanguage.Text = _userTranslator.Translate("Idioma");
            btnManUser.Text = _userTranslator.Translate("AdminUsuario");
            btnLog.Text = _userTranslator.Translate("Bitacora");
            btnRol.Text = _userTranslator.Translate("AdminRol");
        }
        private void btnLanguage_Click(object sender, EventArgs e)
        {
            var codigoIdiomaPorDefecto = "es-AR";
            var idiomaPorDefecto =
                _userTranslator.SupportedLanguages.Single(
                    i => i.ISOCode.Equals(codigoIdiomaPorDefecto, StringComparison.InvariantCultureIgnoreCase));
            _userTranslator.PreferredLanguage = idiomaPorDefecto;
        }
        private void btnDbSettings_Click(object sender, EventArgs e)
        {
            ApplicationServices.GetInstance().GetRestoreBackup.Restore();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
