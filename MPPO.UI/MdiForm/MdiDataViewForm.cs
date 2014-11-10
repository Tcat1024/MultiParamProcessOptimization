using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace MPPO.UI.MdiForm
{
    public partial class MdiDataViewForm : DevExpress.XtraEditors.XtraForm, MPPO.Protocol.Interface.IMdiDataForm<DataRow>
    {
        public MdiDataViewForm()
        {
            InitializeComponent();
        }
        private object _DataSource;
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public object DataSource
        {
            get
            {
                return this._DataSource;
            }
            set
            {
                this._DataSource = value;
                DataInit();
            }
        }
        private string _DataMember;
        [Category("Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string DataMember
        {
            get
            {
                return this._DataMember;
            }
            set
            {
                this._DataMember = value;
                if (this.DataSource != null)
                    DataInit();
            }
        }
        public int MdiIndex { get; set; }
        private string _Caption;
        public string Caption
        {
            get
            {
                return this._Caption;
            }
            set
            {
                this._Caption = value;
                this.Text = "WorkTable" + MdiIndex + " - " + value;
            }
        }
        public bool IsBusy { get; private set; }
        private string _State = "准备就绪";
        public string State
        {
            get
            {
                return this._State;
            }
            private set
            {
                if (this._State != value)
                {
                    this._State = value;
                    if (StateChanged != null)
                        StateChanged(this, new EventArgs());
                }
            }
        }
        public double CostTime { get; private set; }

        public event EventHandler MethodEnd;
        public event EventHandler StateChanged;
        private void DataInit()
        {
            if (this.DataSource == null)
            {
                MessageBox.Show("数据集为空");
                return;
            }
            try
            {
                mainGridView.Columns.Clear();
                this.mainGridControl.DataSource = this.DataSource;
                this.mainGridControl.DataMember = this.DataMember;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Protocol.Interface.IDataTable<DataRow> GetDataTable()
        {
            return new ViewData(mainGridView);
        }

        public void UIInvoke(Delegate method)
        {
            this.Invoke(method);
        }
        private void MdiDataViewForm_Resize(object sender, EventArgs e)
        {
            this.loadingControl1.Location = new Point((this.Width - this.loadingControl1.Width) / 2, (this.Height - this.loadingControl1.Height) / 2);
        }
        private void loadingControl1_SizeChanged(object sender, EventArgs e)
        {
            this.loadingControl1.Location = new Point((this.Width - this.loadingControl1.Width) / 2, (this.Height - this.loadingControl1.Height) / 2);
        }
        private Thread waitThread;
        private Thread methodThread;
        private void startWait(MPPO.Protocol.Structure.WaitObject waithandle)
        {
            this.Invoke(new Action(() =>
                {
                    this.IsBusy = true;
                    this.loadingControl1.ProgressBarVisible = true;
                    this.loadingControl1.Visible = true;
                    if (waithandle != null)
                    {
                        if (waitThread != null && waitThread.ThreadState != ThreadState.Aborted)
                            waitThread.Abort();
                        (waitThread = new Thread(WaitProgressThreadMethod) { IsBackground = true }).Start(waithandle);
                    }
                }));
        }
        private void endWait()
        {
            this.Invoke(new Action(() =>
                   {
                       if (waitThread != null && waitThread.ThreadState != ThreadState.Aborted)
                           waitThread.Abort();
                       this.loadingControl1.Visible = false;
                       this.loadingControl1.Position = 0;
                       this.IsBusy = false;
                       this.State = "准备就绪...";
                       if (this.MethodEnd != null)
                           this.MethodEnd(this,new EventArgs());
                   }));
        }
        private void WaitProgressThreadMethod(object input)
        {
            var waitobject = input as MPPO.Protocol.Structure.WaitObject;
            int progress;
            while (true)
            {
                Thread.Sleep(500);
                progress = 0;
                int max = waitobject.Max;
                int[] flags = waitobject.Flags;
                if (flags == null || max == -1)
                    continue;
                foreach (var flag in flags)
                    progress += flag;
                progress = progress * 100 / max;
                this.Invoke(new Action(() => { this.loadingControl1.Position = progress; }));
            }
        }
        public void DoMethod(string methodname,Action method, Protocol.Structure.WaitObject waithandle,Action callback = null)
        {
            this.State ="正在执行:"+methodname;
            startWait(waithandle);
            (methodThread = new Thread(() => 
            {
                DateTime start = DateTime.Now;
                method();
                this.CostTime = (DateTime.Now - start).TotalSeconds;
                endWait(); 
                callback();
            }) { IsBackground = true }).Start();
        }

        private void MdiDataViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AbortMethod();
        }

        private void loadingControl1_Cancel(object sender, EventArgs e)
        {
            AbortMethod();
        }
        private void AbortMethod()
        {
            if (waitThread != null && waitThread.ThreadState != ThreadState.Aborted)
                waitThread.Abort();
            if (methodThread != null && methodThread.ThreadState != ThreadState.Aborted)
                methodThread.Abort();
            GC.Collect();
        }
    }
}