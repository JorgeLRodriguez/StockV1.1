
namespace UI.Forms.Stock
{
    partial class frmReception
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReception));
            this.clientlab = new System.Windows.Forms.Label();
            this.datelab = new System.Windows.Forms.Label();
            this.voucherPicker = new System.Windows.Forms.DateTimePicker();
            this.invlab = new System.Windows.Forms.Label();
            this.invdetdataGrid = new System.Windows.Forms.DataGridView();
            this.articlecbdg = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.quantitytxtdg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientcbx = new System.Windows.Forms.ComboBox();
            this.vouchertypelb = new System.Windows.Forms.Label();
            this.typetxt = new System.Windows.Forms.TextBox();
            this.letterlab = new System.Windows.Forms.Label();
            this.lettertxt = new System.Windows.Forms.TextBox();
            this.subsidiarytxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.leftpanel = new System.Windows.Forms.Panel();
            this.addbtn = new FontAwesome.Sharp.IconButton();
            this.btnclose = new System.Windows.Forms.PictureBox();
            this.remitotxt = new System.Windows.Forms.TextBox();
            this.panelright = new System.Windows.Forms.Panel();
            this.savebtn = new FontAwesome.Sharp.IconButton();
            this.deletebtn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.invdetdataGrid)).BeginInit();
            this.leftpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).BeginInit();
            this.panelright.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientlab
            // 
            this.clientlab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clientlab.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clientlab.ForeColor = System.Drawing.Color.White;
            this.clientlab.Location = new System.Drawing.Point(65, 113);
            this.clientlab.Name = "clientlab";
            this.clientlab.Size = new System.Drawing.Size(75, 27);
            this.clientlab.TabIndex = 2;
            this.clientlab.Text = "Cliente";
            // 
            // datelab
            // 
            this.datelab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datelab.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.datelab.ForeColor = System.Drawing.Color.White;
            this.datelab.Location = new System.Drawing.Point(65, 158);
            this.datelab.Name = "datelab";
            this.datelab.Size = new System.Drawing.Size(71, 27);
            this.datelab.TabIndex = 4;
            this.datelab.Text = "Fecha";
            // 
            // voucherPicker
            // 
            this.voucherPicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.voucherPicker.CalendarFont = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.voucherPicker.CalendarForeColor = System.Drawing.Color.MediumSpringGreen;
            this.voucherPicker.CalendarMonthBackground = System.Drawing.Color.Maroon;
            this.voucherPicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(26)))), ((int)(((byte)(14)))));
            this.voucherPicker.CalendarTitleForeColor = System.Drawing.Color.SeaShell;
            this.voucherPicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.voucherPicker.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.voucherPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.voucherPicker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.voucherPicker.Location = new System.Drawing.Point(146, 154);
            this.voucherPicker.Name = "voucherPicker";
            this.voucherPicker.Size = new System.Drawing.Size(208, 27);
            this.voucherPicker.TabIndex = 6;
            // 
            // invlab
            // 
            this.invlab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.invlab.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.invlab.ForeColor = System.Drawing.Color.White;
            this.invlab.Location = new System.Drawing.Point(65, 196);
            this.invlab.Name = "invlab";
            this.invlab.Size = new System.Drawing.Size(98, 23);
            this.invlab.TabIndex = 7;
            this.invlab.Text = "Remito #";
            // 
            // invdetdataGrid
            // 
            this.invdetdataGrid.AllowUserToAddRows = false;
            this.invdetdataGrid.AllowUserToDeleteRows = false;
            this.invdetdataGrid.AllowUserToOrderColumns = true;
            this.invdetdataGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.invdetdataGrid.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.invdetdataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.invdetdataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.invdetdataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.articlecbdg,
            this.quantitytxtdg});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.invdetdataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.invdetdataGrid.GridColor = System.Drawing.Color.White;
            this.invdetdataGrid.Location = new System.Drawing.Point(29, 52);
            this.invdetdataGrid.MultiSelect = false;
            this.invdetdataGrid.Name = "invdetdataGrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.invdetdataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.invdetdataGrid.Size = new System.Drawing.Size(403, 468);
            this.invdetdataGrid.TabIndex = 9;
            // 
            // articlecbdg
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.articlecbdg.DefaultCellStyle = dataGridViewCellStyle2;
            this.articlecbdg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.articlecbdg.HeaderText = "";
            this.articlecbdg.Name = "articlecbdg";
            this.articlecbdg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.articlecbdg.Width = 210;
            // 
            // quantitytxtdg
            // 
            this.quantitytxtdg.HeaderText = "";
            this.quantitytxtdg.Name = "quantitytxtdg";
            this.quantitytxtdg.Width = 150;
            // 
            // clientcbx
            // 
            this.clientcbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clientcbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientcbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientcbx.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clientcbx.FormattingEnabled = true;
            this.clientcbx.Location = new System.Drawing.Point(146, 111);
            this.clientcbx.Name = "clientcbx";
            this.clientcbx.Size = new System.Drawing.Size(208, 29);
            this.clientcbx.TabIndex = 11;
            this.clientcbx.SelectedIndexChanged += new System.EventHandler(this.Clientcbx_SelectedIndexChanged);
            // 
            // vouchertypelb
            // 
            this.vouchertypelb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vouchertypelb.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.vouchertypelb.ForeColor = System.Drawing.Color.White;
            this.vouchertypelb.Location = new System.Drawing.Point(65, 67);
            this.vouchertypelb.Name = "vouchertypelb";
            this.vouchertypelb.Size = new System.Drawing.Size(59, 27);
            this.vouchertypelb.TabIndex = 14;
            this.vouchertypelb.Text = "Tipo:";
            // 
            // typetxt
            // 
            this.typetxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.typetxt.Enabled = false;
            this.typetxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.typetxt.Location = new System.Drawing.Point(122, 67);
            this.typetxt.Name = "typetxt";
            this.typetxt.Size = new System.Drawing.Size(56, 27);
            this.typetxt.TabIndex = 15;
            this.typetxt.Text = "SIR";
            this.typetxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // letterlab
            // 
            this.letterlab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.letterlab.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.letterlab.ForeColor = System.Drawing.Color.White;
            this.letterlab.Location = new System.Drawing.Point(181, 67);
            this.letterlab.Name = "letterlab";
            this.letterlab.Size = new System.Drawing.Size(73, 27);
            this.letterlab.TabIndex = 16;
            this.letterlab.Text = "Letra:";
            // 
            // lettertxt
            // 
            this.lettertxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lettertxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lettertxt.Location = new System.Drawing.Point(257, 67);
            this.lettertxt.Name = "lettertxt";
            this.lettertxt.Size = new System.Drawing.Size(42, 27);
            this.lettertxt.TabIndex = 17;
            this.lettertxt.Text = "X";
            this.lettertxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // subsidiarytxt
            // 
            this.subsidiarytxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subsidiarytxt.Enabled = false;
            this.subsidiarytxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subsidiarytxt.Location = new System.Drawing.Point(329, 67);
            this.subsidiarytxt.Name = "subsidiarytxt";
            this.subsidiarytxt.Size = new System.Drawing.Size(25, 27);
            this.subsidiarytxt.TabIndex = 18;
            this.subsidiarytxt.Text = "01";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(306, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 27);
            this.label1.TabIndex = 19;
            this.label1.Text = "-";
            // 
            // leftpanel
            // 
            this.leftpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftpanel.Controls.Add(this.deletebtn);
            this.leftpanel.Controls.Add(this.savebtn);
            this.leftpanel.Controls.Add(this.addbtn);
            this.leftpanel.Controls.Add(this.btnclose);
            this.leftpanel.Controls.Add(this.remitotxt);
            this.leftpanel.Controls.Add(this.letterlab);
            this.leftpanel.Controls.Add(this.lettertxt);
            this.leftpanel.Controls.Add(this.clientlab);
            this.leftpanel.Controls.Add(this.typetxt);
            this.leftpanel.Controls.Add(this.datelab);
            this.leftpanel.Controls.Add(this.subsidiarytxt);
            this.leftpanel.Controls.Add(this.vouchertypelb);
            this.leftpanel.Controls.Add(this.voucherPicker);
            this.leftpanel.Controls.Add(this.label1);
            this.leftpanel.Controls.Add(this.clientcbx);
            this.leftpanel.Controls.Add(this.invlab);
            this.leftpanel.Location = new System.Drawing.Point(12, 12);
            this.leftpanel.Name = "leftpanel";
            this.leftpanel.Size = new System.Drawing.Size(456, 553);
            this.leftpanel.TabIndex = 20;
            // 
            // addbtn
            // 
            this.addbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbtn.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.addbtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addbtn.ForeColor = System.Drawing.Color.White;
            this.addbtn.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.addbtn.IconColor = System.Drawing.Color.White;
            this.addbtn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.addbtn.IconSize = 40;
            this.addbtn.Location = new System.Drawing.Point(161, 264);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(135, 45);
            this.addbtn.TabIndex = 23;
            this.addbtn.Text = "Agregar";
            this.addbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addbtn.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.Image")));
            this.btnclose.Location = new System.Drawing.Point(3, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(15, 15);
            this.btnclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnclose.TabIndex = 22;
            this.btnclose.TabStop = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // remitotxt
            // 
            this.remitotxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.remitotxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remitotxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.remitotxt.Location = new System.Drawing.Point(161, 195);
            this.remitotxt.MaxLength = 11;
            this.remitotxt.Name = "remitotxt";
            this.remitotxt.Size = new System.Drawing.Size(193, 27);
            this.remitotxt.TabIndex = 21;
            // 
            // panelright
            // 
            this.panelright.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelright.Controls.Add(this.invdetdataGrid);
            this.panelright.Location = new System.Drawing.Point(474, 12);
            this.panelright.Name = "panelright";
            this.panelright.Size = new System.Drawing.Size(460, 553);
            this.panelright.TabIndex = 21;
            // 
            // savebtn
            // 
            this.savebtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.savebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebtn.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.savebtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.savebtn.ForeColor = System.Drawing.Color.White;
            this.savebtn.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.savebtn.IconColor = System.Drawing.Color.White;
            this.savebtn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.savebtn.IconSize = 40;
            this.savebtn.Location = new System.Drawing.Point(161, 331);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(135, 45);
            this.savebtn.TabIndex = 24;
            this.savebtn.Text = "Guardar";
            this.savebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.savebtn.UseVisualStyleBackColor = true;
            // 
            // deletebtn
            // 
            this.deletebtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deletebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletebtn.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.deletebtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deletebtn.ForeColor = System.Drawing.Color.White;
            this.deletebtn.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.deletebtn.IconColor = System.Drawing.Color.White;
            this.deletebtn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.deletebtn.IconSize = 40;
            this.deletebtn.Location = new System.Drawing.Point(161, 397);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(135, 45);
            this.deletebtn.TabIndex = 25;
            this.deletebtn.Text = "Eliminar";
            this.deletebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deletebtn.UseVisualStyleBackColor = true;
            // 
            // frmReception
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(26)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Controls.Add(this.panelright);
            this.Controls.Add(this.leftpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReception";
            this.Text = "Recepcionfrm";
            this.Load += new System.EventHandler(this.Recepcionfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.invdetdataGrid)).EndInit();
            this.leftpanel.ResumeLayout(false);
            this.leftpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).EndInit();
            this.panelright.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label clientlab;
        private System.Windows.Forms.Label datelab;
        private System.Windows.Forms.DateTimePicker voucherPicker;
        private System.Windows.Forms.Label invlab;
        private System.Windows.Forms.DataGridView invdetdataGrid;
        private System.Windows.Forms.Label vouchertypelb;
        private System.Windows.Forms.TextBox typetxt;
        private System.Windows.Forms.Label letterlab;
        private System.Windows.Forms.TextBox lettertxt;
        private System.Windows.Forms.TextBox subsidiarytxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel leftpanel;
        private System.Windows.Forms.Panel panelright;
        private System.Windows.Forms.ComboBox clientcbx;
        private System.Windows.Forms.DataGridViewComboBoxColumn articlecbdg;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantitytxtdg;
        private System.Windows.Forms.TextBox remitotxt;
        private System.Windows.Forms.PictureBox btnclose;
        private FontAwesome.Sharp.IconButton addbtn;
        private FontAwesome.Sharp.IconButton deletebtn;
        private FontAwesome.Sharp.IconButton savebtn;
    }
}