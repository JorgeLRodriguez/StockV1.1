
namespace UI.Forms.CRUD
{
    partial class frmAisle
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
            this.labDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.txtDescription);
            this.bottomPanel.Controls.Add(this.labDescription);
            this.bottomPanel.Controls.SetChildIndex(this.btnNew, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnSave, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnDelete, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labDescription, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtDescription, 0);
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
            // labDescription
            // 
            this.labDescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labDescription.ForeColor = System.Drawing.Color.White;
            this.labDescription.Location = new System.Drawing.Point(21, 34);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new System.Drawing.Size(100, 21);
            this.labDescription.TabIndex = 5;
            this.labDescription.Text = "Description";
            this.labDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescription.Location = new System.Drawing.Point(124, 34);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(165, 23);
            this.txtDescription.TabIndex = 11;
            // 
            // frmAisle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Name = "frmAisle";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmAisle_Load);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label labDescription;
    }
}