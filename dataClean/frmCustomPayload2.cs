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
    public partial class frmCustomPayload2 : Form
    {

        List<CustomPayload> customPayloads;
        public frmCustomPayload2()
        {
            InitializeComponent();
        }        
        public frmCustomPayload2(List<CustomPayload> customPayloads) : this()
        {
            //this.customPayloads = customPayloads;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }
    }
}
