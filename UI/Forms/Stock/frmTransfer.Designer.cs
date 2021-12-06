
namespace UI.Forms.Stock
{
    partial class frmTransfer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.originlab = new System.Windows.Forms.Label();
            this.destlab = new System.Windows.Forms.Label();
            this.origendg = new System.Windows.Forms.DataGridView();
            this.articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depositlab = new System.Windows.Forms.Label();
            this.depcbx = new System.Windows.Forms.ComboBox();
            this.palletlab = new System.Windows.Forms.Label();
            this.palletcb = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.destdg = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.origendg)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destdg)).BeginInit();
            this.SuspendLayout();
            // 
            // originlab
            // 
            this.originlab.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.originlab.ForeColor = System.Drawing.Color.White;
            this.originlab.Location = new System.Drawing.Point(170, 10);
            this.originlab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.originlab.Name = "originlab";
            this.originlab.Size = new System.Drawing.Size(149, 55);
            this.originlab.TabIndex = 0;
            this.originlab.Text = "Origen";
            this.originlab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // destlab
            // 
            this.destlab.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.destlab.ForeColor = System.Drawing.Color.White;
            this.destlab.Location = new System.Drawing.Point(93, 10);
            this.destlab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.destlab.Name = "destlab";
            this.destlab.Size = new System.Drawing.Size(293, 55);
            this.destlab.TabIndex = 1;
            this.destlab.Text = "Destino";
            this.destlab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // origendg
            // 
            this.origendg.AllowDrop = true;
            this.origendg.AllowUserToAddRows = false;
            this.origendg.AllowUserToDeleteRows = false;
            this.origendg.AllowUserToResizeRows = false;
            this.origendg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.origendg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.origendg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.origendg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.articulo,
            this.cantidad,
            this.estado});
            this.origendg.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.origendg.DefaultCellStyle = dataGridViewCellStyle4;
            this.origendg.Location = new System.Drawing.Point(4, 137);
            this.origendg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.origendg.MultiSelect = false;
            this.origendg.Name = "origendg";
            this.origendg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.origendg.Size = new System.Drawing.Size(456, 426);
            this.origendg.TabIndex = 2;
            this.origendg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.origendg_MouseDown);
            // 
            // articulo
            // 
            this.articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.articulo.DefaultCellStyle = dataGridViewCellStyle2;
            this.articulo.HeaderText = "";
            this.articulo.Name = "articulo";
            // 
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidad.HeaderText = "";
            this.cantidad.Name = "cantidad";
            this.cantidad.Width = 19;
            // 
            // estado
            // 
            this.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estado.HeaderText = "";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // depositlab
            // 
            this.depositlab.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.depositlab.ForeColor = System.Drawing.Color.White;
            this.depositlab.Location = new System.Drawing.Point(122, 77);
            this.depositlab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.depositlab.Name = "depositlab";
            this.depositlab.Size = new System.Drawing.Size(49, 40);
            this.depositlab.TabIndex = 4;
            this.depositlab.Text = "Dep";
            this.depositlab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // depcbx
            // 
            this.depcbx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.depcbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.depcbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.depcbx.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.depcbx.FormattingEnabled = true;
            this.depcbx.Location = new System.Drawing.Point(178, 80);
            this.depcbx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.depcbx.Name = "depcbx";
            this.depcbx.Size = new System.Drawing.Size(186, 28);
            this.depcbx.TabIndex = 7;
            this.depcbx.SelectedIndexChanged += new System.EventHandler(this.depcbx_SelectedIndexChanged);
            // 
            // palletlab
            // 
            this.palletlab.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.palletlab.ForeColor = System.Drawing.Color.White;
            this.palletlab.Location = new System.Drawing.Point(132, 76);
            this.palletlab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.palletlab.Name = "palletlab";
            this.palletlab.Size = new System.Drawing.Size(68, 40);
            this.palletlab.TabIndex = 11;
            this.palletlab.Text = "Pallet";
            this.palletlab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // palletcb
            // 
            this.palletcb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.palletcb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.palletcb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.palletcb.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.palletcb.FormattingEnabled = true;
            this.palletcb.Location = new System.Drawing.Point(207, 80);
            this.palletcb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.palletcb.Name = "palletcb";
            this.palletcb.Size = new System.Drawing.Size(140, 28);
            this.palletcb.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.depositlab);
            this.panel1.Controls.Add(this.origendg);
            this.panel1.Controls.Add(this.originlab);
            this.panel1.Controls.Add(this.depcbx);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 577);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.Controls.Add(this.destdg);
            this.panel2.Controls.Add(this.destlab);
            this.panel2.Controls.Add(this.palletcb);
            this.panel2.Controls.Add(this.palletlab);
            this.panel2.Location = new System.Drawing.Point(469, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 577);
            this.panel2.TabIndex = 14;
            // 
            // destdg
            // 
            this.destdg.AllowDrop = true;
            this.destdg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destdg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.destdg.Location = new System.Drawing.Point(12, 137);
            this.destdg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.destdg.Name = "destdg";
            this.destdg.Size = new System.Drawing.Size(440, 426);
            this.destdg.TabIndex = 10;
            this.destdg.DragDrop += new System.Windows.Forms.DragEventHandler(this.destdg_DragDrop);
            this.destdg.DragEnter += new System.Windows.Forms.DragEventHandler(this.destdg_DragEnter);
            // 
            // frmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(43)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(934, 577);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmTransfer";
            this.Text = "Transferencia";
            this.Load += new System.EventHandler(this.Transferenciafrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.origendg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.destdg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label originlab;
        private System.Windows.Forms.Label destlab;
        private System.Windows.Forms.DataGridView origendg;
        private System.Windows.Forms.Label depositlab;
        private System.Windows.Forms.ComboBox depcbx;
        private System.Windows.Forms.Label palletlab;
        private System.Windows.Forms.ComboBox palletcb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView destdg;
        private System.Windows.Forms.DataGridViewTextBoxColumn articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
    }
}