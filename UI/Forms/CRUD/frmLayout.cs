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
    public partial class frmLayout : frmCRUD, ILanguageSubscriber
    {
        private static frmLayout _instance = null;
        public frmLayout()
        {
            InitializeComponent();
        }
        public static frmLayout GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmLayout();
            return _instance;
        }

        public void LanguageChanged(Language newLanguage)
        {
            throw new NotImplementedException();
        }
    }
}
