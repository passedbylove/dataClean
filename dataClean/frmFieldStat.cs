using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataClean
{
    public partial class frmFieldStat : Form
    {

        public HashSet<string> replacement = new HashSet<string>();
        public Hashtable h_multiKey = new Hashtable();
        private List<ListViewItem> allItems = new List<ListViewItem>();

        public frmFieldStat()
        {
            InitializeComponent();
        }

        public frmFieldStat(List<FieldStat> fieldStats)
        {
            InitializeComponent();
            LoadConvertor();
            DataRender(fieldStats);

        }

        void LoadConvertor()
        {
            var dataSource = Converter.Instance(new string[] {
                "请选择",
                 "简转繁","繁转简",
                //utf-8转其他编码
                "utf-8 => gbk","utf-8 => gb2312","utf-8 => iso-8859-1",
                 "utf-8 => latin1","utf-8 => Big5",
                //拉丁文转其他
                "iso-8859-1 => utf-8","iso-8859-1 => gb2312","iso-8859-1 => gbk",
                "iso-8859-1 => Big5",

                "latin1 => utf-8","latin1 => GBK","latin1 => gb2312","latin1 => utf-8",
                "latin1 => Big5",

                //TODO:GB18030>GBK>GB2312 编码表完全兼容
                //gb2312转其他
                "gb2312 => utf-8","gb2312 --> latin1","gb2312 --> iso-8859-1","gb2312 => Big5",
                //gbk转其他
                "gbk => utf-8","gbk => latin1","gbk --> iso-8859-1","gbk => Big5",
                //大五码Big5转其他
                "Big5 => Gb2312","Big5 => GBK","Big5 => utf-8",
                "html Entity",
                "upper","lower",
                "trimLeft","trimRight","trim"/*,"trimInner"*/,"trimAll",
                "sha256(upper)","sha256(lower)",
                "md5(lower 16)","md5(upper 16)",
                "md5(lower 32)","md5(upper 32)"
            });
            Converter[] copy = new Converter[dataSource.Count];
            dataSource.CopyTo(copy, 0);
            cbxConverter.DataSource = copy;
            cbxCrypt.DataSource = dataSource;
        }

        void DataRender(List<FieldStat> fieldStats)
        {

            replacement.Clear();
            this.lstFieldStat.Items.Clear();

            this.lstFieldStat.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

            for (int i = 0; i < fieldStats.Count; i++)
            {
                FieldStat fieldStat = fieldStats[i];

                ListViewItem lvi = new ListViewItem();

                lvi.ImageIndex = i + 1;     //通过与imageList绑定，显示imageList中第i项图标

                lvi.Text = "";
                lvi.SubItems.Add(fieldStat.Name);
                lvi.SubItems.Add(fieldStat.Count + "");
                lvi.SubItems.Add(fieldStat.Hex);

                this.lstFieldStat.Items.Add(lvi);

                //保留一个备份
                allItems.Add(lvi);
                toolTips.Text = string.Format("共{0}条记录!", allItems.Count);
            }

            //获取一共有多少列 然后每列内容自适应-2   另外标题自适应是-1
            for (int i = 0; i < lstFieldStat.Columns.Count; i++)
            {
                lstFieldStat.Columns[i].Width = -2;
            }

            this.lstFieldStat.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        private void lstFieldStat_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lstFieldStat.Columns[e.Column].Tag);
                }
                catch
                {
                }
                this.lstFieldStat.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lstFieldStat.Items)
                    item.Checked = !value;

                this.lstFieldStat.Invalidate();
            }
        }


        private void lstFieldStat_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            return;
        }

        private void lstFieldStat_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void lstFieldStat_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstFieldStat_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstFieldStat_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string value = lstFieldStat.Items[e.Index].SubItems[1].Text; //第一列 数据库原始值

            string hex = lstFieldStat.Items[e.Index].SubItems[3].Text; //hex值

            if (e.NewValue == CheckState.Unchecked)
            {
                replacement.Remove(hex);
                Console.WriteLine("删除清洗数据:{0} --> {1}", value, hex);
                if (chkMultiKey.Checked)
                {
                    h_multiKey.Remove(value);
                }
            }
            else
            {
                replacement.Add(hex);
                Console.WriteLine("添加计划清洗数据:{0} -->{1}", value, hex);
                txtSelected.Text = value;
                if (chkMultiKey.Checked)
                {
                    h_multiKey[value] = hex;
                }
            }
        }

        private void cbxConverter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var conv = (Converter)((ComboBox)sender).SelectedItem;
            string from = txtSelected.Text;
            if (!string.IsNullOrEmpty(from))
            {
                conv.From = from;
                txtReplaceTo.Text = conv.To;
            }
        }

        private void txtSelected_TextChanged(object sender, EventArgs e)
        {
            var conv = (Converter)cbxConverter.SelectedItem;
            conv.From = ((TextBox)sender).Text;
            txtReplaceTo.Text = conv.To;
        }

        private void txtReplaceTo_TextChanged(object sender, EventArgs e)
        {
            if (chkMultiKey.Checked)
            {
                string selected = txtSelected.Text;
                string replaceTo = txtReplaceTo.Text;
                if (!string.IsNullOrEmpty(selected))
                {
                    h_multiKey[selected] = string.IsNullOrEmpty(replaceTo) ? null : replaceTo;
                }
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string find = ((TextBox)sender).Text;


            List<ListViewItem> dataSource = allItems;
            //https://devblogs.microsoft.com/pfxteam/
            if (!string.IsNullOrEmpty(find))
            {
                dataSource = allItems.AsParallel()
                    /*.Where(item => !string.IsNullOrEmpty(item.SubItems[1].Text))*/.Where(item => item.SubItems[1].Text.Contains(find)).ToList();
                dataSource.ForEach(item => {
                    var subItems = item.SubItems;
                    var key = MySqlHexDecimalEncoding.hex(item.SubItems[1].Text);
                    if (chkMultiKey.Checked)
                    {

                        item.Checked = (h_multiKey.ContainsValue(key)); //如果是多键不同值,存在这个key就选中
                    }
                    else
                    {
                        item.Checked = replacement.Contains(key); //多键同值,存在这个key就选中
                    }
                    Console.WriteLine("{0}", subItems[0].GetType());
                });

                toolTips.Text = string.Format("共命中{0}条记录!", dataSource.Count);
            }
            else
            {
                toolTips.Text = string.Format("共{0}条记录!", dataSource.Count);
            }

            this.lstFieldStat.BeginUpdate();
            lstFieldStat.Items.Clear();
            lstFieldStat.Items.AddRange(dataSource.ToArray());
            this.lstFieldStat.EndUpdate();
        }

        private void cbxCrypt_SelectedIndexChanged(object sender, EventArgs e)
        {
            var conv = (Converter)((ComboBox)sender).SelectedItem;
            string from = txtFind.Text;
            if (!string.IsNullOrEmpty(from))
            {
                conv.From = from;
                txtFind.Text = conv.To;
            }
            
        }

        private void chkMultiKey_CheckStateChanged(object sender, EventArgs e)
        {
            bool multiReplacement = ((CheckBox)sender).Checked;
            //如果是多键值对替换，清空 多键同一值替换
            if (multiReplacement)
            {
                replacement.Clear();
            }
            //otherwise
            else {
                h_multiKey.Clear();
            }
        }
    }
}
