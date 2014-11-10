using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MPPO.UI.Control
{
    [Designer(typeof(LoadingControlDesigner))]
    public partial class LoadingControl : DevExpress.XtraEditors.XtraUserControl
    {
        public bool ProgressBarVisible
        {
            get
            {
                return this.progressBarControl1.Visible;
            }
            set
            {
                this.progressBarControl1.Visible = value;
                if (value)
                    this.Height =16 + progressPanel1.Height + progressBarControl1.Height+btnCancel.Height;
                else
                    this.Height = 16+ progressPanel1.Height+btnCancel.Height;
            }
        }
        public string WaitText
        {
            get
            {
                return this.progressPanel1.Caption;
            }
            set
            {
                this.progressPanel1.Caption = value;
                this.progressPanel1.Refresh();
            }
        }
        public int Position
        {
            get
            {
                return this.progressBarControl1.Position;
            }
            set
            {
                this.progressBarControl1.Position = value;
            }
        }
        public LoadingControl()
        {
            InitializeComponent();
            this.Visible = false;
        }

        private void progressPanel1_SizeChanged(object sender, EventArgs e)
        {
            this.Width = this.progressPanel1.Width + 21;
            this.btnCancel.Location = new Point((this.Width - this.btnCancel.Width) / 2,this.btnCancel.Location.Y);
        }
        public event EventHandler Cancel;
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
    public class LoadingControlDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public LoadingControlDesigner()
        {
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules rules = SelectionRules.Visible | SelectionRules.Moveable;
                return rules;
            }
        }
    }
}
