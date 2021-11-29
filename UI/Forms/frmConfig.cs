using Services.BLL.Contracts;
using Services.Domain.Language;
using Services.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmConfig : Form, ILanguageSubscriber
    {
        private readonly IUserTranslator _userTranslator;
        private readonly ApplicationServices _applicationServices;
        private static frmConfig _instance = null;
        public frmConfig(ApplicationServices applicationServices)
        {
            InitializeComponent();
            _applicationServices = applicationServices;
            _userTranslator = applicationServices.GetUserTranslator;
            this.EnlazarmeConServiciosDeTraduccion(_userTranslator);
        }
        public static frmConfig GetInstance(ApplicationServices applicationServices)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmConfig(applicationServices);
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

        }

        private void btnDbSettings_Click(object sender, EventArgs e)
        {
            _applicationServices.GetRestoreBackup.Restore();
        }
    }
}
