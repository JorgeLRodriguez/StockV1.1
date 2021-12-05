using Services.BLL.Contracts;
using Services.Domain.Language;
using Services.Domain.SecurityComposite;
using Services.Factory;
using System;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmLogIn : Form , ILanguageSubscriber
    {
        private readonly IUserTranslator _userTranslator;
        public frmLogIn()
        {
            InitializeComponent();
            _userTranslator = ApplicationServices.GetInstance().GetUserTranslator;
            this.LinkToTranslationServices(_userTranslator);
        }
        private void Clean()
        {
            txtuser.Clear();
            txtpsw.Clear();
            txtuser.Focus();
            Cursor = Cursors.Arrow;
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                ApplicationServices.GetInstance().GetSesionService.Login(new User() { Name = txtuser.Text , Password = txtpsw.Text });
                new frmMain().Show();
                Hide();
            }
            catch (Exception ex)
            {
                Clean();
                this.ShowErrorDialog(_userTranslator, ex.Message);
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void LanguageChanged(Language newLanguage)
        {
            usrlab.Text = _userTranslator.Translate("Usuario") + ":";
            pswlab.Text = _userTranslator.Translate("Contraseña") + ":";
            btnlogin.Text = _userTranslator.Translate("Acceder");
            Text = _userTranslator.Translate("Login");
        }
    }
}
