namespace dataClean
{
    partial class frmFieldStat
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
            this.lstFieldStat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolTips = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblReplaceTo = new System.Windows.Forms.Label();
            this.txtReplaceTo = new System.Windows.Forms.TextBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.cbxConverter = new System.Windows.Forms.ComboBox();
            this.lblConverter = new System.Windows.Forms.Label();
            this.chkMultiKey = new System.Windows.Forms.CheckBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCrypt = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFieldStat
            // 
            this.lstFieldStat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFieldStat.CheckBoxes = true;
            this.lstFieldStat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.colValue,
            this.colCount,
            this.colHex});
            this.lstFieldStat.Location = new System.Drawing.Point(25, 38);
            this.lstFieldStat.Name = "lstFieldStat";
            this.lstFieldStat.OwnerDraw = true;
            this.lstFieldStat.Size = new System.Drawing.Size(1004, 383);
            this.lstFieldStat.TabIndex = 6;
            this.lstFieldStat.UseCompatibleStateImageBehavior = false;
            this.lstFieldStat.View = System.Windows.Forms.View.Details;
            this.lstFieldStat.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstFieldStat_ColumnClick);
            this.lstFieldStat.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstFieldStat_ColumnWidthChanging);
            this.lstFieldStat.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lstFieldStat_DrawColumnHeader);
            this.lstFieldStat.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstFieldStat_DrawItem);
            this.lstFieldStat.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lstFieldStat_DrawSubItem);
            this.lstFieldStat.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstFieldStat_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 50;
            // 
            // colValue
            // 
            this.colValue.Text = "待清洗";
            this.colValue.Width = 120;
            // 
            // colCount
            // 
            this.colCount.Text = "数量";
            this.colCount.Width = 80;
            // 
            // colHex
            // 
            this.colHex.Text = "hexdecimal";
            this.colHex.Width = 80;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTips});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1056, 22);
            this.statusStrip1.TabIndex = 7;
            // 
            // toolTips
            // 
            this.toolTips.Name = "toolTips";
            this.toolTips.Size = new System.Drawing.Size(0, 17);
            // 
            // lblReplaceTo
            // 
            this.lblReplaceTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReplaceTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblReplaceTo.Location = new System.Drawing.Point(583, 430);
            this.lblReplaceTo.Name = "lblReplaceTo";
            this.lblReplaceTo.Size = new System.Drawing.Size(47, 17);
            this.lblReplaceTo.TabIndex = 8;
            this.lblReplaceTo.Text = "替换成:";
            this.lblReplaceTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtReplaceTo
            // 
            this.txtReplaceTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplaceTo.Location = new System.Drawing.Point(636, 429);
            this.txtReplaceTo.Name = "txtReplaceTo";
            this.txtReplaceTo.Size = new System.Drawing.Size(393, 21);
            this.txtReplaceTo.TabIndex = 9;
            this.txtReplaceTo.TextChanged += new System.EventHandler(this.txtReplaceTo_TextChanged);
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSelected.Location = new System.Drawing.Point(23, 427);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(67, 23);
            this.lblSelected.TabIndex = 8;
            this.lblSelected.Text = "选中内容:";
            this.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSelected
            // 
            this.txtSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSelected.Location = new System.Drawing.Point(90, 427);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.Size = new System.Drawing.Size(182, 21);
            this.txtSelected.TabIndex = 9;
            this.txtSelected.TextChanged += new System.EventHandler(this.txtSelected_TextChanged);
            // 
            // cbxConverter
            // 
            this.cbxConverter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxConverter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConverter.FormattingEnabled = true;
            this.cbxConverter.Location = new System.Drawing.Point(315, 427);
            this.cbxConverter.Name = "cbxConverter";
            this.cbxConverter.Size = new System.Drawing.Size(161, 20);
            this.cbxConverter.TabIndex = 10;
            this.cbxConverter.SelectedIndexChanged += new System.EventHandler(this.cbxConverter_SelectedIndexChanged);
            // 
            // lblConverter
            // 
            this.lblConverter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConverter.Location = new System.Drawing.Point(278, 427);
            this.lblConverter.Name = "lblConverter";
            this.lblConverter.Size = new System.Drawing.Size(37, 17);
            this.lblConverter.TabIndex = 11;
            this.lblConverter.Text = "转码:";
            this.lblConverter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkMultiKey
            // 
            this.chkMultiKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMultiKey.AutoSize = true;
            this.chkMultiKey.Location = new System.Drawing.Point(489, 430);
            this.chkMultiKey.Name = "chkMultiKey";
            this.chkMultiKey.Size = new System.Drawing.Size(84, 16);
            this.chkMultiKey.TabIndex = 12;
            this.chkMultiKey.Text = "多键不同值";
            this.chkMultiKey.UseVisualStyleBackColor = true;
            this.chkMultiKey.CheckStateChanged += new System.EventHandler(this.chkMultiKey_CheckStateChanged);
            // 
            // lblFind
            // 
            this.lblFind.Location = new System.Drawing.Point(23, 14);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(35, 13);
            this.lblFind.TabIndex = 13;
            this.lblFind.Text = "快查";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(64, 11);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(296, 21);
            this.txtFind.TabIndex = 14;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(376, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "<==";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxCrypt
            // 
            this.cbxCrypt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCrypt.FormattingEnabled = true;
            this.cbxCrypt.Location = new System.Drawing.Point(421, 12);
            this.cbxCrypt.Name = "cbxCrypt";
            this.cbxCrypt.Size = new System.Drawing.Size(152, 20);
            this.cbxCrypt.TabIndex = 16;
            this.cbxCrypt.SelectedIndexChanged += new System.EventHandler(this.cbxCrypt_SelectedIndexChanged);
            // 
            // frmFieldStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 480);
            this.Controls.Add(this.cbxCrypt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.chkMultiKey);
            this.Controls.Add(this.lblConverter);
            this.Controls.Add(this.cbxConverter);
            this.Controls.Add(this.txtSelected);
            this.Controls.Add(this.txtReplaceTo);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblReplaceTo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstFieldStat);
            this.Name = "frmFieldStat";
            this.Text = "frmFieldStat";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ListView lstFieldStat;
        private System.Windows.Forms.Label lblReplaceTo;
        public System.Windows.Forms.TextBox txtReplaceTo;
        private System.Windows.Forms.ColumnHeader colHex;
        private System.Windows.Forms.ToolStripStatusLabel toolTips;
        private System.Windows.Forms.Label lblSelected;
        public System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.ComboBox cbxConverter;
        private System.Windows.Forms.Label lblConverter;
        public System.Windows.Forms.CheckBox chkMultiKey;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCrypt;
    }
}