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
    public partial class EntropyForm : DevExpress.XtraEditors.XtraForm
    {
        public List<string> SelectedColumns { get; set; }
        public EntropyForm(string tablename, string[] columns)
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