
namespace UI.Forms
{
    partial class frmLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            this.leftpanel = new System.Windows.Forms.Panel();
            this.mainiconpic = new System.Windows.Forms.PictureBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpsw = new System.Windows.Forms.TextBox();
            this.lablogin = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.usrlab = new System.Windows.Forms.Label();
            this.pswlab = new System.Windows.Forms.Label();
            this.leftpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainiconpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // leftpanel
            // 
            this.leftpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(26)))), ((int)(((byte)(14)))));
            this.leftpanel.Controls.Add(this.mainiconpic);
            this.leftpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftpanel.Location = new System.Drawing.Point(0, 0);
            this.leftpanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.leftpanel.Name = "leftpanel";
            this.leftpanel.Size = new System.Drawing.Size(292, 381);
            this.leftpanel.TabIndex = 0;
            // 
            // mainiconpic
            // 
            this.mainiconpic.Image = ((System.Drawing.Image)(resources.GetObject("mainiconpic.Image")));
            this.mainiconpic.Location = new System.Drawing.Point(66, 114);
            this.mainiconpic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainiconpic.Name = "mainiconpic";
            this.mainiconpic.Size = new System.Drawing.Size(159, 138);
            this.mainiconpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainiconpic.TabIndex = 0;
            this.mainiconpic.TabStop = false;
            // 
            // txtuser
            // 
            this.txtuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtuser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtuser.ForeColor = System.Drawing.Color.White;
            this.txtuser.Location = new System.Drawing.Point(463, 115);
            this.txtuser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(396, 19);
            this.txtuser.TabIndex = 1;
            // 
            // txtpsw
            // 
            this.txtpsw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtpsw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpsw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtpsw.ForeColor = System.Drawing.Color.White;
            this.txtpsw.Location = new System.Drawing.Point(466, 194);
            this.txtpsw.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtpsw.Name = "txtpsw";
            this.txtpsw.PasswordChar = '♦';
            this.txtpsw.Size = new System.Drawing.Size(393, 19);
            this.txtpsw.TabIndex = 2;
            // 
            // lablogin
            // 
            this.lablogin.AutoSize = true;
            this.lablogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lablogin.ForeColor = System.Drawing.Color.DimGray;
            this.lablogin.Location = new System.Drawing.Point(523, 23);
            this.lablogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lablogin.Name = "lablogin";
            this.lablogin.Size = new System.Drawing.Size(157, 46);
            this.lablogin.TabIndex = 0;
            this.lablogin.Text = "STOCK";
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogin.FlatAppearance.BorderSize = 0;
            this.btnlogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnlogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Location = new System.Drawing.Point(349, 270);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(507, 57);
            this.btnlogin.TabIndex = 0;
            this.btnlogin.Text = "Ingresar";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // btnclose
            // 
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(889, 3);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(18, 17);
            this.btnclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnclose.TabIndex = 5;
            this.btnclose.TabStop = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(864, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // usrlab
            // 
            this.usrlab.AutoSize = true;
            this.usrlab.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usrlab.ForeColor = System.Drawing.Color.White;
            this.usrlab.Location = new System.Drawing.Point(373, 114);
            this.usrlab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usrlab.Name = "usrlab";
            this.usrlab.Size = new System.Drawing.Size(70, 21);
            this.usrlab.TabIndex = 7;
            this.usrlab.Text = "Usuario:";
            this.usrlab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pswlab
            // 
            this.pswlab.AutoSize = true;
            this.pswlab.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pswlab.ForeColor = System.Drawing.Color.White;
            this.pswlab.Location = new System.Drawing.Point(345, 194);
            this.pswlab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pswlab.Name = "pswlab";
            this.pswlab.Size = new System.Drawing.Size(107, 21);
            this.pswlab.TabIndex = 8;
            this.pswlab.Text = "Contraseña:";
            this.pswlab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LogIn
            // 
            this.AcceptButton = this.btnlogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(910, 381);
            this.Controls.Add(this.pswlab);
            this.Controls.Add(this.usrlab);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.lablogin);
            this.Controls.Add(this.txtpsw);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.leftpanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LogIn";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.leftpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainiconpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel leftpanel;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.PictureBox mainiconpic;
        private System.Windows.Forms.TextBox txtpsw;
        private System.Windows.Forms.Label lablogin;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.PictureBox btnclose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label usrlab;
        private System.Windows.Forms.Label pswlab;
    }
}