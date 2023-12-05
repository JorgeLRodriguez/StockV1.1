
namespace UI.Forms.CRUD
{
    partial class frmDeposit
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
            this.cbxClient = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.labAddress = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labClient = new System.Windows.Forms.Label();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.cbxClient);
            this.bottomPanel.Controls.Add(this.txtName);
            this.bottomPanel.Controls.Add(this.txtAddress);
            this.bottomPanel.Controls.Add(this.labAddress);
            this.bottomPanel.Controls.Add(this.labName);
            this.bottomPanel.Controls.Add(this.labClient);
            this.bottomPanel.Controls.SetChildIndex(this.btnSave, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnDelete, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnNew, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labClient, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labName, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labAddress, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtAddress, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtName, 0);
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
            // cbxClient
            // 
            this.cbxClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxClient.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxClient.FormattingEnabled = true;
            this.cbxClient.Location = new System.Drawing.Point(108, 23);
            this.cbxClient.Name = "cbxClient";
            this.cbxClient.Size = new System.Drawing.Size(181, 25);
            this.cbxClient.TabIndex = 19;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(481, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 23);
            this.txtName.TabIndex = 18;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddress.Location = new System.Drawing.Point(108, 88);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(181, 23);
            this.txtAddress.TabIndex = 17;
            // 
            // labAddress
            // 
            this.labAddress.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labAddress.ForeColor = System.Drawing.Color.White;
            this.labAddress.Location = new System.Drawing.Point(21, 88);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(82, 21);
            this.labAddress.TabIndex = 16;
            this.labAddress.Text = "Address";
            this.labAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labName
            // 
            this.labName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labName.ForeColor = System.Drawing.Color.White;
            this.labName.Location = new System.Drawing.Point(378, 23);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(100, 21);
            this.labName.TabIndex = 15;
            this.labName.Text = "Name";
            this.labName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labClient
            // 
            this.labClient.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labClient.ForeColor = System.Drawing.Color.White;
            this.labClient.Location = new System.Drawing.Point(21, 23);
            this.labClient.Name = "labClient";
            this.labClient.Size = new System.Drawing.Size(82, 23);
            this.labClient.TabIndex = 14;
            this.labClient.Text = "Client";
            this.labClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmDeposit
            // 
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Name = "frmDeposit";
            this.Load += new System.EventHandler(this.frmDeposit_Load);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxClient;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label labAddress;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labClient;
    }
}