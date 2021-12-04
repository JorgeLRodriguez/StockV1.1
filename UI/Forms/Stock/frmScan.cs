using BLL.Factory;
using Domain;
using Services.BLL.Contracts;
using Services.Domain.Language;
using Services.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UI.Forms.Print;

namespace UI.Forms.Stock
{
    public partial class frmScan : Form, ILanguageSubscriber
    {
        #region FormSettings
        private readonly IUserTranslator _userTranslator;
        private readonly IFactory businessLayer;
        private readonly ApplicationServices _applicationServices;
        private List<RejectionType> _rejectionType;
        private static frmScan _instance = null;
        private frmScan(ApplicationServices applicationServices)
        {
            InitializeComponent();
            _applicationServices = applicationServices;
            _userTranslator = applicationServices.GetUserTranslator;
            businessLayer = Factory.Current;
            this.EnlazarmeConServiciosDeTraduccion(_userTranslator);
        }
        public static frmScan GetInstance(ApplicationServices applicationServices)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmScan(applicationServices);
            return _instance;
        }
        public frmScan() { }

        #endregion
        #region FormActions
        private void receiptcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            maindg.Rows.Clear();
            scandg.Rows.Clear();
            receiptdg.Rows.Clear();
            var voucher = (Voucher)receiptcb.SelectedItem;
            voucher.VoucherDetails.ToList().ForEach(x => LoadMainDg(x));
            if (voucher.VoucherType.Equals(VoucherType.SPK))
            {
                expedbtn.Visible = true;
            }
            else
            {
                expedbtn.Visible = false;
            }
        }
        private void scandg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string tipoDesc = ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString();
                string code = ((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString();
                string barraDesc = ((Voucher)receiptcb.SelectedItem).VoucherDetails
                    .Where(vd => vd.Article.FsCode == code)
                    .Select(cd => cd.Article.BarcodeDescription)
                    .FirstOrDefault();
                scandg.Rows.Remove(scandg.Rows[e.RowIndex]);
                UpdateMaindg(barraDesc);
                UpdateReceiptdg(code, tipoDesc);
            }
        }
        private void codetxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!CompararScanConCodigo(codetxt.Text)) codetxt.Text = "";
                codetxt.SelectAll();
            }
        }
        private void dcbtn_Click(object sender, EventArgs e)
        {
            if (!CountScans()) { this.MostrarDialogoAdvertencia(_userTranslator, "AtItemSinScan"); return; }
            try
            {
                var comp = (Voucher)receiptcb.SelectedItem;
                Voucher C = new()
                {
                    ID = Guid.NewGuid(),
                    Client_ID = comp.Client_ID,
                    VoucherType = VoucherType.SIS,
                    Letter = comp.Letter,
                    Branch = comp.Branch,
                    InvoiceClientNumber = comp.InvoiceClientNumber,
                    Closure = "D",
                    VoucherDate = DateTime.Now,
                };
                List<VoucherDetail> VD = new List<VoucherDetail>();
                if (maindg.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in receiptdg.Rows)
                    {
                        VD.Add(new VoucherDetail()
                        {
                            ID = Guid.NewGuid(),
                            Article_ID = Guid.Parse(row.Cells[3].Value.ToString()),
                            Line = row.Index + 1,
                            Quantity = Convert.ToInt32(row.Cells[2].Value),
                            RejectionType_ID = Convert.ToInt32(row.Cells[1].Value),
                            RejectionType = _rejectionType.Where(x => x.ID.Equals(row.Cells[1].Value)).FirstOrDefault()
                        });
                    }
                }
                C.VoucherDetails = VD;
                C = businessLayer.VoucherService.Create(C);
                comp.Closure = "D";
                businessLayer.VoucherService.Update(comp);
                this.MostrarDialogoInformacion(_userTranslator, "ComprobanteGenerado");
                new frmPrintVoucher(C, _applicationServices).ShowDialog();
                Init();
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
        private void Scaneofrm_Load(object sender, EventArgs e)
        {
            Init();
        }
        #endregion
        #region PrivateFunctions
        private void LoadRejectionTypes()
        {
            _rejectionType = businessLayer.VoucherService.GetRejectionTypes().ToList();
            reasoncb.DisplayMember = "Description";
            reasoncb.ValueMember = "ID";
            reasoncb.DataSource = _rejectionType;
            reasoncb.SelectedValue = 4;
        }
        private void LoadVoucher()
        {
            try
            {
                receiptcb.DisplayMember = "Description";
                receiptcb.ValueMember = "ID";
                receiptcb.DataSource = businessLayer.VoucherService.GetScanVoucher().ToList();
            }
            catch (Exception ex)
            {
                this.MostrarDialogoError(_userTranslator, ex.Message);
            }
        }
        private bool CompararScanConCodigo(string _barcode)
        {
            foreach (var detail in ((Voucher)receiptcb.SelectedItem).VoucherDetails.ToList())
            {
                if (detail.Article.Barcode.Equals(_barcode))
                {
                    foreach (DataGridViewRow row in maindg.Rows)
                    {
                        if (row.Cells[0].Value.Equals(detail.Line)
                            && row.Cells[1].Value.Equals(detail.Article.BarcodeDescription)
                            && !row.Cells[2].Value.Equals(row.Cells[3].Value))
                        {
                            LoadScan(row.Cells[3], detail);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void LoadMainDg(VoucherDetail voucherDetail)
        {
            maindg.Rows.Add(
                voucherDetail.Line,
                voucherDetail.Article.BarcodeDescription,
                voucherDetail.Quantity,
                0
                );
        }
        private void LoadScan(DataGridViewCell cell, VoucherDetail voucherDetail)
        {
            int cant = 0;
            if (completecb.Checked)
            {
                cant = voucherDetail.Quantity - Convert.ToInt32(cell.Value);
                cell.Value = voucherDetail.Quantity;
            }
            else
            {
                cant = 1;
                cell.Value = Convert.ToInt32(cell.Value) + 1;
            }
            LoadScandg(voucherDetail, cant);
            LoadComp(voucherDetail, cant);
        }
        private void LoadScandg(VoucherDetail voucherDetail, int quantity)
        {
            for (int i = 1; i <= quantity; i++)
            {
                scandg.Rows.Add
                (
                scandg.RowCount + 1,
                voucherDetail.Article.FsCode,
                ((RejectionType)reasoncb.SelectedItem).Description,
                _userTranslator.Translate("Suprimir")
                );
            }
        }
        private void LoadComp(VoucherDetail voucherDetail, int quantity)
        {
            foreach (DataGridViewRow row in receiptdg.Rows)
            {
                if (row.Cells[0].Value.Equals(voucherDetail.Article.FsCode)
                    && row.Cells[1].Value.Equals(((RejectionType)reasoncb.SelectedItem).ID))
                {
                    row.Cells[2].Value = Convert.ToInt32(row.Cells[2].Value) + quantity;
                    return;
                }
            }
            receiptdg.Rows.Add
            (
            voucherDetail.Article.FsCode,
            ((RejectionType)reasoncb.SelectedItem).ID,
            quantity,
            voucherDetail.Article_ID
            );
        }
        private void UpdateMaindg(string barraDesc)
        {
            foreach (DataGridViewRow row in maindg.Rows)
            {
                if (row.Cells[1].Value.Equals(barraDesc)
                    && Convert.ToInt32(row.Cells[3].Value) > 0)
                {
                    row.Cells[3].Value = Convert.ToInt32(row.Cells[3].Value) - 1;
                    return;
                }
            }
        }
        private void UpdateReceiptdg(string codigo, string tipoDesc)
        {
            foreach (DataGridViewRow row in receiptdg.Rows)
            {
                if (row.Cells[0].Value.Equals(codigo)
                    && row.Cells[1].Value.Equals
                    (_rejectionType
                    .Where(t => t.Description.Equals(tipoDesc))
                    .Select(t => t.ID).FirstOrDefault()))
                {
                    row.Cells[2].Value = Convert.ToInt32(row.Cells[2].Value) - 1;
                    if (row.Cells[2].Value.Equals(0)) receiptdg.Rows.Remove(row);
                    return;
                }
            }
        }
        private bool CountScans()
        {
            foreach (DataGridViewRow row in maindg.Rows)
            {
                if (!row.Cells[2].Value.Equals(row.Cells[3].Value))
                {
                    return false;
                }
            }
            return true;
        }
        private void Init()
        {
            maindg.Rows.Clear();
            scandg.Rows.Clear();
            receiptdg.Rows.Clear();
            LoadRejectionTypes();
            LoadVoucher();
        }
        #endregion
        public void LanguageChanged(Language newLanguage)
        {
            maindg.Columns[0].HeaderText = _userTranslator.Translate("Linea");
            maindg.Columns[1].HeaderText = _userTranslator.Translate("Articulo");
            maindg.Columns[2].HeaderText = _userTranslator.Translate("Cantidad");
            maindg.Columns[3].HeaderText = "Scan";
            scandg.Columns[0].HeaderText = "#";
            scandg.Columns[1].HeaderText = _userTranslator.Translate("Codigo");
            scandg.Columns[2].HeaderText = _userTranslator.Translate("Motivo");
            receiptdg.Columns[0].HeaderText = _userTranslator.Translate("Codigo");
            receiptdg.Columns[1].HeaderText = _userTranslator.Translate("Motivo");
            receiptdg.Columns[2].HeaderText = _userTranslator.Translate("Cantidad");
            receiptlab.Text = _userTranslator.Translate("Comprobante");
            reasonlab.Text = _userTranslator.Translate("Motivo");
            voucherlab.Text = _userTranslator.Translate("Comprobante");
            completecb.Text = _userTranslator.Translate("ComplCant");
            dcbtn.Text = _userTranslator.Translate("Cierre");
            expedbtn.Text = _userTranslator.Translate("Expedicion");
            LoadRejectionTypes();
        }

        private void expedbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
