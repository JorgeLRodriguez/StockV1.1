using Domain;
using Microsoft.Reporting.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI.Print
{
    public class VoucherLabelReportExtension
    {
        private readonly Voucher _voucher;
        private readonly ReportViewer _reportViewer;
        public VoucherLabelReportExtension(Voucher voucher, ReportViewer reportViewer)
        {
            _voucher = voucher;
            _reportViewer = reportViewer;
            Init();
        }
        private void Init()
        {
            try
            {
                BindingSource Voucher = new();
                BindingSource Client = new();
                BindingSource Article = new();
                BindingSource Label = new();

                Article.DataSource = _voucher.VoucherDetails.Select(x => x.Article);
                Voucher.DataSource = _voucher;
                Label.DataSource = _voucher.Labels.ToList();
                Client.DataSource = _voucher.Client;

                ReportDataSource ArticleDS = new("Article", Article);
                ReportDataSource VoucherDS = new("Voucher", Voucher);
                ReportDataSource LabelDS = new("Label", Label);
                ReportDataSource ClientDS = new("Client", Client);

                _reportViewer.LocalReport.DataSources.Clear();
                _reportViewer.LocalReport.DataSources.Add(ArticleDS);
                _reportViewer.LocalReport.DataSources.Add(VoucherDS);
                _reportViewer.LocalReport.DataSources.Add(LabelDS);
                _reportViewer.LocalReport.DataSources.Add(ClientDS);
                _reportViewer.LocalReport.Refresh();
                _reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}