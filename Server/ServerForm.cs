using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;
using Common;
using RemoteObject;
using Server;

namespace Server
{
    public class ServerForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ListBox lbMonitor;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBC;
        private System.ComponentModel.Container components = null;

        public static IOpentEvent eventA = null;
        public static IOpentEvent eventB = null;

        public ServerForm()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���
        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.lbMonitor = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMonitor
            // 
            this.lbMonitor.ItemHeight = 12;
            this.lbMonitor.Location = new System.Drawing.Point(32, 24);
            this.lbMonitor.Name = "lbMonitor";
            this.lbMonitor.Size = new System.Drawing.Size(232, 184);
            this.lbMonitor.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(88, 240);
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBC
            // 
            this.btnBC.Location = new System.Drawing.Point(192, 240);
            this.btnBC.Name = "btnBC";
            this.btnBC.TabIndex = 2;
            this.btnBC.Text = "&BroadCast";
            this.btnBC.Click += new System.EventHandler(this.btnBC_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(296, 285);
            this.Controls.Add(this.btnBC);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lbMonitor);
            this.Name = "ServerForm";
            this.Text = "FileWatcher";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.Run(new ServerForm());
        }

        private void StartServer()
        {
            OpenEventWrapper.RegistChannel();
            eventA = new OpenEventA();
            OpenEventWrapper.SetRemotingObj<OpenEventA>((OpenEventA)eventA);
            eventB = new OpenEventB();
            OpenEventWrapper.SetRemotingObj<OpenEventB>((OpenEventB)eventB);
        }

        private void ServerForm_Load(object sender, System.EventArgs e)
        {
            StartServer();
            lbMonitor.Items.Add("Server started!");
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            lbMonitor.Items.Clear();
        }

        private void btnBC_Click(object sender, System.EventArgs e)
        {
            BroadCastForm bcForm = new BroadCastForm();
            bcForm.StartPosition = FormStartPosition.CenterParent;
            bcForm.ShowDialog();
        }
    }
}
