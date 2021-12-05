
namespace UI.Forms.Stock
{
    partial class frmImport
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
            this.impbtn = new FontAwesome.Sharp.IconButton();
            this.csvdg = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.savebtn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.csvdg)).BeginInit();
            this.SuspendLayout();
            // 
            // impbtn
            // 
            this.impbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.impbtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.impbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.impbtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.impbtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.impbtn.ForeColor = System.Drawing.Color.White;
            this.impbtn.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.impbtn.IconColor = System.Drawing.Color.White;
            this.impbtn.IconSize = 27;
            this.impbtn.Location = new System.Drawing.Point(60, 12);
            this.impbtn.Name = "impbtn";
            this.impbtn.Rotation = 0D;
            this.impbtn.Size = new System.Drawing.Size(117, 33);
            this.impbtn.TabIndex = 0;
            this.impbtn.Text = "Importar";
            this.impbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.impbtn.UseVisualStyleBackColor = true;
            this.impbtn.Click += new System.EventHandler(this.impbtn_Click);
            // 
            // csvdg
            // 
            this.csvdg.AllowUserToAddRows = false;
            this.csvdg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.csvdg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csvdg.Location = new System.Drawing.Point(24, 64);
            this.csvdg.Name = "csvdg";
            this.csvdg.Size = new System.Drawing.Size(885, 486);
            this.csvdg.TabIndex = 1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // savebtn
            // 
            this.savebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.savebtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.savebtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.ForeColor = System.Drawing.Color.White;
            this.savebtn.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.savebtn.IconColor = System.Drawing.Color.White;
            this.savebtn.IconSize = 27;
            this.savebtn.Location = new System.Drawing.Point(206, 12);
            this.savebtn.Name = "savebtn";
            this.savebtn.Rotation = 0D;
            this.savebtn.Size = new System.Drawing.Size(117, 33);
            this.savebtn.TabIndex = 2;
            this.savebtn.Text = "Guardar";
            this.savebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // Importarfrm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(43)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.csvdg);
            this.Controls.Add(this.impbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmImport";
            this.Text = "Importarfrm";
            ((System.ComponentModel.ISupportInitialize)(this.csvdg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton impbtn;
        private System.Windows.Forms.DataGridView csvdg;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private FontAwesome.Sharp.IconButton savebtn;
    }
}