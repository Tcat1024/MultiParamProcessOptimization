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
    public partial class DataStandardForm : DevExpress.XtraEditors.XtraForm
    {
        private string[] originalColumns;
        private string[] inputColumns;
        private string[] outputColumns;
        public DataStandardForm(string[] columns)
        {
            InitializeComponent();
            this.originalColumns = columns;
            this.listBoxControl1.Items.AddRange(columns);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int count = this.listBoxControl2.Items.Count;
            inputColumns = new string[count];
            for(int i = 0;i<count;i++)
            {
                inputColumns[i] = this.listBoxControl2.Items[i].ToString();
            }
            outputColumns = new string[count];
            for(int i = 0;i<count;i++)
            {
                outputColumns[i] = this.listBoxControl3.Items[i].ToString();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach(var col in this.listBoxControl1.SelectedItems)
            {
                if (!this.listBoxControl2.Items.Contains(col) && this.originalColumns.Contains(col.ToString()))
                    this.listBoxControl2.Items.Add(col);
            }
            checkValidate();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            foreach (var col in this.listBoxControl1.SelectedItems)
            {
                if (!this.listBoxControl3.Items.Contains(col))
                    this.listBoxControl3.Items.Add(col);
            }
            checkValidate();
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string text= (sender as DevExpress.XtraEditors.ButtonEdit).Text.Trim();
            if (text != "" && !this.listBoxControl1.Items.Contains(text))
            {
                if (this.listBoxControl1.SelectedItem != null)
                    this.listBoxControl1.Items.Insert(this.listBoxControl1.SelectedIndex + 1, text);
                else
                    this.listBoxControl1.Items.Add(text);
            }
                
        }
        public string[] GetInputColumns()
        {
            return this.inputColumns;
        }
        public string[] GetOutputColumns()
        {
            return this.outputColumns;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var selectitems = this.listBoxControl2.SelectedItems;
            int count = selectitems.Count;
            for (int i = count - 1; i >= 0;i-- )
            {
                this.listBoxControl2.Items.Remove(selectitems[i]);
            }
            checkValidate();
        }
        private void checkValidate()
        {
            bool b = false;
            if(this.listBoxControl2.Items.Count!=this.listBoxControl3.Items.Count)
                b=true;
            this.labelControl5.Visible = b;
            this.simpleButton3.Enabled = !b;
        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var selectitems = this.listBoxControl3.SelectedItems;
            int count = selectitems.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                this.listBoxControl3.Items.Remove(selectitems[i]);
            }
            checkValidate();
        }

        private void listBoxControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control&&e.KeyCode==Keys.C)
            {
                Clipboard.SetText((sender as DevExpress.XtraEditors.ListBoxControl).SelectedItem.ToString());
            }
        }
    }
}