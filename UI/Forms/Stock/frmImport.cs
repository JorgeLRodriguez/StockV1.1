using BLL.Factory;
using Domain;
using Services.BLL.Contracts;
using Services.Domain.Language;
using Services.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace UI.Forms.Stock
{
    public partial class frmImport : Form, ILanguageSubscriber
    {
        #region FormSettings
        private readonly IUserTranslator _UserTranslator;
        private readonly IFactory _bussinessLayer;
        private readonly ApplicationServices _applicationServices;
        private static frmImport _instance = null;
        private string FileName = null;
        public frmImport(ApplicationServices applicationServices)
        {
            InitializeComponent();
            _applicationServices = applicationServices;
            _UserTranslator = _applicationServices.GetUserTranslator;
            _bussinessLayer = Factory.Current;
            this.EnlazarmeConServiciosDeTraduccion(_UserTranslator);
        }
        public static frmImport GetInstance(ApplicationServices applicationServices)
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmImport(applicationServices);
            return _instance;
        }
        #endregion
        #region FormActions
        private void impbtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            openFileDialog.Filter = ".csv|*.csv";
            openFileDialog.FileName = "";
            openFileDialog.ShowDialog();
            Cursor.Current = Cursors.WaitCursor;
            csvdg.DataSource = "";
            if (Path.GetExtension(openFileDialog.FileName) == ".csv")
            {
                using (TextReader tr = File.OpenText(openFileDialog.FileName))
                {
                    FileName = openFileDialog.SafeFileName;
                    Cursor.Current = Cursors.WaitCursor;
                    string line;
                    while ((line = tr.ReadLine()) != null)
                    {
                        string[] items = line.Split(';');
                        if (dt.Columns.Count == 0)
                        {
                            for (int i = 0; i < items.Length; i++)
                                dt.Columns.Add(new DataColumn(items[i], typeof(string)));
                        }
                        else
                        {
                            dt.Rows.Add(items);
                        }
                    }
                    csvdg.DataSource = dt;
                }
            }
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                _bussinessLayer.CSVService.Create(GetInvoices(csvdg));
                this.MostrarDialogoInformacion(_UserTranslator, "ComprobanteGenerado");
                csvdg.DataSource = "";
            }
            catch (Exception ex)
            {
                this.MostrarDialogoError(_UserTranslator, ex.Message);
            }
        }
        #endregion
        #region PrivateFunctions
        private List<CSV> GetInvoices(DataGridView dg)
        {
            List<CSV> CSVs = new();
            foreach (DataGridViewRow dr in dg.Rows)
            {
                CSVs.Add(new CSV()
                {
                    ID = Guid.NewGuid(),
                    InvoiceDate = Convert.ToDateTime(dr.Cells[0].Value.ToString()),
                    Cuit = dr.Cells[1].Value.ToString(),
                    Letter = dr.Cells[2].Value.ToString(),
                    Branch = dr.Cells[3].Value.ToString(),
                    InvoiceNumber = dr.Cells[4].Value.ToString(),
                    DocType = Convert.ToInt32(dr.Cells[5].Value),
                    DocNumber = Convert.ToInt32(dr.Cells[6].Value.ToString()),
                    AddresseeName = dr.Cells[7].Value.ToString(),
                    AddresseeLastName = dr.Cells[8].Value.ToString(),
                    AddresseeAddress = dr.Cells[9].Value.ToString(),
                    AddresseeZipCode = dr.Cells[10].Value.ToString(),
                    AddresseePhoneNumber = dr.Cells[11].Value.ToString(),
                    AddresseeCellPhoneNumber = dr.Cells[12].Value.ToString(),
                    AddresseeMail = dr.Cells[13].Value.ToString(),
                    DeliveryDate = Convert.ToDateTime(dr.Cells[14].Value.ToString()),
                    DeliveryTimeSlot = dr.Cells[15].Value.ToString(),
                    RetirementDate = Convert.ToDateTime(dr.Cells[16].Value.ToString()),
                    ClientAddresse = dr.Cells[17].Value.ToString(),
                    ClientZipCode = dr.Cells[18].Value.ToString(),
                    Packages = Convert.ToInt32(dr.Cells[19].Value),
                    FsCode = dr.Cells[20].Value.ToString(),
                    Weight = Convert.ToInt32(dr.Cells[21].Value),
                    Width = Convert.ToInt32(dr.Cells[22].Value),
                    Long = Convert.ToInt32(dr.Cells[23].Value.ToString()),
                    High = Convert.ToInt32(dr.Cells[24].Value.ToString()),
                    FileName = FileName
                });
            }
            return CSVs;
        }
        #endregion
        #region Language
        public void LanguageChanged(Language newLanguage)
        {
            impbtn.Text = _UserTranslator.Translate("Importar");
            savebtn.Text = _UserTranslator.Translate("Guardar");
            openFileDialog.Title = _UserTranslator.Translate("Importar");
        }
        #endregion
    }
}