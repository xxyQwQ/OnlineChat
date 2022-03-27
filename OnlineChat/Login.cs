using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace OnlineChat
{
    public partial class frmLogin : Form
    {
        private string Login(string getUsername, string getPassword)
        {
            string result = null;
            try
            {
                using (var client = new WebClient())
                {
                    var value = new NameValueCollection();
                    value["username"] = getUsername;
                    value["password"] = getPassword;
                    result = Encoding.Default.GetString(client.UploadValues("http://118.25.126.34/Project/OnlineChat/Control/Login.php", value));
                }
            }
            catch (Exception)
            {
                result = "Error: connection failed";
            }
            return result;
        }
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Global.Username;
            chkRemember.Checked = Global.Remember;
            chkAutomatic.Checked = Global.Automatic;
            if (chkRemember.Checked) txtPassword.Text = Global.Password;
            if (chkAutomatic.Checked) btnLogin_Click(sender, e);
            picLogo.Focus();
        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Global.ValidCharacters.Contains(e.KeyChar.ToString())) e.Handled = true;
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Global.ValidCharacters.Contains(e.KeyChar.ToString())) e.Handled = true;
        }
        private void chkRemember_CheckStateChanged(object sender, EventArgs e)
        {
            Global.Remember = chkRemember.Checked;
            Config.Default.Remember = Global.Remember;
            Config.Default.Save();
        }
        private void chkAutomatic_CheckStateChanged(object sender, EventArgs e)
        {
            Global.Automatic = chkAutomatic.Checked;
            Config.Default.Automatic = Global.Automatic;
            Config.Default.Save();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("账号不可为空", "登录失败", MessageBoxButtons.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("密码不可为空", "登录失败", MessageBoxButtons.OK);
                return;
            }
            this.Enabled = false;
            string result = Login(txtUsername.Text, txtPassword.Text);
            if (result == "Error: no such username")
            {
                txtUsername.Text = txtPassword.Text = "";
                MessageBox.Show("无效账号", "登陆失败", MessageBoxButtons.OK);
            }
            else if (result == "Error: wrong password")
            {
                txtPassword.Text = "";
                MessageBox.Show("密码错误", "登陆失败", MessageBoxButtons.OK);
            }
            else if (result == "Success: login successfully")
            {
                Global.Username = txtUsername.Text;
                Global.Password = txtPassword.Text;
                Config.Default.Username = Global.Username;
                if (Global.Remember) Config.Default.Password = Global.Password;
                Config.Default.Save();
                txtUsername.Text = txtPassword.Text = "";
                this.DialogResult = DialogResult.OK;
            }
            else MessageBox.Show("无法连接至服务器", "登陆失败", MessageBoxButtons.OK);
            this.Enabled = true;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.ShowDialog();
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            frmChange frmChange = new frmChange();
            frmChange.ShowDialog();
        }
    }
}
