using Services.BLL.Contracts;
using Services.Domain.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms.CRUD
{
    public partial class frmDeposit : frmCRUD, ILanguageSubscriber
    {
        private static frmDeposit _instance = null;
        public frmDeposit()
        {
            InitializeComponent();
        }
        public static frmDeposit GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmDeposit();
            return _instance;
        }

        public void LanguageChanged(Language newLanguage)
        {
            throw new NotImplementedException();
        }
    }
}