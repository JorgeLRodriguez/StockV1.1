using Domain;
using Services.BLL.Contracts;
using Services.Domain.Language;
using Services.Factory;
using System.Windows.Forms;
using UI.Print;

namespace UI.Forms.Print
{
    public partial class frmPrintVoucherLabel : Form, ILanguageSubscriber
    {
        IUserTranslator _userTranslator;
        public frmPrintVoucherLabel(Voucher voucher)
        {
            InitializeComponent();
            _userTranslator = ApplicationServices.GetInstance().GetUserTranslator;
            new VoucherLabelReportExtension(voucher, reportViewer1);
            this.LinkToTranslationServices(_userTranslator);
        }
        public void LanguageChanged(Language newLanguage)
        {
            this.Text = _userTranslator.Translate("ImpEtiq");
        }
    }
}
