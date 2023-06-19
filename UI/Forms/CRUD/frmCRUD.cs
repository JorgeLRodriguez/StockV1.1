using Services.BLL.Contracts;
using Services.Factory;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace UI.Forms.CRUD
{
    public partial class frmCRUD : Form
    {
        internal readonly IUserTranslator _userTranslator;
        private static frmCRUD _instance = null;
        public frmCRUD()
        {
            InitializeComponent();
            _userTranslator = ApplicationServices.GetInstance().GetUserTranslator;
        }
        internal void LoadDataGridViewHeaders(object[] headers, bool visible)
        {
            dgData.AutoGenerateColumns = false;

            DataGridViewColumn dataGridViewColumn = default;

            foreach (PropertyInfo propertyInfo in headers)
            {
                string headerText = null;

                try
                {
                    headerText = _userTranslator.Translate(((System.ComponentModel.DataAnnotations.DisplayAttribute)(propertyInfo.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), true)).Single()).Name);
                }
                catch
                {
                    headerText = _userTranslator.Translate(propertyInfo.Name);
                }

                dataGridViewColumn = new DataGridViewTextBoxColumn
                {
                    Visible = visible,
                    DataPropertyName = propertyInfo.Name,
                    HeaderText = headerText
                };
                dgData.Columns.Add(dataGridViewColumn);
            }
        }
        internal void LoadDataGridViewData (object[] row) 
        {
            dgData.Rows.Add(row);
        }
        protected virtual void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        protected virtual void txtSearch_TextChanged(object sender, System.EventArgs e)
        {

        }
        private void btnclose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
