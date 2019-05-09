namespace dataClean
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
            this.rtxtMongo = new System.Windows.Forms.RichTextBox();
            this.lblMongodb = new System.Windows.Forms.Label();
            this.rtxtMysql = new System.Windows.Forms.RichTextBox();
            this.lblMysql = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.StatusStrip();
            this.toolTips = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtMongo
            // 
            this.rtxtMongo.Location = new System.Drawing.Point(45, 39);
            this.rtxtMongo.Name = "rtxtMongo";
            this.rtxtMongo.Size = new System.Drawing.Size(681, 124);
            this.rtxtMongo.TabIndex = 0;
            this.rtxtMongo.Text = "";
            this.rtxtMongo.DoubleClick += new System.EventHandler(this.rtxtMongo_DoubleClick);
            // 
            // lblMongodb
            // 
            this.lblMongodb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMongodb.Location = new System.Drawing.Point(43, 15);
            this.lblMongodb.Name = "lblMongodb";
            this.lblMongodb.Size = new System.Drawing.Size(59, 17);
            this.lblMongodb.TabIndex = 1;
            this.lblMongodb.Text = "Mongo";
            // 
            // rtxtMysql
            // 
            this.rtxtMysql.Location = new System.Drawing.Point(44, 207);
            this.rtxtMysql.Name = "rtxtMysql";
            this.rtxtMysql.Size = new System.Drawing.Size(681, 124);
            this.rtxtMysql.TabIndex = 0;
            this.rtxtMysql.Text = "";
            this.rtxtMysql.DoubleClick += new System.EventHandler(this.rtxtMysql_DoubleClick);
            // 
            // lblMysql
            // 
            this.lblMysql.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMysql.Location = new System.Drawing.Point(42, 183);
            this.lblMysql.Name = "lblMysql";
            this.lblMysql.Size = new System.Drawing.Size(59, 17);
            this.lblMysql.TabIndex = 1;
            this.lblMysql.Text = "Mysql";
            // 
            // txtStatus
            // 
            this.txtStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTips});
            this.txtStatus.Location = new System.Drawing.Point(0, 428);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(800, 22);
            this.txtStatus.TabIndex = 2;
            this.txtStatus.Text = "statusStrip1";
            // 
            // toolTips
            // 
            this.toolTips.Name = "toolTips";
            this.toolTips.Size = new System.Drawing.Size(0, 17);
            // 
            // frmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblMysql);
            this.Controls.Add(this.rtxtMysql);
            this.Controls.Add(this.lblMongodb);
            this.Controls.Add(this.rtxtMongo);
            this.Name = "frmTransfer";
            this.Text = "导入导出";
            this.Load += new System.EventHandler(this.frmTransfer_Load);
            this.txtStatus.ResumeLayout(false);
            this.txtStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtMongo;
        private System.Windows.Forms.Label lblMongodb;
        private System.Windows.Forms.RichTextBox rtxtMysql;
        private System.Windows.Forms.Label lblMysql;
        private System.Windows.Forms.StatusStrip txtStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolTips;
    }
}