using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MPPO.UI.ConfigForm
{
    public partial class SchmidtAnalysisConfigForm : DevExpress.XtraEditors.XtraForm
    {
        public List<string> SelectedColumns { get; set; }
        public int AreaSize { get; set; }
        public int AreaSpace { get; set; }
        public SchmidtAnalysisConfigForm(string tablename, string[] columns)
        {
            InitializeComponent();

            this.triStateTreeView1.BeginUpdate();
            this.triStateTreeView1.Nodes.Clear();
            var root = this.triStateTreeView1.Nodes.Add(tablename);
            foreach (var col in columns)
            {
                root.Nodes.Add(col);
            }
            root.Checked = true;
            root.Expand();
            this.triStateTreeView1.EndUpdate();
            this.Refresh();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(txeAreaSize.Text.Trim() == "" || txeAreaSpace.Text.Trim() == "")
            {
                MessageBox.Show("请填写完整滑动区间信息");
                return;
            }
            int size;
            if (!int.TryParse(txeAreaSize.Text, out size) || size <= 0)
            {
                MessageBox.Show("滑动区间大小必须为大于0的整数");
                return;
            }
            int space;
            if (!int.TryParse(txeAreaSpace.Text, out space) || space <= 0)
            {
                MessageBox.Show("滑动区间步长必须为大于0的整数");
                return;
            }
            if(space > size)
            {
                MessageBox.Show("步长不能大于区间大小");
                return;
            }
            this.AreaSize = size;
            this.AreaSpace = space;
            this.SelectedColumns = new List<string>();
            var nodes = this.triStateTreeView1.Nodes[0].Nodes;
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                    this.SelectedColumns.Add(node.Text);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void triStateTreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool temp = true;
            if (!this.triStateTreeView1.Nodes[0].Checked)
                temp = false;
            this.simpleButton1.Enabled = temp;
            this.labelControl2.Visible = !temp;

        }

    }
}