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
    public partial class frmAisle : frmCRUD, ILanguageSubscriber
    {
        private readonly IAisleService _aisleService;
        private static frmAisle _instance = null;
        private List<Aisle> _aisles;
        private Aisle _aisle;
        public frmAisle()
        {
            _aisleService = Factory.GetInstance().AisleService;
            InitializeComponent();
            this.LinkToTranslationServices(_userTranslator);
        }
        public static frmAisle GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmAisle();
            return _instance;
        }
        private void frmAisle_Load(object sender, EventArgs e)
        {
            LoadDataGridViewHeaders(LoadDataGridHeaders(), true);
            LoadDataGridViewHeaders(LoadDataGridHeadersNoVisible(), false);
            ListAisle();
            if(!(_aisles == null)) _aisles.ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
        }
        private List<Aisle> ListAisle()
        {
            try
            {
                _aisles = _aisleService.GetAll();
            }
            catch(Exception ex)
            {
                this.ShowErrorDialog(_userTranslator, ex.Message);
            }
            return _aisles;
        }
        private object[] LoadDataGridView(Aisle entity)
        {
            object[] values = new object[7];

            values[0] = entity.Description;        

            values[1] = entity.DVH;
            values[2] = entity.ID;
            values[3] = entity.CreatedBy;
            values[4] = entity.CreatedOn;
            values[5] = entity.ChangedBy;
            values[6] = entity.ChangedOn;

            return values;
        }
        private object[] LoadDataGridHeaders()
        {
            Type type = typeof(Aisle);
            var properties = type.GetProperties();
            object[] values = new object[1];

            values[0] = properties[0];

            return values;
        }
        private object[] LoadDataGridHeadersNoVisible()
        {
            Type type = typeof(Aisle);
            var properties = type.GetProperties();
            object[] values = new object[7];

            values[0] = properties[1];
            values[1] = properties[2];
            values[2] = properties[3];
            values[3] = properties[4];
            values[4] = properties[5];
            values[5] = properties[6];
            values[6] = properties[7];

            return values;
        }
        protected override void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _aisle = _aisles.Where(x => x.ID == Guid.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString())).FirstOrDefault();
            LoadAisleToModify(_aisle);
        }
        public void LanguageChanged(Language newLanguage)
        {
            btnDelete.Text = _userTranslator.Translate("Eliminar");
            btnSave.Text = _userTranslator.Translate("Guardar");
            btnNew.Text = _userTranslator.Translate("Agregar");
            labSearch.Text = _userTranslator.Translate("Buscar");
            labDescription.Text = _userTranslator.Translate("Descripcion");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_aisle == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("GuardarCambios"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                _aisleService.Delete(_aisle.ID);
                this.ShowInformationDialog(_userTranslator, "ProcCorrecto");
            }
            catch
            {
                this.ShowErrorDialog(_userTranslator, "ErrorGenerico");
            }
            Reset();
        }
        private void LoadAisleToModify(Aisle aisle)
        {
            txtDescription.Text = aisle.Description;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_aisle == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("GuardarCambios"),"", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            _aisle.Description = txtDescription.Text;
            try
            {
                if (_aisle.ID == Guid.Empty) _aisleService.Create(_aisle);
                else _aisleService.Update(_aisle);
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
            txtDescription.Clear();
            dgData.Rows.Clear();
            _aisles = null;
            _aisle = null;
            ListAisle();
            if (!(_aisles == null)) _aisles.ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            _aisle = new();
        }
    }
}