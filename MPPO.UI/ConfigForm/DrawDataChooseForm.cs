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
    public partial class DrawDataChooseForm : DevExpress.XtraEditors.XtraForm
    {
        public DrawDataChooseForm()
        {
            InitializeComponent();
        }
        List<MPPO.Protocol.Interface.IMdiDataForm<DataRow>> m_Forms = null;
        public void Init(List<MPPO.Protocol.Interface.IMdiDataForm<DataRow>> forms, List<bool> choosed = null)
        {
            this.clbForms.Items.Clear();
            m_Forms = forms;
            if(choosed!= null)
                for (int i = 0; i < forms.Count; ++i)
                {
                    this.clbForms.Items.Add(forms[i].Text);
                    this.clbForms.SetItemChecked(i, choosed[i]);
                }
            else
                for (int i = 0; i < forms.Count; ++i)
                {
                    this.clbForms.Items.Add(forms[i].Text);
                    this.clbForms.SetItemChecked(i, false);
                }
        }
        public List<MPPO.Protocol.Interface.IMdiDataForm<DataRow>> GetCheckedList()
        {
            List<MPPO.Protocol.Interface.IMdiDataForm<DataRow>> selected = new List<Protocol.Interface.IMdiDataForm<DataRow>>();
            for (int i = 0; i < clbForms.Items.Count; ++i)
            {
                if (clbForms.GetItemChecked(i))
                    selected.Add(m_Forms[i]);
            }
            return selected;
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}