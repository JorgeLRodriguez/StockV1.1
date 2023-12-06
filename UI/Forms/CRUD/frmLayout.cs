using BLL.Contracts;
using BLL.Factory;
using Domain;
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
        private readonly IPalletService _palletService;
        private readonly IDepositService _depositService;
        private readonly IAisleService _aisleService;
        private static frmLayout _instance = null;
        private List<Pallet> _pallets;
        private List<Deposit> _deposits;
        private List<Aisle> _aisles;
        private Pallet _pallet;
        public frmLayout()
        {
            InitializeComponent();
            this.LinkToTranslationServices(_userTranslator);
            _palletService = Factory.GetInstance().PalletService;
            _depositService = Factory.GetInstance().DepositService;
            _aisleService = Factory.GetInstance().AisleService;
        }
        private List<Pallet> ListPallets()
        {
            _pallets = _palletService.GetAll();
            return _pallets;
        }
        private List<Deposit> ListDeposits()
        {
            _deposits = _depositService.GetAll();
            return _deposits;
        }
        private List<Aisle> ListAisles()
        {
            _aisles = _aisleService.GetAll();
            return _aisles;
        }
        public static frmLayout GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmLayout();
            return _instance;
        }
        public void LanguageChanged(Language newLanguage)
        {
            btnDelete.Text = _userTranslator.Translate("Eliminar");
            btnSave.Text = _userTranslator.Translate("Guardar");
            btnNew.Text = _userTranslator.Translate("Agregar");
            labSearch.Text = _userTranslator.Translate("Buscar");
            labDeposit.Text = _userTranslator.Translate("Deposito");
            labAisle.Text = _userTranslator.Translate("Pasillo");
            labColumn.Text = _userTranslator.Translate("Columna");
            labRow.Text = _userTranslator.Translate("Fila");
            labDescription.Text = _userTranslator.Translate("Descripcion");
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            cbxDeposit.DataSource = _deposits;
            cbxDeposit.ValueMember = "ID";
            cbxDeposit.DisplayMember = "DepositName";
            cbxAisle.DataSource = _aisles;
            cbxAisle.ValueMember = "ID";
            cbxAisle.DisplayMember = "Description";
            txtColumn.Text = "";
            txtDescription.Text = "";
            txtRow.Text = "";
            _pallet = new();
        }
        private void Reset()
        {
            cbxDeposit.DataSource = null;
            cbxDeposit.Items.Clear();
            cbxDeposit.ResetText();
            cbxDeposit.Refresh();
            cbxAisle.DataSource = null;
            cbxAisle.Items.Clear();
            cbxAisle.ResetText();
            cbxAisle.Refresh();
            txtColumn.Clear();
            txtDescription.Clear();
            txtRow.Clear();
            dgData.Rows.Clear();
            ListPallets().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
            _pallet = null;
        }
        private void frmLayout_Load(object sender, EventArgs e)
        {
            ListDeposits();
            ListAisles();
            LoadDataGridViewHeaders(LoadDataGridHeaders(), true);
            LoadDataGridViewHeaders(LoadDataGridHeadersNoVisible(), false);
            try
            {
                ListPallets().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog(_userTranslator, ex.Message);
            }
        }
        private object[] LoadDataGridView(Pallet entity)
        {
            object[] values = new object[13];

            values[0] = entity.Deposit.DepositName;
            values[1] = entity.Aisle.Description;
            values[2] = entity.Col;
            values[3] = entity.Row;
            values[4] = entity.Description;

            values[5] = entity.Deposit_ID;
            values[6] = entity.Aisle_ID;
            values[7] = entity.DVH;
            values[8] = entity.ID;
            values[9] = entity.CreatedOn;
            values[10] = entity.CreatedBy;
            values[11] = entity.ChangedOn;
            values[12] = entity.ChangedBy;

            return values;
        }
        private object[] LoadDataGridHeaders()
        {
            Type type = typeof(Pallet);
            var properties = type.GetProperties();
            object[] values = new object[5];

            values[0] = properties[1];
            values[1] = properties[3];
            values[2] = properties[4];
            values[3] = properties[5];
            values[4] = properties[6];

            return values;
        }
        private object[] LoadDataGridHeadersNoVisible()
        {
            Type type = typeof(Pallet);
            var properties = type.GetProperties();
            object[] values = new object[8];

            values[0] = properties[0];
            values[1] = properties[2];
            values[2] = properties[8];
            values[3] = properties[9];
            values[4] = properties[10];
            values[5] = properties[11];
            values[6] = properties[12];
            values[7] = properties[13];

            return values;
        }
        protected override void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _pallet = _pallets.Where(x => x.ID == Guid.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[8].Value.ToString())).FirstOrDefault();
                LoadPalletToModify(_pallet);
            }
            catch { }
        }
        private void LoadPalletToModify(Pallet pallet)
        {
            cbxDeposit.DataSource = _deposits;
            cbxDeposit.ValueMember = "ID";
            cbxDeposit.DisplayMember = "DepositName";
            cbxDeposit.SelectedItem = _pallet.Deposit;
            cbxAisle.DataSource = _aisles;
            cbxAisle.ValueMember = "ID";
            cbxAisle.DisplayMember = "Description";
            cbxAisle.SelectedItem = _pallet.Aisle;
            txtColumn.Text = _pallet.Col.ToString();
            txtRow.Text = _pallet.Row.ToString();
            txtDescription.Text = _pallet.Description;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_pallet == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("BorrarRegistro"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                _palletService.Delete(_pallet.ID);
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
            if (_pallet == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("GuardarCambios"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            _pallet.Deposit = cbxDeposit.SelectedItem as Deposit;
            _pallet.Aisle = cbxAisle.SelectedItem as Aisle;
            _pallet.Col = Convert.ToInt32(txtColumn.Text);
            _pallet.Row = Convert.ToInt32(txtRow.Text);
            _pallet.Description = txtDescription.Text;     
            try
            {
                if (_pallet.ID == Guid.Empty) _palletService.Create(_pallet);
                else _palletService.Update(_pallet);
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