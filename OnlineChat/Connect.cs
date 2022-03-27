using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace OnlineChat
{
    public partial class frmConnect : Form
    {
        public frmConnect()
        {
            InitializeComponent();
        }
        private void frmConnect_Load(object sender, EventArgs e)
        {
            btnConfirm.Focus();
        }
        private void rdoOfficial_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.ReadOnly = txtPort.ReadOnly = true;
            txtIP.Text = txtPort.Text = "(自动分配)";
        }
        private void rdoUser_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.ReadOnly = txtPort.ReadOnly = false;
            txtIP.Text = txtPort.Text = "";
        }
        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Global.Numbers.Contains(e.KeyChar.ToString())) e.Handled = true;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (rdoOfficial.Checked)
            {
                Global.ServerIP = "118.25.126.34";
                Global.ServerPort = 23333;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(txtIP.Text))
                {
                    MessageBox.Show("地址不可为空", "连接失败", MessageBoxButtons.OK);
                    return;
                }
                if (String.IsNullOrWhiteSpace(txtPort.Text))
                {
                    MessageBox.Show("端口不可为空", "连接失败", MessageBoxButtons.OK);
                    return;
                }
                string testIP = txtIP.Text;
                int testPort = int.Parse(txtPort.Text);
                if (testPort <= 1000 || testPort >= 65536)
                {
                    txtPort.Text = "";
                    MessageBox.Show("无效端口(1000~65535)", "连接失败", MessageBoxButtons.OK);
                    return;
                }
                Global.ServerIP = testIP;
                Global.ServerPort = testPort;
            }
            this.Enabled = false;
            try
            {
                Global.socketClient = new Socket(SocketType.Stream, ProtocolType.Tcp);
                Global.socketIP = IPAddress.Parse(Global.ServerIP);
                Global.socketPoint = new IPEndPoint(Global.socketIP, Global.ServerPort);
                Global.socketClient.Connect(Global.socketPoint);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                MessageBox.Show("无法连接至服务器", "连接失败", MessageBoxButtons.OK);
            }
            this.Enabled = true;
        }
    }
}
