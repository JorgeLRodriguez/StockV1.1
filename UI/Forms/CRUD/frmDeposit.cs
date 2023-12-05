using BLL.Contracts;
using BLL.Factory;
using Domain;
using Services.BLL.Contracts;
using Services.Domain.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms.CRUD
{
    public partial class frmDeposit : frmCRUD, ILanguageSubscriber
    {
        private readonly IDepositService _depositService;
        private readonly IClientService _clientService;
        private static frmDeposit _instance = null;
        private List<Deposit> _deposits;
        private List<Client> _clients;
        private Deposit _deposit;
        public frmDeposit()
        {
            InitializeComponent();
            this.LinkToTranslationServices(_userTranslator);
            _depositService = Factory.GetInstance().DepositService;
            _clientService = Factory.GetInstance().ClientService;
        }
        public static frmDeposit GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmDeposit();
            return _instance;
        }
        private List<Client> ListClients()
        {
            _clients = _clientService.GetAll();
            return _clients;
        }
        private List<Deposit> ListDeposits()
        {
            _deposits = _depositService.GetAll();
            return _deposits;
        }
        public void LanguageChanged(Language newLanguage)
        {
            btnDelete.Text = _userTranslator.Translate("Eliminar");
            btnSave.Text = _userTranslator.Translate("Guardar");
            btnNew.Text = _userTranslator.Translate("Agregar");
            labSearch.Text = _userTranslator.Translate("Buscar");
            labClient.Text = _userTranslator.Translate("Cliente");
            labName.Text = _userTranslator.Translate("Nombre");
            labAddress.Text = _userTranslator.Translate("Domicilio");
        }

        private void frmDeposit_Load(object sender, EventArgs e)
        {
            LoadDataGridViewHeaders(LoadDataGridHeaders(), true);
            LoadDataGridViewHeaders(LoadDataGridHeadersNoVisible(), false);
            ListClients();
            try
            {
                ListDeposits().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog(_userTranslator, ex.Message);
            }
        }
        protected override void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _deposit = _deposits.Where(x => x.ID == Guid.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[5].Value.ToString())).FirstOrDefault();
                LoadDepositToModify(_deposit);
            }
            catch { }
        }
        private object[] LoadDataGridView(Deposit entity)
        {
            object[] values = new object[11];

            values[0] = entity.Client.Description;
            values[1] = entity.DepositName;
            values[2] = entity.Address;

            values[3] = entity.Client_ID;
            values[4] = entity.Client;
            values[5] = entity.ID;
            values[6] = entity.CreatedBy;
            values[7] = entity.CreatedOn;
            values[8] = entity.ChangedBy;
            values[9] = entity.ChangedOn;
            values[10] = entity.DVH;

            return values;
        }
        private object[] LoadDataGridHeaders()
        {
            Type type = typeof(Deposit);
            var properties = type.GetProperties();
            object[] values = new object[3];

            values[0] = properties[1];
            values[1] = properties[2];
            values[2] = properties[3];

            return values;
        }
        private object[] LoadDataGridHeadersNoVisible()
        {
            Type type = typeof(Deposit);
            var properties = type.GetProperties();
            object[] values = new object[7];

            values[0] = properties[0];
            values[1] = properties[6];
            values[2] = properties[7];
            values[3] = properties[8];
            values[4] = properties[9];
            values[5] = properties[10];
            values[6] = properties[4];

            return values;
        }
        private void LoadDepositToModify(Deposit deposit)
        {
            cbxClient.DataSource = _clients;
            cbxClient.ValueMember = "ID";
            cbxClient.DisplayMember = "Description";
            cbxClient.SelectedItem = deposit.Client;
            txtName.Text = deposit.DepositName;
            txtAddress.Text = deposit.Address;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            cbxClient.DataSource = _clients;
            cbxClient.ValueMember = "ID";
            cbxClient.DisplayMember = "Description";
            _deposit = new();
        }
        private void Reset()
        {
            cbxClient.DataSource = null;
            cbxClient.Items.Clear();
            cbxClient.ResetText();
            cbxClient.Refresh();
            txtName.Clear();
            txtAddress.Clear();
            dgData.Rows.Clear();
            ListDeposits().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
            _deposit = null;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_deposit == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("BorrarRegistro"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                _depositService.Delete(_deposit.ID);
                this.ShowInformationDialog(_userTranslator, "ProcCorrecto");
            }
            catch
            {
                this.ShowErrorDialog(_userTranslator, "ErrorGenerico");
            }
            Reset();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_deposit == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("GuardarCambios"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            _deposit.Client = cbxClient.SelectedItem as Client;
            _deposit.DepositName = txtName.Text;
            _deposit.Address = txtAddress.Text;
            try
            {
                if (_deposit.ID == Guid.Empty) _depositService.Create(_deposit);
                else _depositService.Update(_deposit);
                this.ShowInformationDialog(_userTranslator, "ProcCorrecto");
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog(_userTranslator, "ErrorGenerico");
            }
            Reset();
        }
    }
}