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
    public partial class frmProvince : frmCRUD, ILanguageSubscriber 
    {
        private readonly IProvinceService _provinceService;
        private static frmProvince _instance = null;
        private List<Province> _provinces;
        Province _province = null;
        public frmProvince()
        {
            InitializeComponent();
            this.LinkToTranslationServices(_userTranslator);
            _provinceService = Factory.GetInstance().ProvinceService;
        }
        public static frmProvince GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmProvince();
            return _instance;
        }

        public void LanguageChanged(Language newLanguage)
        {
            btnDelete.Text = _userTranslator.Translate("Eliminar");
            btnSave.Text = _userTranslator.Translate("Guardar");
            btnNew.Text = _userTranslator.Translate("Agregar");
            labSearch.Text = _userTranslator.Translate("Buscar");
            labProvinceName.Text = _userTranslator.Translate("Provincia");
        }
        private List<Province> ListProvinces()
        {
            _provinces = _provinceService.GetAll();
            return _provinces;
        }
        private void frmProvince_Load(object sender, System.EventArgs e)
        {
            LoadDataGridViewHeaders(LoadDataGridHeaders(), true);
            LoadDataGridViewHeaders(LoadDataGridHeadersNoVisible(), false);
            ListProvinces().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
        }
        private object[] LoadDataGridView(Province entity)
        {
            object[] values = new object[7];

            values[0] = entity.ProvinceName;
            values[1] = entity.Localities;
            values[2] = entity.ID;
            values[3] = entity.CreatedOn;
            values[4] = entity.CreatedBy;
            values[5] = entity.ChangedOn;
            values[6] = entity.ChangedBy;

            return values;
        }
        private object[] LoadDataGridHeaders()
        {
            Type type = typeof(Province);
            var properties = type.GetProperties();
            object[] values = new object[1];

            values[0] = properties[0];

            return values;
        }
        private object[] LoadDataGridHeadersNoVisible()
        {
            Type type = typeof(Province);
            var properties = type.GetProperties();
            object[] values = new object[6];

            values[0] = properties[1];
            values[1] = properties[2];
            values[2] = properties[3];
            values[3] = properties[4];
            values[4] = properties[5];
            values[5] = properties[6];

            return values;
        }
        protected override void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _province = _provinces.Where(x => x.ID == Guid.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString())).FirstOrDefault();
                LoadProvinceToModify(_province);
            }
            catch { }
        }
        private void LoadProvinceToModify(Province province)
        {
            txtProvinceName.Text = province.ProvinceName;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_province == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("GuardarCambios"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            _province.ProvinceName = txtProvinceName.Text;
            try
            {
                if (_province.ID == Guid.Empty) _provinceService.Create(_province);
                else _provinceService.Update(_province);
                this.ShowInformationDialog(_userTranslator, "ProcCorrecto");
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog(_userTranslator, "ErrorGenerico");
            }
            Reset();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_province == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("BorrarRegistro"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                _provinceService.Delete(_province.ID);
                this.ShowInformationDialog(_userTranslator, "ProcCorrecto");
            }
            catch
            {
                this.ShowErrorDialog(_userTranslator, "ErrorGenerico");
            }
            Reset();
        }
        private void Reset()
        {
            txtProvinceName.Clear();
            dgData.Rows.Clear();
            ListProvinces().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
            _province = null;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            _province = new();
        }
    }
}
