
namespace UI.Forms.CRUD
{
    partial class frmPallet
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
            this.labClient = new System.Windows.Forms.Label();
            this.labDescription = new System.Windows.Forms.Label();
            this.labFsCode = new System.Windows.Forms.Label();
            this.labBarcode = new System.Windows.Forms.Label();
            this.labOwnBarcode = new System.Windows.Forms.Label();
            this.txtFsCode = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cbxOwnBarcode = new System.Windows.Forms.ComboBox();
            this.cbxClient = new System.Windows.Forms.ComboBox();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.cbxClient);
            this.bottomPanel.Controls.Add(this.cbxOwnBarcode);
            this.bottomPanel.Controls.Add(this.txtDescription);
            this.bottomPanel.Controls.Add(this.txtBarcode);
            this.bottomPanel.Controls.Add(this.txtFsCode);
            this.bottomPanel.Controls.Add(this.labOwnBarcode);
            this.bottomPanel.Controls.Add(this.labBarcode);
            this.bottomPanel.Controls.Add(this.labFsCode);
            this.bottomPanel.Controls.Add(this.labDescription);
            this.bottomPanel.Controls.Add(this.labClient);
            this.bottomPanel.Controls.SetChildIndex(this.btnNew, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnSave, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnDelete, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labClient, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labDescription, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labFsCode, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labBarcode, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labOwnBarcode, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtFsCode, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtBarcode, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtDescription, 0);
            this.bottomPanel.Controls.SetChildIndex(this.cbxOwnBarcode, 0);
            this.bottomPanel.Controls.SetChildIndex(this.cbxClient, 0);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // labClient
            // 
            this.labClient.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labClient.ForeColor = System.Drawing.Color.White;
            this.labClient.Location = new System.Drawing.Point(12, 25);
            this.labClient.Name = "labClient";
            this.labClient.Size = new System.Drawing.Size(82, 23);
            this.labClient.TabIndex = 4;
            this.labClient.Text = "Client";
            this.labClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labDescription
            // 
            this.labDescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labDescription.ForeColor = System.Drawing.Color.White;
            this.labDescription.Location = new System.Drawing.Point(369, 25);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new System.Drawing.Size(100, 21);
            this.labDescription.TabIndex = 5;
            this.labDescription.Text = "Description";
            this.labDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labFsCode
            // 
            this.labFsCode.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labFsCode.ForeColor = System.Drawing.Color.White;
            this.labFsCode.Location = new System.Drawing.Point(12, 90);
            this.labFsCode.Name = "labFsCode";
            this.labFsCode.Size = new System.Drawing.Size(82, 21);
            this.labFsCode.TabIndex = 6;
            this.labFsCode.Text = "Fs Code";
            this.labFsCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labBarcode
            // 
            this.labBarcode.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labBarcode.ForeColor = System.Drawing.Color.White;
            this.labBarcode.Location = new System.Drawing.Point(369, 90);
            this.labBarcode.Name = "labBarcode";
            this.labBarcode.Size = new System.Drawing.Size(100, 21);
            this.labBarcode.TabIndex = 7;
            this.labBarcode.Text = "Barcode";
            this.labBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labOwnBarcode
            // 
            this.labOwnBarcode.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labOwnBarcode.ForeColor = System.Drawing.Color.White;
            this.labOwnBarcode.Location = new System.Drawing.Point(12, 160);
            this.labOwnBarcode.Name = "labOwnBarcode";
            this.labOwnBarcode.Size = new System.Drawing.Size(119, 21);
            this.labOwnBarcode.TabIndex = 8;
            this.labOwnBarcode.Text = "Own Barcode";
            this.labOwnBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFsCode
            // 
            this.txtFsCode.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFsCode.Location = new System.Drawing.Point(99, 90);
            this.txtFsCode.Name = "txtFsCode";
            this.txtFsCode.Size = new System.Drawing.Size(165, 23);
            this.txtFsCode.TabIndex = 9;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBarcode.Location = new System.Drawing.Point(472, 90);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(165, 23);
            this.txtBarcode.TabIndex = 10;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescription.Location = new System.Drawing.Point(472, 25);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(165, 23);
            this.txtDescription.TabIndex = 11;
            // 
            // cbxOwnBarcode
            // 
            this.cbxOwnBarcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxOwnBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxOwnBarcode.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxOwnBarcode.FormattingEnabled = true;
            this.cbxOwnBarcode.Location = new System.Drawing.Point(137, 160);
            this.cbxOwnBarcode.Name = "cbxOwnBarcode";
            this.cbxOwnBarcode.Size = new System.Drawing.Size(127, 25);
            this.cbxOwnBarcode.TabIndex = 12;
            // 
            // cbxClient
            // 
            this.cbxClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxClient.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxClient.FormattingEnabled = true;
            this.cbxClient.Location = new System.Drawing.Point(99, 25);
            this.cbxClient.Name = "cbxClient";
            this.cbxClient.Size = new System.Drawing.Size(165, 25);
            this.cbxClient.TabIndex = 13;
            // 
            // frmPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Name = "frmPallet";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmPallet_Load);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labClient;
        private System.Windows.Forms.ComboBox cbxClient;
        private System.Windows.Forms.ComboBox cbxOwnBarcode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtFsCode;
        private System.Windows.Forms.Label labOwnBarcode;
        private System.Windows.Forms.Label labBarcode;
        private System.Windows.Forms.Label labFsCode;
        private System.Windows.Forms.Label labDescription;
    }
}