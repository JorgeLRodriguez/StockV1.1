using BLL.Factory;
using Domain;
using Services.BLL.Contracts;
using Services.Domain.Language;
using Services.Factory;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Forms.Print;

namespace UI.Forms.Stock
{
    public partial class frmReception : Form, ILanguageSubscriber
    {
        #region FormSettings
        private readonly IUserTranslator _userTranslator;
        private readonly IFactory businessLayer;
        private readonly ApplicationServices _applicationServices;
        private static frmReception _instance = null;
        private frmReception(ApplicationServices applicationServices)
        {
            InitializeComponent();
            _applicationServices = applicationServices;
            _userTranslator = applicationServices.GetUserTranslator;
            businessLayer = Factory.Current;
            this.EnlazarmeConServiciosDeTraduccion(_userTranslator);
        }
        public static frmReception GetInstance(ApplicationServices applicationServices)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmReception(applicationServices);
            return _instance;
        }
        public frmReception() { }

        #endregion
        #region FormActions
        private void Recepcionfrm_Load(object sender, EventArgs e)
        {
            ListClients();
        }
        private void Clientcbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListArticles();
        }
        private void Addbtn_Click(object sender, EventArgs e)
        {
            invdetdataGrid.Rows.Add();
        }
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (invdetdataGrid.Rows.Count == 0) return;
            invdetdataGrid.Rows.Remove(invdetdataGrid.CurrentRow);
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            invdetdataGrid.EndEdit();
            try
            {
                Voucher voucher = new()
                {
                    ID = Guid.NewGuid(),
                    Client_ID = ((Client)clientcbx.SelectedValue).ID,
                    VoucherType = VoucherType.SIR,
                    Letter = lettertxt.Text,
                    Branch = int.Parse(subsidiarytxt.Text),
                    InvoiceClientNumber = (remitotxt.Text).ToString().Trim(),
                    VoucherDate = voucherPicker.Value
                };
                List<VoucherDetail> voucherDetails = new List<VoucherDetail>();
                if (invdetdataGrid.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in invdetdataGrid.Rows)
                    {
                        voucherDetails.Add(new VoucherDetail()
                        {
                            ID = Guid.NewGuid(),
                            Article_ID = String.IsNullOrEmpty(row.Cells[0].EditedFormattedValue.ToString()) ? Guid.Empty : Guid.Parse(row.Cells[0].Value.ToString()),
                            Quantity = String.IsNullOrEmpty(row.Cells[1].EditedFormattedValue.ToString()) ? 0 : int.Parse(row.Cells[1].EditedFormattedValue.ToString()),
                            Line = row.Index + 1,
                        });
                    }
                }
                voucher.VoucherDetails = voucherDetails;
                voucher = businessLayer.VoucherService.Create(voucher);
                this.MostrarDialogoInformacion(_userTranslator, "ComprobanteGenerado");
                new frmPrintVoucher(voucher, _applicationServices).ShowDialog();
                new frmPrintVoucherLabel(voucher, _applicationServices).ShowDialog();
                Reset();
            }
            catch (Exception ex)
            {
                this.MostrarDialogoError(_userTranslator, ex.Message);
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region PrivateFunctions
        private void ListArticles()
        {
            try
            {
                DataGridViewComboBoxColumn articlecbdg = invdetdataGrid.Columns[0] as DataGridViewComboBoxColumn;
                articlecbdg.DisplayMember = nameof(Article.Description);
                articlecbdg.ValueMember = nameof(Article.ID);
                articlecbdg.DataSource = businessLayer.ArticleService.GetByClient((Client)clientcbx.SelectedValue);
            }
            catch (Exception ex)
            {
                this.MostrarDialogoError(_userTranslator, ex.Message);
            }
        }
        private void ListClients()
        {
            clientcbx.DisplayMember = nameof(Client.Description);
            clientcbx.DataSource = businessLayer.ClientService.Get();
        }
        private void Reset()
        {
            ListClients();
            ListArticles();
            voucherPicker.ResetText();
            remitotxt.Clear();
            invdetdataGrid.Rows.Clear();
        }
        #endregion
        #region Language
        public void LanguageChanged(Language newLanguage)
        {
            invdetdataGrid.Columns[0].HeaderText = _userTranslator.Translate("Articulos").Substring(0, _userTranslator.Translate("Articulos").Length - 1);
            invdetdataGrid.Columns[1].HeaderText = _userTranslator.Translate("Cantidad");
            vouchertypelb.Text = _userTranslator.Translate("Tipo");
            letterlab.Text = _userTranslator.Translate("Letra");
            clientlab.Text = _userTranslator.Translate("Cliente");
            datelab.Text = _userTranslator.Translate("Fecha");
            invlab.Text = _userTranslator.Translate("Remito") + " #";
            addbtn.Text = _userTranslator.Translate("Agregar");
            deletebtn.Text = _userTranslator.Translate("Eliminar");
            savebtn.Text = _userTranslator.Translate("Guardar");
            typetxt.Text = VoucherType.SIR.ToString();
            this.Text = _userTranslator.Translate("Recepcion");
        }
        #endregion
    }
}