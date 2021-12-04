using Domain;
using Services.BLL.Contracts;
using Services.Domain.Language;
using Services.Factory;
using System;
using System.Windows.Forms;
using UI.Print;

namespace UI.Forms.Print
{
    public partial class frmPrintVoucher : Form, ILanguageSubscriber
    {
        private readonly VoucherReportExtension _voucherReportExtesion;
        private readonly IUserTranslator _userTranslator;
        public frmPrintVoucher(Voucher voucher, ApplicationServices applicationServices)
        {
            Cursor = Cursors.WaitCursor;
            InitializeComponent();
            _userTranslator = applicationServices.GetUserTranslator;
            _voucherReportExtesion = new VoucherReportExtension(voucher,reportViewer1);
            this.EnlazarmeConServiciosDeTraduccion(_userTranslator);
            Cursor = Cursors.Default;
        }

        private void printcompfrm_Load(object sender, EventArgs e)
        {
            copiacb.Items.Add(_userTranslator.Translate("Original"));
            copiacb.Items.Add(_userTranslator.Translate("Duplicado"));
            copiacb.Items.Add(_userTranslator.Translate("Triplicado"));
        }
        private void copiacb_SelectedIndexChanged(object sender, EventArgs e)
        {
            _voucherReportExtesion.CopyChanged(copiacb.SelectedItem.ToString());
        }
        public void LanguageChanged(Language newLanguage)
        {
            Text = _userTranslator.Translate("ImpComprobante");
            copialab.Text = _userTranslator.Translate("SeleCopia") + ":";
        }
    }
}
