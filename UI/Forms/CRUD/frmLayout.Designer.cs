
namespace UI.Forms.CRUD
{
    partial class frmLayout
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
            this.cbxDeposit = new System.Windows.Forms.ComboBox();
            this.txtColumn = new System.Windows.Forms.TextBox();
            this.labColumn = new System.Windows.Forms.Label();
            this.labDeposit = new System.Windows.Forms.Label();
            this.cbxAisle = new System.Windows.Forms.ComboBox();
            this.labAisle = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.labRow = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.labDescription = new System.Windows.Forms.Label();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.txtDescription);
            this.bottomPanel.Controls.Add(this.labDescription);
            this.bottomPanel.Controls.Add(this.txtRow);
            this.bottomPanel.Controls.Add(this.labRow);
            this.bottomPanel.Controls.Add(this.cbxAisle);
            this.bottomPanel.Controls.Add(this.labAisle);
            this.bottomPanel.Controls.Add(this.cbxDeposit);
            this.bottomPanel.Controls.Add(this.txtColumn);
            this.bottomPanel.Controls.Add(this.labColumn);
            this.bottomPanel.Controls.Add(this.labDeposit);
            this.bottomPanel.Controls.SetChildIndex(this.btnSave, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnDelete, 0);
            this.bottomPanel.Controls.SetChildIndex(this.btnNew, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labDeposit, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labColumn, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtColumn, 0);
            this.bottomPanel.Controls.SetChildIndex(this.cbxDeposit, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labAisle, 0);
            this.bottomPanel.Controls.SetChildIndex(this.cbxAisle, 0);
            this.bottomPanel.Controls.SetChildIndex(this.labRow, 0);
            this.bottomPanel.Controls.SetChildIndex(this.txtRow, 0);
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
            // cbxDeposit
            // 
            this.cbxDeposit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxDeposit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxDeposit.FormattingEnabled = true;
            this.cbxDeposit.Location = new System.Drawing.Point(108, 26);
            this.cbxDeposit.Name = "cbxDeposit";
            this.cbxDeposit.Size = new System.Drawing.Size(181, 25);
            this.cbxDeposit.TabIndex = 17;
            // 
            // txtColumn
            // 
            this.txtColumn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtColumn.Location = new System.Drawing.Point(108, 91);
            this.txtColumn.Name = "txtColumn";
            this.txtColumn.Size = new System.Drawing.Size(181, 23);
            this.txtColumn.TabIndex = 16;
            // 
            // labColumn
            // 
            this.labColumn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labColumn.ForeColor = System.Drawing.Color.White;
            this.labColumn.Location = new System.Drawing.Point(21, 91);
            this.labColumn.Name = "labColumn";
            this.labColumn.Size = new System.Drawing.Size(82, 21);
            this.labColumn.TabIndex = 15;
            this.labColumn.Text = "Column";
            this.labColumn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labDeposit
            // 
            this.labDeposit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labDeposit.ForeColor = System.Drawing.Color.White;
            this.labDeposit.Location = new System.Drawing.Point(21, 26);
            this.labDeposit.Name = "labDeposit";
            this.labDeposit.Size = new System.Drawing.Size(82, 23);
            this.labDeposit.TabIndex = 14;
            this.labDeposit.Text = "Deposit";
            this.labDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxAisle
            // 
            this.cbxAisle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxAisle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxAisle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxAisle.FormattingEnabled = true;
            this.cbxAisle.Location = new System.Drawing.Point(433, 26);
            this.cbxAisle.Name = "cbxAisle";
            this.cbxAisle.Size = new System.Drawing.Size(181, 25);
            this.cbxAisle.TabIndex = 19;
            // 
            // labAisle
            // 
            this.labAisle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labAisle.ForeColor = System.Drawing.Color.White;
            this.labAisle.Location = new System.Drawing.Point(346, 26);
            this.labAisle.Name = "labAisle";
            this.labAisle.Size = new System.Drawing.Size(82, 23);
            this.labAisle.TabIndex = 18;
            this.labAisle.Text = "Aisle";
            this.labAisle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRow
            // 
            this.txtRow.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRow.Location = new System.Drawing.Point(433, 90);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(181, 23);
            this.txtRow.TabIndex = 21;
            // 
            // labRow
            // 
            this.labRow.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labRow.ForeColor = System.Drawing.Color.White;
            this.labRow.Location = new System.Drawing.Point(346, 90);
            this.labRow.Name = "labRow";
            this.labRow.Size = new System.Drawing.Size(82, 21);
            this.labRow.TabIndex = 20;
            this.labRow.Text = "Row";
            this.labRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescription.Location = new System.Drawing.Point(108, 153);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(181, 23);
            this.txtDescription.TabIndex = 23;
            // 
            // labDescription
            // 
            this.labDescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labDescription.ForeColor = System.Drawing.Color.White;
            this.labDescription.Location = new System.Drawing.Point(1, 153);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new System.Drawing.Size(105, 21);
            this.labDescription.TabIndex = 22;
            this.labDescription.Text = "Description";
            this.labDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLayout
            // 
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Name = "frmLayout";
            this.Text = "frmLayout";
            this.Load += new System.EventHandler(this.frmLayout_Load);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label labDescription;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.Label labRow;
        private System.Windows.Forms.ComboBox cbxAisle;
        private System.Windows.Forms.Label labAisle;
        private System.Windows.Forms.ComboBox cbxDeposit;
        private System.Windows.Forms.TextBox txtColumn;
        private System.Windows.Forms.Label labColumn;
        private System.Windows.Forms.Label labDeposit;
    }
}