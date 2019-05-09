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
    public partial class frmCustomPayload : Form
    {

        List<CustomPayload> customPayloads ;
        public frmCustomPayload()
        {
            InitializeComponent();
        }

        public frmCustomPayload(List<CustomPayload> customPayloads) : this()
        {
            this.customPayloads = customPayloads;
        }

        private void frmCustomPayload_Load(object sender, EventArgs e)
        {
            dataView.DataSource = customPayloads;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dataView.Rows.Add(1);
        }
    }
}
