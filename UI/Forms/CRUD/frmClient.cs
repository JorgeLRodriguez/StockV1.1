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
        private readonly IArticleService _articleService;
        private readonly IClientService _clientService;
        private List<Article> _articles;
        private List<Client> _clients;
        private Article _article;
        public frmClient()
        {
            _clientService = Factory.GetInstance().ClientService;
            _articleService = Factory.GetInstance().ArticleService;
            InitializeComponent();
            this.LinkToTranslationServices(_userTranslator);
        }
        private void frmClient_Load(object sender, EventArgs e)
        {
            LoadDataGridViewHeaders(LoadDataGridHeaders(), true);
            LoadDataGridViewHeaders(LoadDataGridHeadersNoVisible(), false);
            ListArticles().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
            ListClients();
        }
        private List<Article> ListArticles()
        {
            _articles = _articleService.GetAll();
            return _articles;
        }
        private List<Client> ListClients()
        {
            _clients = _clientService.GetAll();
            return _clients;
        }
        private object[] LoadDataGridView(Article entity)
        {
            object[] values = new object[12];

            values[0] = entity.Client.Description;
            values[1] = entity.FsCode;
            values[2] = entity.Description;
            values[3] = entity.Barcode;
            values[4] = entity.OwnBarcode;

            values[5] = entity.Client_ID;
            values[6] = entity.Client;
            values[7] = entity.ID;
            values[8] = entity.CreatedBy;
            values[9] = entity.CreatedOn;
            values[10] = entity.ChangedBy;
            values[11] = entity.ChangedOn;

            return values;
        }
        private object[] LoadDataGridHeaders()
        {
            Type type = typeof(Article);
            var properties = type.GetProperties();
            object[] values = new object[5];

            values[0] = properties[1];
            values[1] = properties[2];
            values[2] = properties[3];
            values[3] = properties[4];
            values[4] = properties[5];

            return values;
        }
        private object[] LoadDataGridHeadersNoVisible()
        {
            Type type = typeof(Article);
            var properties = type.GetProperties();
            object[] values = new object[7];

            values[0] = properties[0];
            values[1] = properties[6];
            values[2] = properties[7];
            values[3] = properties[8];
            values[4] = properties[9];
            values[5] = properties[10];
            values[6] = properties[11];

            return values;
        }
        protected override void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt16(((DataGridView)sender).Rows[e.RowIndex]) > 0)
            _article = _articles.Where(x => x.ID == Guid.Parse(((DataGridView)sender).Rows[e.RowIndex].Cells[7].Value.ToString())).FirstOrDefault();
            LoadArticleToModify(_article);
        }
        public void LanguageChanged(Language newLanguage)
        {
            btnDelete.Text = _userTranslator.Translate("Eliminar");
            btnSave.Text = _userTranslator.Translate("Guardar");
            btnNew.Text = _userTranslator.Translate("Agregar");
            labSearch.Text = _userTranslator.Translate("Buscar");
            labClient.Text = _userTranslator.Translate("Cliente");
            labFsCode.Text = _userTranslator.Translate("Codigo") + "FS";
            labDescription.Text = _userTranslator.Translate("Descripcion");
            labOwnBarcode.Text = _userTranslator.Translate("CodigoPropio");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_article == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("GuardarCambios"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                _articleService.Delete(_article.ID);
                this.ShowInformationDialog(_userTranslator, "ProcCorrecto");
            }
            catch
            {
                this.ShowErrorDialog(_userTranslator, "ErrorGenerico");
            }
            Reset();
        }
        private void LoadArticleToModify(Article article)
        {
            cbxClient.DataSource = _clients;
            cbxClient.ValueMember = "ID";
            cbxClient.DisplayMember = "Description";
            cbxClient.SelectedItem = article.Client;
            txtFsCode.Text = article.FsCode;
            txtDescription.Text = article.Description;
            txtBarcode.Text = article.Barcode;
            cbxOwnBarcode.DataSource = null;
            cbxOwnBarcode.Items.Clear();
            cbxOwnBarcode.Text = "";
            cbxOwnBarcode.Items.Add(false);
            cbxOwnBarcode.Items.Add(true);
            cbxOwnBarcode.SelectedItem = article.OwnBarcode;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_article == null)
            {
                this.ShowWarningDialog(_userTranslator, "ObjetoSinEspecificar");
                return;
            }
            if (MessageBox.Show(_userTranslator.Translate("GuardarCambios"),"", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            _article.Client = cbxClient.SelectedItem as Client;
            _article.FsCode = txtFsCode.Text;
            _article.Description = txtDescription.Text;
            _article.Barcode = txtBarcode.Text;
            _article.OwnBarcode = Convert.ToBoolean(cbxOwnBarcode.SelectedItem);
            try
            {
                if (_article.ID == Guid.Empty) _articleService.Create(_article);
                else _articleService.Update(_article);
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
            cbxClient.DataSource = null;
            cbxClient.Items.Clear();
            cbxClient.ResetText();
            cbxClient.Refresh();
            cbxOwnBarcode.DataSource = null;
            cbxOwnBarcode.Items.Clear();
            cbxOwnBarcode.ResetText();
            cbxOwnBarcode.Refresh();
            txtFsCode.Clear();
            txtDescription.Clear();
            txtBarcode.Clear();
            dgData.Rows.Clear();
            ListArticles().ForEach(x => LoadDataGridViewData(LoadDataGridView(x)));
            _article = null;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            cbxClient.DataSource = _clients;
            cbxClient.ValueMember = "ID";
            cbxClient.DisplayMember = "Description";
            cbxOwnBarcode.Items.Add(false);
            cbxOwnBarcode.Items.Add(true);
            _article = new();
        }
    }
}