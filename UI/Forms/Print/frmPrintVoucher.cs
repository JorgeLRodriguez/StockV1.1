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
        private Voucher _voucher;
        private readonly IUserTranslator _userTranslator;
        public frmPrintVoucher(Voucher voucher)
        {
            InitializeComponent();
            _userTranslator = ApplicationServices.GetInstance().GetUserTranslator;
            this.LinkToTranslationServices(_userTranslator);
            _voucher = voucher;
        }
        private void printcompfrm_Load(object sender, EventArgs e)
        {
            VoucherReportExtension.Current.LoadReport(_voucher, reportViewer1);
            copiacb.Items.Add(_userTranslator.Translate("Original"));
            copiacb.Items.Add(_userTranslator.Translate("Duplicado"));
            copiacb.Items.Add(_userTranslator.Translate("Triplicado"));
        }
        private void copiacb_SelectedIndexChanged(object sender, EventArgs e)
        {
            VoucherReportExtension.Current.CopyChanged(copiacb.SelectedItem.ToString(),reportViewer1);
        }
        public void LanguageChanged(Language newLanguage)
        {
            Text = _userTranslator.Translate("ImpComprobante");
            copialab.Text = _userTranslator.Translate("SeleCopia") + ":";
        }
    }
}
