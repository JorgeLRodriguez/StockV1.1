using Services.BLL.Contracts;
using Services.Factory;
using System.Reflection;
using System.Windows.Forms;

namespace UI.Forms.CRUD
{
    public partial class frmCRUD : Form
    {
        internal readonly IUserTranslator _userTranslator;
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
                dataGridViewColumn = new DataGridViewTextBoxColumn
                {
                    Visible = visible,
                    DataPropertyName = propertyInfo.Name,
                    HeaderText = _userTranslator.Translate(propertyInfo.Name)
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
