using BLL.Factory;
using Domain;
using Microsoft.Reporting.WinForms;
using Services.BLL.Contracts;
using Services.Domain.Language;
using Services.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UI.Print;

namespace UI.Forms.Stock
{
    public partial class frmPicking : Form, ILanguageSubscriber
    {
        #region FormSettings
        private readonly IUserTranslator _userTranslator;
        private readonly IFactory businessLayer;
        private static frmPicking _instance = null;
        private VoucherReportExtension _voucherReportExtension;
        private Voucher V = new();
        private IEnumerable<Voucher> list;
        public frmPicking(ApplicationServices applicationServices)
        {
            InitializeComponent();
            _userTranslator = applicationServices.GetUserTranslator;
            businessLayer = Factory.Current;
            this.EnlazarmeConServiciosDeTraduccion(_userTranslator);
        }
        public static frmPicking GetInstance(ApplicationServices applicationServices)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmPicking(applicationServices);
            return _instance;
        }
        #endregion
        #region FormActions
        private void printbtn_Click(object sender, EventArgs e)
        {
            if (SavePDF(reportViewer1))
            {
                try
                {
                    UpdateComp("I", V);
                }
                catch (Exception ex)
                {
                    this.MostrarDialogoError(_userTranslator, ex.Message);
                }
            }
        }
        private void maindg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            V = list.Where(x => x.Description.Equals(((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString()))
                    .FirstOrDefault();
            EnabledButtons(V);
            //LoadReportViewerData(V);
        }
        private void confirmbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, _userTranslator.Translate("ConfComprobante"), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    UpdateComp("C", V);
                    this.MostrarDialogoInformacion(_userTranslator, "ProcCorrecto");
                }
                catch (Exception ex)
                {
                    this.MostrarDialogoError(_userTranslator, ex.Message);
                }
            }
        }
        #endregion
        #region PrivateFunctions
        private void CargarComprobantes()
        {
            try
            {
                list = businessLayer.VoucherService.GetPickingVoucher();
                foreach (var item in list)
                {
                    maindg.Rows.Add(
                        item.Client.Description,
                        item.Description,
                        item.VoucherDate,
                        GetStatus(item.Closure)
                        );
                }
            }
            catch (Exception ex)
            {
                this.MostrarDialogoError(_userTranslator, ex.Message);
            }
        }
        private string GetStatus(string cierre)
        {
            switch (cierre)
            {
                case "I":
                    return _userTranslator.Translate("Impreso");
                case "C":
                    return _userTranslator.Translate("Conf");
                case "D":
                    return _userTranslator.Translate("Despachado");
                default:
                    return _userTranslator.Translate("NoImpreso");
            }
        }
        private void LoadReportViewerParameters()
        {
            ReportParameter[] reportParameters = new ReportParameter[12];
            reportParameters[0] = new ReportParameter("informe", _userTranslator.Translate("InformePicking"), true);
            reportParameters[1] = new ReportParameter("cliente", _userTranslator.Translate("Cliente"), true);
            reportParameters[2] = new ReportParameter("remito", _userTranslator.Translate("Remito"), true);
            reportParameters[3] = new ReportParameter("copia", _userTranslator.Translate("Original"), true);
            reportParameters[4] = new ReportParameter("comprobante", _userTranslator.Translate("Comprobante"), true);
            reportParameters[5] = new ReportParameter("fecha", _userTranslator.Translate("Fecha"), true);
            reportParameters[6] = new ReportParameter("codigo", _userTranslator.Translate("Codigo"), true);
            reportParameters[7] = new ReportParameter("descripcion", _userTranslator.Translate("Descripcion"), true);
            reportParameters[8] = new ReportParameter("cantidad", _userTranslator.Translate("Cantidad"), true);
            reportParameters[9] = new ReportParameter("cantidadtotal", _userTranslator.Translate("CantidadTotal"), true);
            reportParameters[10] = new ReportParameter("destinatario", _userTranslator.Translate("Destinatario"), true);
            reportParameters[11] = new ReportParameter("cp", _userTranslator.Translate("CodigoPostal"), true);
            reportViewer1.LocalReport.SetParameters(reportParameters);
        }
        private void LoadReportViewerData(Voucher _voucher)
        {
            Cursor = Cursors.WaitCursor;
            BindingSource Article = new BindingSource();
            BindingSource Voucher = new BindingSource();
            BindingSource VoucherDetail = new BindingSource();
            BindingSource Client = new BindingSource();
            BindingSource RejectionType = new BindingSource();
            BindingSource Addressee = new BindingSource();
            Article.DataSource = _voucher.VoucherDetails.Select(x => x.Article);
            Voucher.DataSource = _voucher;
            VoucherDetail.DataSource = _voucher.VoucherDetails;
            Client.DataSource = _voucher.Client;
            RejectionType.DataSource = _voucher.VoucherDetails.Select(x => x.RejectionType ?? new RejectionType());
            Addressee.DataSource = _voucher.Addressee;
            ReportDataSource ArticleDS = new ReportDataSource(nameof(Article), Article);
            ReportDataSource VoucherDS = new ReportDataSource(nameof(Voucher), Voucher);
            ReportDataSource VoucherDetailDS = new ReportDataSource(nameof(VoucherDetail), VoucherDetail);
            ReportDataSource ClientDS = new ReportDataSource(nameof(Client), Client);
            ReportDataSource RejectionTypeDS = new ReportDataSource(nameof(RejectionType), RejectionType);
            ReportDataSource AddresseeDS = new ReportDataSource(nameof(Addressee), Addressee);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(ArticleDS);
            this.reportViewer1.LocalReport.DataSources.Add(VoucherDS);
            this.reportViewer1.LocalReport.DataSources.Add(VoucherDetailDS);
            this.reportViewer1.LocalReport.DataSources.Add(ClientDS);
            this.reportViewer1.LocalReport.DataSources.Add(RejectionTypeDS);
            this.reportViewer1.LocalReport.DataSources.Add(AddresseeDS);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            Cursor = Cursors.Default;
        }
        private void Init()
        {
            maindg.Rows.Clear();
            CargarComprobantes();
            if (list == null) return;
            LoadReportViewerParameters();
            V = list.FirstOrDefault();
            EnabledButtons(V);
            LoadReportViewerData(V);
            reportViewer1.RefreshReport();
        }
        private void UpdateComp(string closure, Voucher V)
        {
            V.Closure = closure;
            businessLayer.VoucherService.Update(V);
            Init();
        }
        public bool SavePDF(ReportViewer viewer)
        {
            using (SaveFileDialog save = new())
            {
                save.FileName = V.Description;
                save.Filter = "PDF|*.pdf";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    byte[] Bytes = viewer.LocalReport.Render(format: "PDF", deviceInfo: "");
                    using (FileStream stream = new(save.FileName, FileMode.Create))
                    {
                        stream.Write(Bytes, 0, Bytes.Length);
                    }
                    return true;
                }
            }
            return false;
        }
        private void EnabledButtons(Voucher V)
        {
            if (V.Closure == null)
            {
                printbtn.Enabled = true;
                confirmbtn.Enabled = false;
            }
            else
            {
                printbtn.Enabled = false;
                confirmbtn.Enabled = true;
            }
        }
        #endregion
        #region Language
        public void LanguageChanged(Language newLanguage)
        {
            maindg.Columns[0].HeaderText = _userTranslator.Translate("Cliente");
            maindg.Columns[1].HeaderText = _userTranslator.Translate("Comprobante");
            maindg.Columns[2].HeaderText = _userTranslator.Translate("Fecha");
            maindg.Columns[3].HeaderText = _userTranslator.Translate("Estado");
            printbtn.Text = _userTranslator.Translate("Imprimir");
            confirmbtn.Text = _userTranslator.Translate("Conf");
            Init();
        }
        #endregion
    }
}
