
namespace UI.Forms.Stock
{
    partial class frmPicking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.printbtn = new System.Windows.Forms.Button();
            this.confirmbtn = new System.Windows.Forms.Button();
            this.maindg = new System.Windows.Forms.DataGridView();
            this.lineatxtdg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articulotxtdg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitytxtdg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scantxtdg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.maindg)).BeginInit();
            this.SuspendLayout();
            // 
            // printbtn
            // 
            this.printbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printbtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.printbtn.ForeColor = System.Drawing.Color.White;
            this.printbtn.Location = new System.Drawing.Point(76, 14);
            this.printbtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(102, 40);
            this.printbtn.TabIndex = 0;
            this.printbtn.Text = "Imprimir";
            this.printbtn.UseVisualStyleBackColor = true;
            this.printbtn.Click += new System.EventHandler(this.printbtn_Click);
            // 
            // confirmbtn
            // 
            this.confirmbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmbtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confirmbtn.ForeColor = System.Drawing.Color.White;
            this.confirmbtn.Location = new System.Drawing.Point(184, 14);
            this.confirmbtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.confirmbtn.Name = "confirmbtn";
            this.confirmbtn.Size = new System.Drawing.Size(122, 40);
            this.confirmbtn.TabIndex = 1;
            this.confirmbtn.Text = "Confirmar";
            this.confirmbtn.UseVisualStyleBackColor = true;
            this.confirmbtn.Click += new System.EventHandler(this.confirmbtn_Click);
            // 
            // maindg
            // 
            this.maindg.AllowUserToAddRows = false;
            this.maindg.AllowUserToDeleteRows = false;
            this.maindg.AllowUserToOrderColumns = true;
            this.maindg.AllowUserToResizeRows = false;
            this.maindg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maindg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.maindg.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.maindg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.maindg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.maindg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineatxtdg,
            this.articulotxtdg,
            this.quantitytxtdg,
            this.scantxtdg});
            this.maindg.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.maindg.DefaultCellStyle = dataGridViewCellStyle3;
            this.maindg.GridColor = System.Drawing.Color.White;
            this.maindg.Location = new System.Drawing.Point(14, 61);
            this.maindg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.maindg.MultiSelect = false;
            this.maindg.Name = "maindg";
            this.maindg.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.maindg.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.maindg.RowHeadersVisible = false;
            this.maindg.Size = new System.Drawing.Size(1062, 263);
            this.maindg.TabIndex = 15;
            this.maindg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.maindg_CellClick);
            // 
            // lineatxtdg
            // 
            this.lineatxtdg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.lineatxtdg.DefaultCellStyle = dataGridViewCellStyle2;
            this.lineatxtdg.HeaderText = "";
            this.lineatxtdg.Name = "lineatxtdg";
            this.lineatxtdg.ReadOnly = true;
            this.lineatxtdg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // articulotxtdg
            // 
            this.articulotxtdg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.articulotxtdg.HeaderText = "";
            this.articulotxtdg.Name = "articulotxtdg";
            this.articulotxtdg.ReadOnly = true;
            // 
            // quantitytxtdg
            // 
            this.quantitytxtdg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantitytxtdg.HeaderText = "";
            this.quantitytxtdg.Name = "quantitytxtdg";
            this.quantitytxtdg.ReadOnly = true;
            // 
            // scantxtdg
            // 
            this.scantxtdg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.scantxtdg.HeaderText = "";
            this.scantxtdg.Name = "scantxtdg";
            this.scantxtdg.ReadOnly = true;
            this.scantxtdg.Width = 19;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Print.voucher.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(14, 342);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowToolBar = false;
            this.reportViewer1.Size = new System.Drawing.Size(1061, 310);
            this.reportViewer1.TabIndex = 16;
            // 
            // frmPicking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(26)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(1090, 666);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.maindg);
            this.Controls.Add(this.confirmbtn);
            this.Controls.Add(this.printbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmPicking";
            this.Text = "Picking";
            this.Load += new System.EventHandler(this.frmPicking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maindg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printbtn;
        private System.Windows.Forms.Button confirmbtn;
        private System.Windows.Forms.DataGridView maindg;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineatxtdg;
        private System.Windows.Forms.DataGridViewTextBoxColumn articulotxtdg;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantitytxtdg;
        private System.Windows.Forms.DataGridViewTextBoxColumn scantxtdg;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}