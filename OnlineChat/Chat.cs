using System;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;

namespace OnlineChat
{
    public partial class frmChat : Form
    {
        static bool isControlPressed = false;
        void socketReceive(object o)
        {
            var connection = o as Socket;
            while (true)
            {
                byte[] data = new byte[4096];
                var effective = connection.Receive(data);
                if (effective == 0) break;
                var result = Encoding.UTF8.GetString(data, 0, effective);
                txtReceive.Text += Environment.NewLine + result;
            }
        }
        private void socketControl(object sender, EventArgs e)
        {
            Global.socketClient.Send(Encoding.UTF8.GetBytes(Global.Username));
            Thread socketListen = new Thread(socketReceive);
            socketListen.IsBackground = true;
            socketListen.Start(Global.socketClient);
            txtReceive.Text = "成功连接服务器";
        }
        public frmChat()
        {
            InitializeComponent();
        }
        private void frmChat_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void frmChat_Activated(object sender, EventArgs e)
        {
            txtSend.Focus();
        }
        private void frmChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            txtReceive.Select(txtReceive.Text.Length, 0);
            txtReceive.ScrollToCaret();
        }
        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            isControlPressed = e.Control;
        }
        private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isControlPressed)
            {
                this.btnSend_Click(sender, e);
                e.Handled = true;
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtSend.Text;
            if (String.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("发送消息不可为空", "发送失败", MessageBoxButtons.OK);
                return;
            }
            txtSend.Text = "";
            Global.socketClient.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
