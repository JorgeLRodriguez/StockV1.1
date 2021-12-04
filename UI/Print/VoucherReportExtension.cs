using Domain;
using Microsoft.Reporting.WinForms;
using Services.BLL.Contracts;
using Services.Factory;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI.Print
{
    internal sealed class VoucherReportExtension
    {
        private readonly IUserTranslator _userTranslator;
        private readonly Voucher _voucher;
        private ReportViewer _reportViewer;
        public VoucherReportExtension(Voucher voucher, ReportViewer reportViewer)
        {
            _reportViewer = reportViewer;
            _voucher = voucher;
            _userTranslator = ApplicationServices.Current.GetUserTranslator;
            Init();
        }
        private void Init()
        {
            ReportParameter[] reportParameters = new ReportParameter[12];

            reportParameters[0] = new ReportParameter("report", GetNameReport(_voucher.VoucherType), true);
            reportParameters[1] = new ReportParameter("client", _userTranslator.Translate("Cliente"), true);
            reportParameters[2] = new ReportParameter("invoice", _userTranslator.Translate("Remito"), true);
            reportParameters[3] = new ReportParameter("copy", _userTranslator.Translate("Original"), true);
            reportParameters[4] = new ReportParameter("voucher", _userTranslator.Translate("Comprobante"), true);
            reportParameters[5] = new ReportParameter("date", _userTranslator.Translate("Fecha"), true);
            reportParameters[6] = new ReportParameter("code", _userTranslator.Translate("Codigo"), true);
            reportParameters[7] = new ReportParameter("description", _userTranslator.Translate("Descripcion"), true);
            reportParameters[8] = new ReportParameter("quantity", _userTranslator.Translate("Cantidad"), true);
            reportParameters[9] = new ReportParameter("totalquantity", _userTranslator.Translate("CantidadTotal"), true);
            reportParameters[10] = new ReportParameter("addressee", GetAddresseeParameter((_voucher.VoucherType)), true);
            reportParameters[11] = new ReportParameter("zipcode", GetZipCodeParameter((_voucher.VoucherType)), true);

            _reportViewer.LocalReport.SetParameters(reportParameters);

            BindingSource Article = new();
            BindingSource Voucher = new();
            BindingSource VoucherDetail = new();
            BindingSource Client = new();
            BindingSource RejectionType = new();
            BindingSource Addressee = new();

            Article.DataSource = _voucher.VoucherDetails.Select(x => x.Article);
            Voucher.DataSource = _voucher;
            VoucherDetail.DataSource = _voucher.VoucherDetails;
            Client.DataSource = _voucher.Client;
            RejectionType.DataSource = _voucher.VoucherDetails.Select(x => x.RejectionType ?? new RejectionType());
            Addressee.DataSource = _voucher.Addressee ?? new Addressee() { Name = " ", LastName = " ", ZipCode = " " };

            ReportDataSource ArticleDS = new("Article", Article);
            ReportDataSource VoucherDS = new("Voucher", Voucher);
            ReportDataSource VoucherDetailDS = new("VoucherDetail", VoucherDetail);
            ReportDataSource ClienteDS = new("Client", Client);
            ReportDataSource RejectionTypeDS = new("RejectionType", RejectionType);
            ReportDataSource AddresseeDS = new("Addressee", Addressee);

            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(ArticleDS);
            _reportViewer.LocalReport.DataSources.Add(VoucherDS);
            _reportViewer.LocalReport.DataSources.Add(VoucherDetailDS);
            _reportViewer.LocalReport.DataSources.Add(ClienteDS);
            _reportViewer.LocalReport.DataSources.Add(RejectionTypeDS);
            _reportViewer.LocalReport.DataSources.Add(AddresseeDS);
            _reportViewer.LocalReport.Refresh();
            _reportViewer.RefreshReport();
        }
        public void CopyChanged(string newCopy)
        {
            ReportParameter reportParameter = new ReportParameter("copy", newCopy, true);
            _reportViewer.LocalReport.SetParameters(reportParameter);
            _reportViewer.LocalReport.Refresh();
            _reportViewer.RefreshReport();
        }
        private string GetNameReport(VoucherType voucherType)
        {
            return voucherType switch
            {
                VoucherType.SIR => _userTranslator.Translate("InformeRecepcion"),
                VoucherType.SIS => _userTranslator.Translate("InformeScaneo"),
                _ => String.Empty,
            };
        }
        private string GetAddresseeParameter(VoucherType voucherType)
        {
            return voucherType switch
            {
                VoucherType.SPK => _userTranslator.Translate("Destinatario"),
                _ => " ",
            };
        }
        private string GetZipCodeParameter(VoucherType voucherType)
        {
            return voucherType switch
            {
                VoucherType.SPK => _userTranslator.Translate("CodigoPostal"),
                _ => " ",
            };
        }
    }
}