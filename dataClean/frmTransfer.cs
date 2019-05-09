using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataClean
{
    public partial class frmTransfer : Form
    {
        public frmTransfer()
        {
            InitializeComponent();
        }

        List<string> columns;
        int type;

        public frmTransfer(List<string> columns, int type):this()
        {
            this.columns = columns;
            this.type = type;
            FormatCommand();
        }

        void FormatCommand()
        {
            
            rtxtMongo.Text = string.Format("mongoexport--host = 192.168.1.197--port = 27017 - u leak - p 964513860220--db leak --collection shenfenzheng--type = csv--fields {0} --out g:\\shenfenzheng.csv",string.Join(",",columns));
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {

        }

        private void rtxtMongo_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(rtxtMongo.Text);
            this.toolTips.Text = "mongodb命令已经复制!";
        }

        private void rtxtMysql_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(rtxtMysql.Text);
            this.toolTips.Text = "mysql命令已经复制!";
        }
    }
}
