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

namespace UI.Forms.Stock
{
    public partial class frmTransfer : Form, ILanguageSubscriber
    {
        #region FormSettings
        private readonly IUserTranslator _userTranslator;
        private readonly IFactory _businessLayer;
        private static frmTransfer _instance = null;
        public frmTransfer()
        {
            _businessLayer = Factory.GetInstance();
            InitializeComponent();
            _userTranslator = ApplicationServices.GetInstance().GetUserTranslator;
            this.LinkToTranslationServices(_userTranslator);
        }
        public static frmTransfer GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new frmTransfer();
            return _instance;
        }
        #endregion
        private void Transferenciafrm_Load(object sender, EventArgs e)
        {
            var deposits = ListDeposits();
            if (deposits == null) return;
            if (deposits.Any())
            {
                depcbx.DisplayMember = nameof(Deposit.DepositName);
                depcbx.DataSource = ListDeposits();
            }
        }
        private IEnumerable<Deposit> ListDeposits()
        {
            IEnumerable<Deposit> list = null;
            try
            {
                list = _businessLayer.DepositService.GetAll();
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog(_userTranslator, ex.Message);
            }
            return list;
        }
        private IEnumerable<Pallet> ListPallet(Deposit Deposit)
        {
            IEnumerable<Pallet> list = null;
            try
            {
                list = _businessLayer.PalletService.GetByDep(Deposit);
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog(_userTranslator, ex.Message);
            }
            return list;
        }
        private IEnumerable<VoucherDetail> ListArticulosByComprobante()
        {
            IEnumerable<VoucherDetail> list = null;
            try
            {
                list = _businessLayer.VoucherService.GetTransferVoucher().SelectMany(c => c.VoucherDetails);
                list.ToList().ForEach(x => x.RejectionType = GetRejectionType(x));
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog(_userTranslator, ex.Message);
            }
            return list;
        }
        private RejectionType GetRejectionType(VoucherDetail cd)
        {
            var rejectionTypes = _businessLayer.VoucherService.GetRejectionTypes();
            return rejectionTypes.Where(x => x.ID.Equals(cd.RejectionType_ID)).SingleOrDefault();
        }
        private void depcbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<VoucherDetail> listcd = null;
            List<Pallet> listp = null;
            listcd = ListArticulosByComprobante().ToList();
            if (origendg.Rows.Count > 0) origendg.Rows.Clear();
            if (listcd.Any())
            {
                foreach (var item in listcd)
                {
                    origendg.Rows.Add(
                        "(" + item.Article.FsCode + ") " + item.Article.Description,
                        item.Quantity,
                        item.RejectionType.Description
                        );
                }
            }
            listp = ListPallet((Deposit)depcbx.SelectedItem).ToList();
            if (listp.Any())
            {
                palletcb.DisplayMember = nameof(Pallet.Description);
                palletcb.DataSource = listp;
            }
        }
        private void origendg_MouseDown(object sender, MouseEventArgs e)
        {
            var hitTestInfo = origendg.HitTest(e.X, e.Y);
            if (hitTestInfo.RowIndex > -1)
            {
                origendg.DoDragDrop(hitTestInfo.RowIndex,
                    DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
        private void destdg_DragDrop(object sender, DragEventArgs e)
        {
            string dropData = e.Data.GetData(DataFormats.Text).ToString();
            int rowIndex = int.Parse(dropData);

            var cells = origendg.Rows[rowIndex].Cells.Cast<DataGridViewCell>()
                            .Select(c => c.Value).ToArray();
            origendg.Rows.Add(cells);

            origendg.Rows.RemoveAt(rowIndex);
        }
        private void destdg_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.StringFormat) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        public void LanguageChanged(Language newLanguage)
        {
            origendg.Columns[0].HeaderText = _userTranslator.Translate("Articulo");
            origendg.Columns[1].HeaderText = _userTranslator.Translate("Cantidad");
            origendg.Columns[2].HeaderText = _userTranslator.Translate("Estado");
            originlab.Text = _userTranslator.Translate("Origen");
            destlab.Text = _userTranslator.Translate("Destino");
        }
    }
}
