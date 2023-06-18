using BLL.Contracts;
using BLL.Factory;
using Domain;
using Services.BLL.Contracts;
using Services.Domain.Language;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Forms.CRUD
{
    public partial class frmClient : frmCRUD, ILanguageSubscriber
    {
        private readonly IClientService _clientService;
        private List<Client> _clients;
        private Client _client;
        public frmClient()
        {
            _clientService = Factory.GetInstance().ClientService;
            InitializeComponent();
            this.LinkToTranslationServices(_userTranslator);
        }
        private void frmClient_Load(object sender, EventArgs e)
        {
            LoadDataGridViewHeaders(LoadDataGridHeaders(), true);
            LoadDataGridViewHeaders(LoadDataGridHeadersNoVisible(), false);
            ListClients().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
        }
        private List<Client> ListClients()
        {
            _clients = _clientService.GetAll();
            return _clients;
        }
        private object[] LoadDataGridView(Client entity)
        {
            object[] values = new object[10];

            values[0] = entity.Cuit;
            values[1] = entity.Description;
            values[2] = entity.Enabled;

            values[3] = entity.Articles;
            values[4] = entity.Vouchers;
            values[5] = entity.ID;
            values[6] = entity.CreatedOn;
            values[7] = entity.CreatedBy;
            values[8] = entity.ChangedOn;
            values[9] = entity.ChangedBy;

            return values;
        }
        private object[] LoadDataGridHeaders()
        {
            Type type = typeof(Client);
            var properties = type.GetProperties();
            object[] values = new object[3];

            values[0] = properties[0];
            values[1] = properties[1];
            values[2] = properties[2];

            return values;
        }
        private object[] LoadDataGridHeadersNoVisible()
        {
            Type type = typeof(Client);
            var properties = type.GetProperties();
            object[] values = new object[7];

            values[0] = properties[3];
            values[1] = properties[4];
            values[2] = properties[5];
            values[3] = properties[6];
            values[4] = properties[7];
            values[5] = properties[8];
            values[6] = properties[9];

            return values;
        }
        protected override void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _client = _clients.Where(x => x.ID == Guid.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[5].Value.ToString())).FirstOrDefault();
                LoadClientToModify(_client);
            }
            catch { }
        }
        public void LanguageChanged(Language newLanguage)
        {
            btnDelete.Text = _userTranslator.Translate("Eliminar");
            btnSave.Text = _userTranslator.Translate("Guardar");
            btnNew.Text = _userTranslator.Translate("Agregar");
            labSearch.Text = _userTranslator.Translate("Buscar");
            labActivo.Text = _userTranslator.Translate("Cliente");
            labNombre.Text = _userTranslator.Translate("Descripcion");

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_client == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("BorrarRegistro"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                _clientService.Delete(_client.ID);
                this.ShowInformationDialog(_userTranslator, "ProcCorrecto");
            }
            catch
            {
                this.ShowErrorDialog(_userTranslator, "ErrorGenerico");
            }
            Reset();
        }
        private void LoadClientToModify(Client client)
        {
            txtName.Text = client.Description;
            txtCUIT.Text = client.Cuit;
            cbxEnabled.DataSource = null;
            cbxEnabled.Items.Clear();
            cbxEnabled.Text = "";
            cbxEnabled.Items.Add(false);
            cbxEnabled.Items.Add(true);
            cbxEnabled.SelectedItem = client.Enabled;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_client == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("GuardarCambios"),"", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            _client.Description = txtName.Text;
            _client.Cuit = txtCUIT.Text;
            _client.Enabled = Convert.ToBoolean(cbxEnabled.SelectedItem);
            try
            {
                if (_client.ID == Guid.Empty) _clientService.Create(_client);
                else _clientService.Update(_client);
                this.ShowInformationDialog(_userTranslator, "ProcCorrecto");
            }
            catch(Exception ex)
            {
                this.ShowErrorDialog(_userTranslator, "ErrorGenerico");
            }
            Reset();
        }
        private void Reset()
        {
            txtName.Clear();
            txtCUIT.Clear();
            dgData.Rows.Clear();
            ListClients().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
            _client = null;
            cbxEnabled.DataSource = null;
            cbxEnabled.Items.Clear();
            cbxEnabled.ResetText();
            cbxEnabled.Refresh();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            cbxEnabled.Items.Add(false);
            cbxEnabled.Items.Add(true);
            _client = new();
        }
    }
}