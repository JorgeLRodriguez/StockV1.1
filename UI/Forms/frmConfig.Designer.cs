
namespace UI.Forms
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.btnLanguage = new FontAwesome.Sharp.IconButton();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            this.btnDbSettings = new FontAwesome.Sharp.IconButton();
            this.btnRol = new FontAwesome.Sharp.IconButton();
            this.btnManUser = new FontAwesome.Sharp.IconButton();
            this.btnLog = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLanguage
            // 
            this.btnLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLanguage.FlatAppearance.BorderSize = 0;
            this.btnLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLanguage.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLanguage.ForeColor = System.Drawing.Color.White;
            this.btnLanguage.IconChar = FontAwesome.Sharp.IconChar.GlobeAmericas;
            this.btnLanguage.IconColor = System.Drawing.Color.White;
            this.btnLanguage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLanguage.IconSize = 40;
            this.btnLanguage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLanguage.Location = new System.Drawing.Point(12, 33);
            this.btnLanguage.MaximumSize = new System.Drawing.Size(225, 45);
            this.btnLanguage.MinimumSize = new System.Drawing.Size(225, 45);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnLanguage.Size = new System.Drawing.Size(225, 45);
            this.btnLanguage.TabIndex = 5;
            this.btnLanguage.Text = "Idioma";
            this.btnLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLanguage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLanguage.UseVisualStyleBackColor = true;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(12, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(15, 15);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 23;
            this.btnClose.TabStop = false;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btnDbSettings);
            this.panel.Controls.Add(this.btnRol);
            this.panel.Controls.Add(this.btnManUser);
            this.panel.Controls.Add(this.btnLog);
            this.panel.Controls.Add(this.btnLanguage);
            this.panel.Controls.Add(this.btnClose);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1090, 550);
            this.panel.TabIndex = 26;
            // 
            // btnDbSettings
            // 
            this.btnDbSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDbSettings.FlatAppearance.BorderSize = 0;
            this.btnDbSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbSettings.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDbSettings.ForeColor = System.Drawing.Color.White;
            this.btnDbSettings.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnDbSettings.IconColor = System.Drawing.Color.White;
            this.btnDbSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDbSettings.IconSize = 40;
            this.btnDbSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDbSettings.Location = new System.Drawing.Point(12, 237);
            this.btnDbSettings.MaximumSize = new System.Drawing.Size(225, 45);
            this.btnDbSettings.MinimumSize = new System.Drawing.Size(225, 45);
            this.btnDbSettings.Name = "btnDbSettings";
            this.btnDbSettings.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnDbSettings.Size = new System.Drawing.Size(225, 45);
            this.btnDbSettings.TabIndex = 29;
            this.btnDbSettings.Text = "Backup / Restore";
            this.btnDbSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDbSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDbSettings.UseVisualStyleBackColor = true;
            this.btnDbSettings.Click += new System.EventHandler(this.btnDbSettings_Click);
            // 
            // btnRol
            // 
            this.btnRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRol.FlatAppearance.BorderSize = 0;
            this.btnRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRol.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRol.ForeColor = System.Drawing.Color.White;
            this.btnRol.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt;
            this.btnRol.IconColor = System.Drawing.Color.White;
            this.btnRol.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRol.IconSize = 40;
            this.btnRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRol.Location = new System.Drawing.Point(12, 186);
            this.btnRol.MaximumSize = new System.Drawing.Size(225, 45);
            this.btnRol.MinimumSize = new System.Drawing.Size(225, 45);
            this.btnRol.Name = "btnRol";
            this.btnRol.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnRol.Size = new System.Drawing.Size(225, 45);
            this.btnRol.TabIndex = 28;
            this.btnRol.Text = "Administrar Roles";
            this.btnRol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRol.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRol.UseVisualStyleBackColor = true;
            // 
            // btnManUser
            // 
            this.btnManUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManUser.FlatAppearance.BorderSize = 0;
            this.btnManUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManUser.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnManUser.ForeColor = System.Drawing.Color.White;
            this.btnManUser.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.btnManUser.IconColor = System.Drawing.Color.White;
            this.btnManUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnManUser.IconSize = 40;
            this.btnManUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManUser.Location = new System.Drawing.Point(12, 135);
            this.btnManUser.MaximumSize = new System.Drawing.Size(225, 45);
            this.btnManUser.MinimumSize = new System.Drawing.Size(225, 45);
            this.btnManUser.Name = "btnManUser";
            this.btnManUser.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnManUser.Size = new System.Drawing.Size(225, 45);
            this.btnManUser.TabIndex = 27;
            this.btnManUser.Text = "Administrar Usuario";
            this.btnManUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManUser.UseVisualStyleBackColor = true;
            // 
            // btnLog
            // 
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLog.ForeColor = System.Drawing.Color.White;
            this.btnLog.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.btnLog.IconColor = System.Drawing.Color.White;
            this.btnLog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLog.IconSize = 40;
            this.btnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.Location = new System.Drawing.Point(12, 84);
            this.btnLog.MaximumSize = new System.Drawing.Size(225, 45);
            this.btnLog.MinimumSize = new System.Drawing.Size(225, 45);
            this.btnLog.Name = "btnLog";
            this.btnLog.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnLog.Size = new System.Drawing.Size(225, 45);
            this.btnLog.TabIndex = 26;
            this.btnLog.Text = "Bitacora";
            this.btnLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLog.UseVisualStyleBackColor = true;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(26)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(1090, 550);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmConfig";
            this.Text = "frmConfig";
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnLanguage;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Panel panel;
        private FontAwesome.Sharp.IconButton btnDbSettings;
        private FontAwesome.Sharp.IconButton btnRol;
        private FontAwesome.Sharp.IconButton btnManUser;
        private FontAwesome.Sharp.IconButton btnLog;
    }
}