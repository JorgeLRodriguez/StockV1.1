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
        private IFactory _businessLayer;
        private static frmPicking _instance = null;
        private Voucher V = new();
        private IEnumerable<Voucher> list;
        public frmPicking(ApplicationServices applicationServices)
        {
            _businessLayer = Factory.GetInstance();
            InitializeComponent();
            _userTranslator = applicationServices.GetUserTranslator;
            this.LinkToTranslationServices(_userTranslator);
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
                    this.ShowErrorDialog(_userTranslator, ex.Message);
                }
            }
        }
        private void maindg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            V = list.Where(x => x.Description.Equals(((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString()))
                    .FirstOrDefault();
            EnabledButtons(V);
            VoucherReportExtension.Current.LoadReport(V,reportViewer1);
        }
        private void confirmbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, _userTranslator.Translate("ConfComprobante"), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    UpdateComp("C", V);
                    this.ShowInformationDialog(_userTranslator, "ProcCorrecto");
                }
                catch (Exception ex)
                {
                    this.ShowErrorDialog(_userTranslator, ex.Message);
                }
            }
        }
        #endregion
        #region PrivateFunctions
        private void LoadVouchers()
        {
            try
            {
                list = _businessLayer.VoucherService.GetPickingVoucher();
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
                this.ShowErrorDialog(_userTranslator, ex.Message);
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
        private void Init()
        {
            maindg.Rows.Clear();
            LoadVouchers();
            if (list == null) return;
            V = list.FirstOrDefault();
            EnabledButtons(V);
            VoucherReportExtension.Current.LoadReport(V, reportViewer1);
        }
        private void UpdateComp(string closure, Voucher V)
        {
            V.Closure = closure;
            _businessLayer.VoucherService.Update(V);
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
        private void frmPicking_Load(object sender, EventArgs e)
        {
            _businessLayer = Factory.GetInstance();
            Init();
        }
    }
}
