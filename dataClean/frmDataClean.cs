using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql;
using MySql.Data;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using Mirabeau.Sql;
using Mirabeau.MySql.Library;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;
using System.Linq;

namespace dataClean
{
    public partial class frmDataClean : Form
    {
        public frmDataClean()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        TaskScheduler scheduler = null;

        private string host;
        private string port;
        private string schema;
        private string table;
        private string user;
        private string passwd;

        private void BtnLoad_Click(object sender, EventArgs e)
        {

            this.host = txtHost.Text;
            this.port = txtPort.Text;            
            this.user = txtUser.Text;
            this.passwd = txtPasswd.Text;

            String connectionString = String.Format("Data Source = {0}; User ID = {1}; Password = {2}; DataBase = information_schema; charset='utf8'", host, user, passwd);

            List<Schema> schemas = new List<Schema>();
            using (
               IDataReader dataReader = DatabaseHelper.ExecuteReader(connectionString, CommandType.Text, "SELECT TABLE_SCHEMA `schema` FROM information_schema.`COLUMNS` WHERE TABLE_SCHEMA NOT IN ('information_schema','mysql') GROUP BY TABLE_SCHEMA"))
            {
                while (dataReader.Read())
                {
                    // Datareader helper
                    // For not-nullable columns:
                    //int column1 = dataReader["schema"].GetDbValueOrDefaultForValueType<int>();

                    // For nullable columns:
                    //int? column2 = dataReader["databaseColumn2"].GetDbValueForNullableValueType<int>();
                    var schema = dataReader["schema"].GetDbValueOrNullForReferenceType<string>();
                    schemas.Add(new Schema(schema));
                }
            }
            cbxSchema.DataSource = schemas;
            scheduler = new TaskScheduler(txtHost.Text, txtPort.Text, txtUser.Text, txtPasswd.Text);
        }

   
      
        private void OnSchemaChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            Schema schema = (Schema)comboBox.SelectedItem;
            if (schema == null) return;

            this.schema = schema.Name;

            String connectionString = String.Format("Data Source = {0}; User ID = {1}; Password = {2}; DataBase = {3}; charset='utf8'", txtHost.Text, txtUser.Text, txtPasswd.Text, schema.Name);

            List<Table> tables = new List<Table>();
            using (
               IDataReader dataReader = DatabaseHelper.ExecuteReader(connectionString, CommandType.Text, "SELECT TABLE_NAME `table` FROM information_schema.`COLUMNS` where TABLE_SCHEMA='" + schema.Name + "' GROUP BY TABLE_NAME"))
            {
                while (dataReader.Read())
                {
                    // Datareader helper
                    // For not-nullable columns:
                    //int column1 = dataReader["schema"].GetDbValueOrDefaultForValueType<int>();

                    // For nullable columns:
                    //int? column2 = dataReader["databaseColumn2"].GetDbValueForNullableValueType<int>();
                    var table = dataReader["table"].GetDbValueOrNullForReferenceType<string>();
                    tables.Add(new Table(table));
                }
            }
            cbxTable.DataSource = tables;
        }

