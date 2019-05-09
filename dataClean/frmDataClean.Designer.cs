namespace dataClean
{
    partial class frmDataClean
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpFrame = new System.Windows.Forms.GroupBox();
            this.btnConfigCustom = new System.Windows.Forms.Button();
            this.lblReplacement = new System.Windows.Forms.Label();
            this.lblCustom = new System.Windows.Forms.Label();
            this.cbxCustomPayload = new System.Windows.Forms.ComboBox();
            this.enableFullMatch = new System.Windows.Forms.CheckBox();
            this.txtReplacement = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbxStat = new System.Windows.Forms.CheckBox();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.lblCondition = new System.Windows.Forms.Label();
            this.btnExportTable = new System.Windows.Forms.Button();
            this.btnFieldStat = new System.Windows.Forms.Button();
            this.lstFields = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExec = new System.Windows.Forms.Button();
            this.btnMongo2Mysql = new System.Windows.Forms.Button();
            this.btnMysql2Mongo = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cbxTable = new System.Windows.Forms.ComboBox();
            this.cbxSchema = new System.Windows.Forms.ComboBox();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPasswd = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblSchema = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tooltip = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpFrame.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFrame
            // 
            this.grpFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFrame.Controls.Add(this.btnConfigCustom);
            this.grpFrame.Controls.Add(this.lblReplacement);
            this.grpFrame.Controls.Add(this.lblCustom);
            this.grpFrame.Controls.Add(this.cbxCustomPayload);
            this.grpFrame.Controls.Add(this.enableFullMatch);
            this.grpFrame.Controls.Add(this.txtReplacement);
            this.grpFrame.Controls.Add(this.lblCategory);
            this.grpFrame.Controls.Add(this.cbxCategory);
            this.grpFrame.Controls.Add(this.tabPage);
            this.grpFrame.Location = new System.Drawing.Point(12, 12);
            this.grpFrame.Name = "grpFrame";
            this.grpFrame.Size = new System.Drawing.Size(845, 615);
            this.grpFrame.TabIndex = 0;
            this.grpFrame.TabStop = false;
            this.grpFrame.Text = "配置数据源";
            // 
            // btnConfigCustom
            // 
            this.btnConfigCustom.Location = new System.Drawing.Point(772, 14);
            this.btnConfigCustom.Name = "btnConfigCustom";
            this.btnConfigCustom.Size = new System.Drawing.Size(59, 23);
            this.btnConfigCustom.TabIndex = 5;
            this.btnConfigCustom.Text = "配置(&C)";
            this.btnConfigCustom.UseVisualStyleBackColor = true;
            this.btnConfigCustom.Click += new System.EventHandler(this.btnConfigCustom_Click);
            // 
            // lblReplacement
            // 
            this.lblReplacement.AutoSize = true;
            this.lblReplacement.Location = new System.Drawing.Point(615, 19);
            this.lblReplacement.Name = "lblReplacement";
            this.lblReplacement.Size = new System.Drawing.Size(47, 12);
            this.lblReplacement.TabIndex = 9;
            this.lblReplacement.Text = "替换成:";
            // 
            // lblCustom
            // 
            this.lblCustom.Location = new System.Drawing.Point(344, 17);
            this.lblCustom.Name = "lblCustom";
            this.lblCustom.Size = new System.Drawing.Size(73, 16);
            this.lblCustom.TabIndex = 8;
            this.lblCustom.Text = "预处理内容:";
            this.lblCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxCustomPayload
            // 
            this.cbxCustomPayload.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCustomPayload.Location = new System.Drawing.Point(668, 15);
            this.cbxCustomPayload.Name = "cbxCustomPayload";
            this.cbxCustomPayload.Size = new System.Drawing.Size(90, 20);
            this.cbxCustomPayload.TabIndex = 0;
            this.cbxCustomPayload.TextChanged += new System.EventHandler(this.cbxReplacement_TextChanged);
            // 
            // enableFullMatch
            // 
            this.enableFullMatch.AutoSize = true;
            this.enableFullMatch.Checked = true;
            this.enableFullMatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableFullMatch.Location = new System.Drawing.Point(538, 17);
            this.enableFullMatch.Name = "enableFullMatch";
            this.enableFullMatch.Size = new System.Drawing.Size(72, 16);
            this.enableFullMatch.TabIndex = 7;
            this.enableFullMatch.Text = "完全匹配";
            this.enableFullMatch.UseVisualStyleBackColor = true;
            // 
            // txtReplacement
            // 
            this.txtReplacement.Location = new System.Drawing.Point(420, 14);
            this.txtReplacement.Name = "txtReplacement";
            this.txtReplacement.Size = new System.Drawing.Size(100, 21);
            this.txtReplacement.TabIndex = 6;
            this.txtReplacement.TextChanged += new System.EventHandler(this.txtReplacement_TextChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(144, 17);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(62, 16);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "清洗类型:";
            // 
            // cbxCategory
            // 
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(212, 14);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(121, 20);
            this.cbxCategory.TabIndex = 5;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // tabPage
            // 
            this.tabPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage.Controls.Add(this.tabPage1);
            this.tabPage.Controls.Add(this.tabPage2);
            this.tabPage.Location = new System.Drawing.Point(18, 20);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(813, 575);
            this.tabPage.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbxStat);
            this.tabPage1.Controls.Add(this.txtCondition);
            this.tabPage1.Controls.Add(this.lblCondition);
            this.tabPage1.Controls.Add(this.btnExportTable);
            this.tabPage1.Controls.Add(this.btnFieldStat);
            this.tabPage1.Controls.Add(this.lstFields);
            this.tabPage1.Controls.Add(this.btnExec);
            this.tabPage1.Controls.Add(this.btnMongo2Mysql);
            this.tabPage1.Controls.Add(this.btnMysql2Mongo);
            this.tabPage1.Controls.Add(this.btnLoad);
            this.tabPage1.Controls.Add(this.cbxTable);
            this.tabPage1.Controls.Add(this.cbxSchema);
            this.tabPage1.Controls.Add(this.txtPasswd);
            this.tabPage1.Controls.Add(this.txtUser);
            this.tabPage1.Controls.Add(this.lblPasswd);
            this.tabPage1.Controls.Add(this.txtPort);
            this.tabPage1.Controls.Add(this.lblUser);
            this.tabPage1.Controls.Add(this.txtHost);
            this.tabPage1.Controls.Add(this.lblSchema);
            this.tabPage1.Controls.Add(this.lblPort);
            this.tabPage1.Controls.Add(this.lblHost);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(805, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MySQL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbxStat
            // 
            this.cbxStat.Location = new System.Drawing.Point(8, 52);
            this.cbxStat.Name = "cbxStat";
            this.cbxStat.Size = new System.Drawing.Size(25, 18);
            this.cbxStat.TabIndex = 9;
            this.cbxStat.Text = "Y";
            this.cbxStat.UseVisualStyleBackColor = true;
            this.cbxStat.CheckStateChanged += new System.EventHandler(this.cbxStat_CheckStateChanged);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(349, 50);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(421, 21);
            this.txtCondition.TabIndex = 8;
            // 
            // lblCondition
            // 
            this.lblCondition.Location = new System.Drawing.Point(288, 53);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(59, 17);
            this.lblCondition.TabIndex = 7;
            this.lblCondition.Text = "查询条件:";
            this.lblCondition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportTable
            // 
            this.btnExportTable.Location = new System.Drawing.Point(174, 49);
            this.btnExportTable.Name = "btnExportTable";
            this.btnExportTable.Size = new System.Drawing.Size(103, 23);
            this.btnExportTable.TabIndex = 6;
            this.btnExportTable.Text = "快速导出表(&E)";
            this.btnExportTable.UseVisualStyleBackColor = true;
            this.btnExportTable.Click += new System.EventHandler(this.btnExportTable_Click);
            // 
            // btnFieldStat
            // 
            this.btnFieldStat.Location = new System.Drawing.Point(35, 49);
            this.btnFieldStat.Name = "btnFieldStat";
            this.btnFieldStat.Size = new System.Drawing.Size(105, 23);
            this.btnFieldStat.TabIndex = 5;
            this.btnFieldStat.Text = "字段分析统计(&S)";
            this.btnFieldStat.UseVisualStyleBackColor = true;
            this.btnFieldStat.Click += new System.EventHandler(this.btnFieldStat_Click);
            // 
            // lstFields
            // 
            this.lstFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFields.CheckBoxes = true;
            this.lstFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.colField,
            this.colType,
            this.colLength});
            this.lstFields.Location = new System.Drawing.Point(31, 108);
            this.lstFields.Name = "lstFields";
            this.lstFields.OwnerDraw = true;
            this.lstFields.Size = new System.Drawing.Size(740, 420);
            this.lstFields.TabIndex = 4;
            this.lstFields.UseCompatibleStateImageBehavior = false;
            this.lstFields.View = System.Windows.Forms.View.Details;
            this.lstFields.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstFields_ColumnClick);
            this.lstFields.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstFields_ColumnWidthChanging);
            this.lstFields.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lstFields_DrawColumnHeader);
            this.lstFields.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstFields_DrawItem);
            this.lstFields.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lstFields_DrawSubItem);
            this.lstFields.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstFields_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // colField
            // 
            this.colField.Text = "列名";
            this.colField.Width = 240;
            // 
            // colType
            // 
            this.colType.Text = "类型";
            this.colType.Width = 120;
            // 
            // colLength
            // 
            this.colLength.Text = "长度";
            this.colLength.Width = 80;
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(435, 78);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 3;
            this.btnExec.Text = "更新(&U)";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // btnMongo2Mysql
            // 
            this.btnMongo2Mysql.Location = new System.Drawing.Point(658, 78);
            this.btnMongo2Mysql.Name = "btnMongo2Mysql";
            this.btnMongo2Mysql.Size = new System.Drawing.Size(115, 23);
            this.btnMongo2Mysql.TabIndex = 3;
            this.btnMongo2Mysql.Text = "mongodb导mysql(&G)";
            this.btnMongo2Mysql.UseVisualStyleBackColor = true;
            this.btnMongo2Mysql.Click += new System.EventHandler(this.btnMongo2Mysql_Click);
            // 
            // btnMysql2Mongo
            // 
            this.btnMysql2Mongo.Location = new System.Drawing.Point(524, 78);
            this.btnMysql2Mongo.Name = "btnMysql2Mongo";
            this.btnMysql2Mongo.Size = new System.Drawing.Size(123, 23);
            this.btnMysql2Mongo.TabIndex = 3;
            this.btnMysql2Mongo.Text = "mysql导Mongodb(&M)";
            this.btnMysql2Mongo.UseVisualStyleBackColor = true;
            this.btnMysql2Mongo.Click += new System.EventHandler(this.btnMysql2Mongo_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(349, 78);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "读取(&R)";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // cbxTable
            // 
            this.cbxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTable.FormattingEnabled = true;
            this.cbxTable.Location = new System.Drawing.Point(559, 11);
            this.cbxTable.Name = "cbxTable";
            this.cbxTable.Size = new System.Drawing.Size(230, 20);
            this.cbxTable.TabIndex = 2;
            this.cbxTable.SelectedIndexChanged += new System.EventHandler(this.onTableChanged);
            this.cbxTable.TextChanged += new System.EventHandler(this.onTableChanged);
            // 
            // cbxSchema
            // 
            this.cbxSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSchema.FormattingEnabled = true;
            this.cbxSchema.Location = new System.Drawing.Point(317, 11);
            this.cbxSchema.Name = "cbxSchema";
            this.cbxSchema.Size = new System.Drawing.Size(229, 20);
            this.cbxSchema.TabIndex = 2;
            this.cbxSchema.SelectedIndexChanged += new System.EventHandler(this.OnSchemaChanged);
            this.cbxSchema.TextChanged += new System.EventHandler(this.OnSchemaChanged);
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(217, 76);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Size = new System.Drawing.Size(110, 21);
            this.txtPasswd.TabIndex = 1;
            this.txtPasswd.Text = "root";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(98, 78);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(57, 21);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "root";
            // 
            // lblPasswd
            // 
            this.lblPasswd.Location = new System.Drawing.Point(176, 81);
            this.lblPasswd.Name = "lblPasswd";
            this.lblPasswd.Size = new System.Drawing.Size(35, 16);
            this.lblPasswd.TabIndex = 0;
            this.lblPasswd.Text = "密码:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(231, 14);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(40, 21);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "3306";
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(46, 81);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(35, 16);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "账号:";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(98, 14);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(88, 21);
            this.txtHost.TabIndex = 1;
            this.txtHost.Text = "127.0.0.1";
            // 
            // lblSchema
            // 
            this.lblSchema.Location = new System.Drawing.Point(281, 15);
            this.lblSchema.Name = "lblSchema";
            this.lblSchema.Size = new System.Drawing.Size(23, 16);
            this.lblSchema.TabIndex = 0;
            this.lblSchema.Text = "库:";
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(192, 14);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 17);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "端口:";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHost
            // 
            this.lblHost.Location = new System.Drawing.Point(35, 14);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(45, 17);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "主机:";
            this.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(805, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQLServer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooltip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(872, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // tooltip
            // 
            this.tooltip.Name = "tooltip";
            this.tooltip.Size = new System.Drawing.Size(0, 17);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backGroundProcessor);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunCompleted);
            // 
            // frmDataClean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 668);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpFrame);
            this.Name = "frmDataClean";
            this.Text = "数据清洗";
            this.Load += new System.EventHandler(this.frmDataClean_Load);
            this.grpFrame.ResumeLayout(false);
            this.grpFrame.PerformLayout();
            this.tabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFrame;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblSchema;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPasswd;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cbxSchema;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cbxTable;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.ListView lstFields;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colField;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colLength;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Button btnMongo2Mysql;
        private System.Windows.Forms.Button btnMysql2Mongo;
        private System.Windows.Forms.CheckBox enableFullMatch;
        private System.Windows.Forms.TextBox txtReplacement;
        private System.Windows.Forms.Label lblReplacement;
        private System.Windows.Forms.Label lblCustom;
        private System.Windows.Forms.ComboBox cbxCustomPayload;
        private System.Windows.Forms.Button btnConfigCustom;
        private System.Windows.Forms.Button btnFieldStat;
        private System.Windows.Forms.Button btnExportTable;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.ToolStripStatusLabel tooltip;
        private System.Windows.Forms.CheckBox cbxStat;
    }
}

