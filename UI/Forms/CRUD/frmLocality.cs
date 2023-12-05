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
    public partial class frmLocality : frmCRUD, ILanguageSubscriber
    {
        private readonly IProvinceService _provinceService;
        private readonly ILocalityService _localityService;
        private static frmLocality _instance = null;
        private List<Province> _provinces;
        private List<Locality> _localities;
        private Locality _locality;
        public frmLocality()
        {
            InitializeComponent();
            this.LinkToTranslationServices(_userTranslator);
            _provinceService = Factory.GetInstance().ProvinceService;
            _localityService = Factory.GetInstance().LocalityService;
        }
        public static frmLocality GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmLocality();
            return _instance;
        }

        public void LanguageChanged(Language newLanguage)
        {
            btnDelete.Text = _userTranslator.Translate("Eliminar");
            btnSave.Text = _userTranslator.Translate("Guardar");
            btnNew.Text = _userTranslator.Translate("Agregar");
            labSearch.Text = _userTranslator.Translate("Buscar");
        }

        private void frmLocality_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataGridViewHeaders(LoadDataGridHeaders(), true);
                LoadDataGridViewHeaders(LoadDataGridHeadersNoVisible(), false);
                ListLocalities().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
                ListProvinces();
            }
            catch(Exception ex)
            {
                this.ShowErrorDialog(_userTranslator, "ErrorGenerico");
            }
        }
        private List<Province> ListProvinces()
        {
            _provinces = _provinceService.GetAll();
            return _provinces;
        }
        private List<Locality> ListLocalities()
        {
            _localities = _localityService.GetAll();
            return _localities;
        }
        private object[] LoadDataGridView(Locality entity)
        {
            object[] values = new object[9];

            values[0] = entity.ZipCode;
            values[1] = entity.LocalityName;
            values[2] = entity.Province.ProvinceName;
            values[3] = entity.Province_ID;
            values[4] = entity.ID;
            values[5] = entity.CreatedOn;
            values[6] = entity.CreatedBy;
            values[7] = entity.ChangedOn;
            values[8] = entity.ChangedBy;

            return values;
        }
        private object[] LoadDataGridHeaders()
        {
            Type type = typeof(Locality);
            var properties = type.GetProperties();
            object[] values = new object[3];

            values[0] = properties[0];
            values[1] = properties[1];
            values[2] = properties[3];

            return values;
        }
        private object[] LoadDataGridHeadersNoVisible()
        {
            Type type = typeof(Locality);
            var properties = type.GetProperties();
            object[] values = new object[6];

            values[0] = properties[2];
            values[1] = properties[4];
            values[2] = properties[5];
            values[3] = properties[6];
            values[4] = properties[7];
            values[5] = properties[8];

            return values;
        }
        protected override void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _locality = _localities.Where(x => x.ID == Guid.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value.ToString())).FirstOrDefault();
                //LoadArticleToModify(_article);
            }
            catch { }
        }
    }
}