        private void onTableChanged(object sender, EventArgs e)
        {

            ComboBox comboBox = (ComboBox)sender;
            Table table = (Table)comboBox.SelectedItem;
        
            Schema schema = (Schema)cbxSchema.SelectedItem;

            this.table = table.Name;

            lstFields.Items.Clear();

            this.lstFields.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

            String connectionString = String.Format("Data Source = {0}; User ID = {1}; Password = {2}; DataBase = {3}; charset='utf8'", txtHost.Text, txtUser.Text, txtPasswd.Text, schema.Name);

            

            String sql = string.Format("SELECT COLUMN_NAME `name`, DATA_TYPE type, CHARACTER_MAXIMUM_LENGTH len FROM information_schema.`COLUMNS` " +
                "WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}' and DATA_TYPE in('varchar','text','char','mediumtext','tinytext','longtext')", schema.Name, table.Name);
            using (
               IDataReader dataReader = DatabaseHelper.ExecuteReader(connectionString, CommandType.Text, sql))
            {
                int index = 0;
                while (dataReader.Read())
                {
                   
                    var name = dataReader["name"].GetDbValueOrNullForReferenceType<string>();
                    var type = dataReader["type"].GetDbValueOrNullForReferenceType<string>();
                    var len = Convert.ToString(dataReader["len"]);


                    ListViewItem lvi = new ListViewItem
                    {
                        ImageIndex = index++,     //通过与imageList绑定，显示imageList中第i项图标

                        Text = ""
                    };
                    lvi.SubItems.Add(name);

                    lvi.SubItems.Add(type);

                    lvi.SubItems.Add(len);

                    this.lstFields.Items.Add(lvi);

                }
            }

            this.lstFields.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        /// <summary>
        /// 处理自定义替换
        /// </summary>
        [Obsolete]
        void HandleCustomReplacement()
        {
            Category category = (Category)cbxCategory.SelectedItem;
            if (category.Code.Equals("custom"))
            {
                if (string.IsNullOrEmpty(txtReplacement.Text))
                {
                    MessageBox.Show("预处理内容必填", "数据无效",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                return;
            }
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            Schema schema = (Schema)cbxSchema.SelectedItem;
            Table table = (Table)cbxTable.SelectedItem;
      
            List<string> columns = new List<string>();

            foreach (ListViewItem item in this.lstFields.Items)
            {                
                var column = item.SubItems[1].Text;
                if (item.Checked)
                {
                    columns.Add(column);                    
                }
            }

            Category category = (Category)cbxCategory.SelectedItem;
            string code = category.Code;

            if ("custom".Equals(code))
            {
                Payload customPayload =  (Payload)cbxCustomPayload.SelectedItem;

                scheduler.Run(schema.Name, table.Name, Payload.Instance.BuildSqls(schema.Name, table.Name, columns, customPayload));
            }
            else {
                tooltip.Text = "执行时间长,请耐心等待...";
                if ("phone+".Equals(code))
                {
                    scheduler.RunWithResultExtractor(schema.Name, table.Name, Payload.Instance.LoadStatFactory(code, new string[] { schema.Name, table.Name, selectedColumn }));
                }
                else
                {
                    scheduler.Run(schema.Name, table.Name, Payload.Instance.BuildSqls(schema.Name, table.Name, columns, Payload.Instance.LoadPayLoadFactory(code)));
                }
                tooltip.Text = "";
            }            
        }

        private void lstFields_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void lstFields_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstFields_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstFields_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lstFields.Columns[e.Column].Tag);
                }
                catch
                {
                }
                this.lstFields.Columns[e.Column].Tag = !value;

                
                foreach (ListViewItem item in this.lstFields.Items)
                    item.Checked = !value;                

                this.lstFields.Invalidate();
            }
        }

        private void frmDataClean_Load(object sender, EventArgs e)
        {
            List<Category> categories = new List<Category>
            {
                new Category("默认", "default"),
                new Category("电话类", "phone"),
                new Category("电话去[+]86", "phone+"),
                new Category("转半角", "halfwidth"),
                new Category("左空格", "ltrim"),
                new Category("右空格", "rtrim"),
                new Category("左右空格", "ltrimr"),
                new Category("转大写", "upper"),
                new Category("转小写", "lower"),
                new Category("自定义", "custom")
            };
            cbxCategory.DataSource = categories;
            SetCtlVisible(false);
        }


        public void SetCtlVisible(bool visbile)
        {
                this.lblCustom.Visible =
                this.txtReplacement.Visible =
                this.enableFullMatch.Visible =
                this.lblReplacement.Visible =
                this.cbxCustomPayload.Visible =
                this.btnConfigCustom.Visible =
                visbile;

            //预添加空的替换载荷
            List<CustomPayload> payloads = new List<CustomPayload>();
            var nullPayload = new CustomPayload("(null)", null, null);
            payloads.Add(nullPayload);
            cbxCustomPayload.DataSource = payloads;
        }

        private void btnMysql2Mongo_Click(object sender, EventArgs e)
        {

        }

        private void btnMongo2Mysql_Click(object sender, EventArgs e)
        {
            List<string> columns = new List<string>();
            foreach (ListViewItem item in this.lstFields.Items)
            {
                var column = item.SubItems[1].Text;
                if (item.Checked)
                {                    
                    columns.Add(column);
                }
            }
            if (columns.Count > 0)
            {
                frmTransfer frmTransfer = new frmTransfer(columns,1);
                frmTransfer.ShowDialog();
            }
        }

    
        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           Category category =  (Category)((ComboBox)sender).SelectedItem;
           SetCtlVisible(category.Code.Equals("custom"));            
        }

        private void txtReplacement_TextChanged(object sender, EventArgs e)
        {
            string replacement = ((TextBox)sender).Text;

            if (string.IsNullOrEmpty(replacement))
            {
                MessageBox.Show("预处理内容必填", "数据无效", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<CustomPayload> payloads = (List<CustomPayload>)cbxCustomPayload.DataSource;
                   
            foreach (CustomPayload payload in payloads)
            {
                var name = payload.Name;
                if ("(null)".Equals(name))
                {
                    payload.From = replacement;
                    payload.Rules = enableFullMatch.Checked ? "full" :"";
                }
            }
            cbxCustomPayload.DataSource = payloads;

        }

        private void cbxReplacement_TextChanged(object sender, EventArgs e)
        {
            List<CustomPayload> payloads = (List<CustomPayload>)cbxCustomPayload.DataSource;
        }

        private void btnConfigCustom_Click(object sender, EventArgs e)
        {
            List<CustomPayload> payloads = (List<CustomPayload>)cbxCustomPayload.DataSource;
            frmCustomPayload2 frmcustomPayload = new frmCustomPayload2(payloads);
            frmcustomPayload.ShowDialog();
        }

        private void btnExportTable_Click(object sender, EventArgs e)
        {
            Schema schema = (Schema)cbxSchema.SelectedItem;
            Table table = (Table)cbxTable.SelectedItem;
            string user = txtUser.Text;
            string passwd = txtPasswd.Text;

            //mysqldump--hex - blob--routines--triggers--max_allowed_packet = 1048576 - uroot - p leak shenfenzheng > g:\shenfenzheng2.sql            
            string command = string.Format("mysqldump --hex-blob --routines --triggers --max_allowed_packet=1048576 -u{0} -p{1} {2} {3} > g:\\{4}_{5}.sql",                
               user,passwd,schema.Name,table.Name,schema.Name,table.Name );
            Task.Run(()=> {
                Console.WriteLine("正在执行命令:{0}",command);
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = command
                };
                process.StartInfo = startInfo;
                process.Start();
            });
        }

        private void btnFieldStat_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.DoWork += backgroundWorker1_DoWork_1;
            if(cbxSchema.Items.Count==0)
            {
                MessageBox.Show("请初始化数据库连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(selectedColumn))
            {
                MessageBox.Show("请选择统计字段", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            backgroundWorker1.RunWorkerAsync();
        }


        List<FieldStat> fieldStats = new List<FieldStat>();
        string selectedColumn = string.Empty;
        private void backGroundProcessor(object sender, DoWorkEventArgs e)
        {
            String connectionString = String.Format("Data Source = {0}; User ID = {1}; Password = {2}; DataBase = {3}; charset='utf8'", host, user, passwd, schema);

           
            /*foreach (ListViewItem item in this.lstFields.Items)
            {
                var column = item.SubItems[1].Text;
                if (item.Checked)
                {
                    selectedColumn = column;
                }
            }*/

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string where = txtCondition.Text;
                string sql = string.Format("SELECT `{0}` as name,CONCAT('0x',HEX(`{1}`)) as hex,count(`{2}`) count from `{3}` WHERE LENGTH(`{4}`) > 0 {5} GROUP BY `{6}` order BY count desc", 
                    selectedColumn, selectedColumn, selectedColumn, table, selectedColumn,
                    string.IsNullOrEmpty(where)?"":string.Format("and `{0}` {1}",selectedColumn,where),
                    selectedColumn);

                Console.WriteLine("字段统计sql:{0}", sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn)
                {
                    CommandTimeout = 0
                };
                var reader = cmd.ExecuteReader();

                fieldStats.Clear();

                while (reader.Read())
                {
                    string name = Convert.ToString(reader["name"]);
                    int count = Convert.ToInt32(reader["count"]);
                    string hex = Convert.ToString(reader["hex"]);
                    fieldStats.Add(new FieldStat(name, hex,count));
                }                
            }
        }

        private void backgroundWorker_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            frmFieldStat frm = new frmFieldStat(fieldStats);            
            frm.Closed += new EventHandler(frmFieldStat_Closed);            
            frm.Show();
        }

        private void frmFieldStat_Closed(object sender, EventArgs e)
        {
            HashSet<string> replacement = ((frmFieldStat)sender).replacement; //待批量替换成 replaceTo的数据

            string replaceTo = ((frmFieldStat)sender).txtReplaceTo.Text; //替换目标

            Hashtable h_multiKey  = ((frmFieldStat)sender).h_multiKey;//待替换的键值对

            bool isMultiKey = ((frmFieldStat)sender).chkMultiKey.Checked; //是否为多键值对替换

            StringBuilder builder = new StringBuilder();

            List<Payload> ltPayLoads = new List<Payload>();
            if (!isMultiKey)
            {
                foreach (string item in replacement)
                {
                    bool isNull = string.IsNullOrEmpty(replaceTo);
                    //如果发现hex或者unhex以后的字符串和待替换的一直，则放弃
                    bool shouldIngoreReplacement = (!isNull) && (MySqlHexDecimalEncoding.hex(item).Equals(replaceTo) || MySqlHexDecimalEncoding.unhex(item).Equals(replaceTo));
                    if (shouldIngoreReplacement) continue;

                    if (isNull)
                    {
                        Payload customPayload = new Payload("invalid to null", item, null)
                        {
                            Rules = "full"
                        };
                        ltPayLoads.Add(customPayload);
                    }
                    else
                    {
                        string hex = MySqlHexDecimalEncoding.hex(replaceTo);
                        Payload customPayload = new Payload("replace", item, hex)
                        {
                            Rules = "full"
                        };
                        ltPayLoads.Add(customPayload);
                    }
                }
            }
            else
            {
                
                foreach (object key in h_multiKey.Keys)
                {
                    string targetKey = (string)key;
                    string targetValue = (string)h_multiKey[key];

                    //如果发现hex或者unhex以后的字符串和待替换的一直，则放弃
                    bool shouldIngoreReplacement = MySqlHexDecimalEncoding.unhex(targetValue).Equals(targetKey);
                    if (shouldIngoreReplacement) continue;

                    Payload customPayload = new Payload("replace", targetKey, targetValue)
                    {
                        Rules = "full"
                    };
                    builder.Append(targetKey);
                    builder.Append("->");
                    builder.Append(targetValue);
                    builder.Append("\n");
                    ltPayLoads.Add(customPayload);
                }
            }

            if (!string.IsNullOrEmpty(selectedColumn) && ltPayLoads.Count > 0)
            {
                DialogResult result =DialogResult.None;

                //普通替换
                if (!isMultiKey)
                {
                    result = MessageBox.Show(string.Concat("即将执行以下替换:\n", string.Join(",", replacement), "\n替换成:", replaceTo), "数据更新提醒",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                }
                else
                {
                    result = MessageBox.Show(string.Concat("即将执行多键值对替换\n", builder), "数据更新提醒",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                }


                if (result == DialogResult.Yes)
                {                    
                    scheduler.Run(schema, table, Payload.Instance.BuildSqls(schema, table, selectedColumn, ltPayLoads));
                }
            }            
        }

        

        private void lstFields_ItemCheck(object sender, ItemCheckEventArgs e)
        {            
            int index = e.Index;
            if (e.NewValue==CheckState.Checked)
            {
                selectedColumn = lstFields.Items[index].SubItems[1].Text;
                Console.WriteLine("selected Column:{0}", selectedColumn);

                //检测"只统计字段"的checkbox是否选择
                bool isOnlyStat = cbxStat.Checked;
                if (isOnlyStat)
                {

                    for (int i = 0; i < lstFields.Items.Count; i++)
                    {
                        if (i == index)
                            continue;
                        lstFields.Items[i].Checked = false;
                    }
                }
            }                      
        }

        private void lstFields_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            return;
            // 如果调整的不是第一列,就不管了 
            if (e.ColumnIndex > 0) return;
            e.Cancel = true;  //取消
            e.NewWidth = lstFields.Columns[e.ColumnIndex].Width; //设置现在新的宽度与调整前宽度一样
        }

        private void cbxStat_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbxStat.CheckState == CheckState.Checked)
            {
                //判断选中个数

                int cntChecked = 0;

                for (int i = 0; i < lstFields.Items.Count; i++)
                {
                    if (lstFields.Items[i].Checked)
                        cntChecked++;
                }

                //如果大于1全部取消
                if (cntChecked > 1)
                {
                    for (int i = 0; i < lstFields.Items.Count; i++)
                    {
                        lstFields.Items[i].Checked = false;
                    }
                }
            }
        }
    }
}
//https://blog.csdn.net/chen_zw/article/details/7910324