using FontAwesome.Sharp;
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
using UI.Forms.Stock;

namespace UI.Forms
{
    public partial class frmMain : Form, ILanguageSubscriber
    {
        private IconButton currentBtn;
        private readonly Panel leftBorderBtn;
        private readonly IUserTranslator _userTranslator;
        private readonly ApplicationServices _applicationServices;
        public frmMain(ApplicationServices applicationServices)
        {
            InitializeComponent();
            leftBorderBtn = new Panel { Size = new Size(7, 60) };
            panelLeft.Controls.Add(leftBorderBtn);
            _applicationServices = applicationServices;
            _userTranslator = applicationServices.GetUserTranslator;
            this.EnlazarmeConServiciosDeTraduccion(_userTranslator);
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                panelStock.Visible = false;
                panelABM.Visible = false;
                panelReportes.Visible = false;
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btnStock_Click(object sender, EventArgs e)
        {
            showSubMenu(panelStock);
            ActivateButton(sender, Color.FromArgb(5, 26, 14));
        }
        private void btnABM_Click(object sender, EventArgs e)
        {
            showSubMenu(panelABM);
            ActivateButton(sender, Color.FromArgb(5, 26, 14));
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReportes);
            ActivateButton(sender, Color.FromArgb(5, 26, 14));
        }
        private void btnconfig_Click(object sender, EventArgs e)
        {
            Form conffrm = frmConfig.GetInstance(_applicationServices);
            openChildFormInPanel(conffrm);
            ActivateButton(sender, Color.FromArgb(5, 26, 14));
        }
        private void openChildFormInPanel(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(8, 204, 41);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                labtitle.Text = currentBtn.Text;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(5, 26, 14);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumSpringGreen;
        }
        private void homepic_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void btnrecepcion_Click(object sender, EventArgs e)
        {
            Form recfrm = frmReception.GetInstance(_applicationServices);
            openChildFormInPanel(recfrm);
        }
        private void btnscaneo_Click(object sender, EventArgs e)
        {
            Form scanfrm = frmScan.GetInstance(_applicationServices);
            openChildFormInPanel(scanfrm);
        }
        private void btnpicking_Click(object sender, EventArgs e)
        {
            Form pickfrm = frmPicking.GetInstance(_applicationServices);
            openChildFormInPanel(pickfrm);
        }
        private void btntransf_Click(object sender, EventArgs e)
        {
            //Form tranfrm = Transferenciafrm.GetInstance(_applicationServices);
            //openChildFormInPanel(tranfrm);
        }
        private void btnajuste_Click(object sender, EventArgs e)
        {
            //Form ajfrm = AjusteInvfrm.GetInstance(_applicationServices);
            //openChildFormInPanel(ajfrm);
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            //Form impfrm = Importarfrm.GetInstance(_applicationServices);
            //openChildFormInPanel(impfrm);
        }
        private void btnArticulos_Click(object sender, EventArgs e)
        {
            //Form artfrm = Articfrm.getInstance();
            //openChildFormInPanel(artfrm);
        }
        private void btnPxE_Click(object sender, EventArgs e)
        {
            //Form pxefrm = PxEfrm.getInstance();
            //openChildFormInPanel(pxefrm);
        }
        private void btnLayout_Click(object sender, EventArgs e)
        {
            //Form layfrm = Layoutfrm.getInstance();
            //openChildFormInPanel(layfrm);
        }
        private void btnEtiq_Click(object sender, EventArgs e)
        {
            //Form etiqfrm = Etiquetasfrm.getInstance();
            //openChildFormInPanel(etiqfrm);
        }
        private void btndeposito_Click(object sender, EventArgs e)
        {
            //Form depofrm = Depositofrm.getInstance();
            //openChildFormInPanel(depofrm);
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {
            //Form invfrm = Inventariofrm.getInstance();
            //openChildFormInPanel(invfrm);
        }
        private void btnMovim_Click(object sender, EventArgs e)
        {
            //Form movimfrm = Movimientosfrm.getInstance();
            //openChildFormInPanel(movimfrm);
        }
        private void btnHxI_Click(object sender, EventArgs e)
        {
            //Form hxifrm = HxEfrm.getInstance();
            //openChildFormInPanel(hxifrm);
        }
        private void btnIxC_Click(object sender, EventArgs e)
        {
            //Form ixcfrm = IxCfrm.getInstance();
            //openChildFormInPanel(ixcfrm);
        }
        private void btnListStock_Click(object sender, EventArgs e)
        {
            //Form liststfrm = ListadoStockfrm.getInstance();
            //openChildFormInPanel(liststfrm);
        }
        private void MainMenufrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _applicationServices.GetSesionService.Logout();
            Application.Exit();
        }

        private void AuthorizationControl()
        {
            btnrecepcion.Visible = _applicationServices.GetServicesUser.IsInRole(Services.Domain.SecurityComposite.PermitType.Reception);
            btnscaneo.Visible = _applicationServices.GetServicesUser.IsInRole(Services.Domain.SecurityComposite.PermitType.Scan);
        }


        public void LanguageChanged(Language newLanguage)
        {
            labtitle.Text = _userTranslator.Translate("Inicio");
            btnrecepcion.Text = _userTranslator.Translate("Recepcion");
            btnscaneo.Text = _userTranslator.Translate("Scaneo");
            btnpicking.Text = _userTranslator.Translate("Picking");
            btntransf.Text = _userTranslator.Translate("Transferencia");
            btnajuste.Text = _userTranslator.Translate("Ajuste");
            btnImportar.Text = _userTranslator.Translate("Importar");
            btnABM.Text = _userTranslator.Translate("Administrar");
            btnArticulos.Text = _userTranslator.Translate("Articulos");
            btnPxE.Text = _userTranslator.Translate("PxE");
            btnLayout.Text = _userTranslator.Translate("Layout");
            btnEtiq.Text = _userTranslator.Translate("Etiq");
            btnReportes.Text = _userTranslator.Translate("Reportes");
            btndeposito.Text = _userTranslator.Translate("Deposito");
            btnInventario.Text = _userTranslator.Translate("Inventario");
            btnMovim.Text = _userTranslator.Translate("Movimientos");
            btnHxI.Text = _userTranslator.Translate("HxI");
            btnIxC.Text = _userTranslator.Translate("IxC");
            btnListStock.Text = _userTranslator.Translate("ListStock");
            btnconfig.Text = _userTranslator.Translate("Config");
            Text = _userTranslator.Translate("Stock");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            AuthorizationControl();
        }
    }
}
