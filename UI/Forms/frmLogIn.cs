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
    public partial class frmLogIn : Form , ILanguageSubscriber
    {
        private readonly IUserTranslator _traductorUsuario;
        private readonly ApplicationServices _serviciosAplicacion;
        public frmLogIn(ApplicationServices serviciosAplicacion)
        {
            InitializeComponent();
            _serviciosAplicacion = serviciosAplicacion;
            _traductorUsuario = serviciosAplicacion.GetUserTranslator;
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);
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
                //_serviciosAplicacion.Usuario.IniciarSesion(txtuser.Text, txtpsw.Text);
                //new MainMenufrm(_serviciosAplicacion).Show();
                Hide();
            }
            catch (Exception ex)
            {
                Clean();
                this.MostrarDialogoError(_traductorUsuario, ex.Message);
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
            usrlab.Text = _traductorUsuario.Translate("Usuario") + ":";
            pswlab.Text = _traductorUsuario.Translate("Contraseña") + ":";
            btnlogin.Text = _traductorUsuario.Translate("Acceder");
            Text = _traductorUsuario.Translate("Login");
        }
    }
}
