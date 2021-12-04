
namespace UI.Forms.Print
{
    partial class frmPrintVoucher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.copiacb = new System.Windows.Forms.ComboBox();
            this.copialab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Print.voucher.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(14, 14);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(740, 347);
            this.reportViewer1.TabIndex = 0;
            // 
            // copiacb
            // 
            this.copiacb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.copiacb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.copiacb.FormattingEnabled = true;
            this.copiacb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.copiacb.Location = new System.Drawing.Point(762, 48);
            this.copiacb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.copiacb.Name = "copiacb";
            this.copiacb.Size = new System.Drawing.Size(140, 23);
            this.copiacb.TabIndex = 2;
            this.copiacb.SelectedIndexChanged += new System.EventHandler(this.copiacb_SelectedIndexChanged);
            // 
            // copialab
            // 
            this.copialab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.copialab.Location = new System.Drawing.Point(763, 15);
            this.copialab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.copialab.Name = "copialab";
            this.copialab.Size = new System.Drawing.Size(117, 27);
            this.copialab.TabIndex = 3;
            this.copialab.Text = "label1";
            // 
            // frmPrintVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 376);
            this.Controls.Add(this.copialab);
            this.Controls.Add(this.copiacb);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmPrintVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir comprobante";
            this.Load += new System.EventHandler(this.printcompfrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox copiacb;
        private System.Windows.Forms.Label copialab;
    }
}