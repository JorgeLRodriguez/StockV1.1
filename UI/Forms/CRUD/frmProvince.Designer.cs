
namespace UI.Forms.CRUD
{
    partial class frmProvince
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
            this.txtProvinceName = new System.Windows.Forms.TextBox();
            this.labProvinceName = new System.Windows.Forms.Label();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.txtProvinceName);
            this.bottomPanel.Controls.Add(this.labProvinceName);
            this.bottomPanel.Controls.SetChildIndex(this.btnSave, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnDelete, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnNew, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labProvinceName, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtProvinceName, 0);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.White;
            // 
            // txtProvinceName
            // 
            this.txtProvinceName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProvinceName.Location = new System.Drawing.Point(154, 75);
            this.txtProvinceName.Name = "txtProvinceName";
            this.txtProvinceName.Size = new System.Drawing.Size(181, 23);
            this.txtProvinceName.TabIndex = 11;
            // 
            // labProvinceName
            // 
            this.labProvinceName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labProvinceName.ForeColor = System.Drawing.Color.White;
            this.labProvinceName.Location = new System.Drawing.Point(67, 75);
            this.labProvinceName.Name = "labProvinceName";
            this.labProvinceName.Size = new System.Drawing.Size(82, 21);
            this.labProvinceName.TabIndex = 10;
            this.labProvinceName.Text = "Fs Code";
            this.labProvinceName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmProvince
            // 
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Name = "frmProvince";
            this.Load += new System.EventHandler(this.frmProvince_Load);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtProvinceName;
        private System.Windows.Forms.Label labProvinceName;
    }
}