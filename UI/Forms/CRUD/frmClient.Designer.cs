
namespace UI.Forms.CRUD
{
    partial class frmClient
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
            this.labNombre = new System.Windows.Forms.Label();
            this.labCUIT = new System.Windows.Forms.Label();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labActivo = new System.Windows.Forms.Label();
            this.cbxEnabled = new System.Windows.Forms.ComboBox();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.cbxEnabled);
            this.bottomPanel.Controls.Add(this.txtName);
            this.bottomPanel.Controls.Add(this.txtCUIT);
            this.bottomPanel.Controls.Add(this.labCUIT);
            this.bottomPanel.Controls.Add(this.labNombre);
            this.bottomPanel.Controls.Add(this.labActivo);
            this.bottomPanel.Controls.SetChildIndex(this.labActivo, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labNombre, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labCUIT, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtCUIT, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtName, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnNew, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnSave, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnDelete, 0);
            this.bottomPanel.Controls.SetChildIndex(this.cbxEnabled, 0);
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
            // labNombre
            // 
            this.labNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labNombre.ForeColor = System.Drawing.Color.White;
            this.labNombre.Location = new System.Drawing.Point(95, 67);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(100, 21);
            this.labNombre.TabIndex = 5;
            this.labNombre.Text = "Name";
            this.labNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labCUIT
            // 
            this.labCUIT.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labCUIT.ForeColor = System.Drawing.Color.White;
            this.labCUIT.Location = new System.Drawing.Point(95, 132);
            this.labCUIT.Name = "labCUIT";
            this.labCUIT.Size = new System.Drawing.Size(100, 21);
            this.labCUIT.TabIndex = 7;
            this.labCUIT.Text = "CUIT";
            this.labCUIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCUIT
            // 
            this.txtCUIT.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCUIT.Location = new System.Drawing.Point(198, 132);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(165, 23);
            this.txtCUIT.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(198, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 23);
            this.txtName.TabIndex = 11;
            // 
            // labActivo
            // 
            this.labActivo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labActivo.ForeColor = System.Drawing.Color.White;
            this.labActivo.Location = new System.Drawing.Point(473, 67);
            this.labActivo.Name = "labActivo";
            this.labActivo.Size = new System.Drawing.Size(82, 23);
            this.labActivo.TabIndex = 4;
            this.labActivo.Text = "Activo";
            this.labActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxEnabled
            // 
            this.cbxEnabled.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxEnabled.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxEnabled.FormattingEnabled = true;
            this.cbxEnabled.Location = new System.Drawing.Point(561, 65);
            this.cbxEnabled.Name = "cbxEnabled";
            this.cbxEnabled.Size = new System.Drawing.Size(127, 25);
            this.cbxEnabled.TabIndex = 13;
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Name = "frmClient";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.Label labCUIT;
        private System.Windows.Forms.Label labNombre;
        private System.Windows.Forms.Label labActivo;
        private System.Windows.Forms.ComboBox cbxEnabled;
    }
}