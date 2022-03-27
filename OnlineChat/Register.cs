using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace OnlineChat
{
    public partial class frmRegister : Form
    {
        private string Register(string getUsername, string getPassword)
        {
            string result = null;
            try
            {
                using (var client = new WebClient())
                {
                    var value = new NameValueCollection();
                    value["username"] = getUsername;
                    value["password"] = getPassword;
                    result = Encoding.Default.GetString(client.UploadValues("http://118.25.126.34/Project/OnlineChat/Control/Register.php", value));
                }
            }
            catch (Exception)
            {
                result = "Error: connection failed";
            }
            return result;
        }
        public frmRegister()
        {
            InitializeComponent();
        }
        private void frmRegister_Load(object sender, EventArgs e)
        {
            btnConfirm.Focus();
        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Global.ValidCharacters.Contains(e.KeyChar.ToString())) e.Handled = true;
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Global.ValidCharacters.Contains(e.KeyChar.ToString())) e.Handled = true;
        }
        private void txtRepeat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Global.ValidCharacters.Contains(e.KeyChar.ToString())) e.Handled = true;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("新用户名不可为空", "注册失败", MessageBoxButtons.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("用户密码不可为空", "注册失败", MessageBoxButtons.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(txtRepeat.Text))
            {
                MessageBox.Show("重复密码不可为空", "注册失败", MessageBoxButtons.OK);
                return;
            }
            if (txtPassword.Text != txtRepeat.Text)
            {
                txtRepeat.Text = "";
                MessageBox.Show("两次密码不同", "注册失败", MessageBoxButtons.OK);
                return;
            }
            this.Enabled = false;
            string result = Register(txtUsername.Text, txtPassword.Text);
            if (result == "Error: user already exist")
            {
                txtUsername.Text = "";
                MessageBox.Show("该用户名已存在", "注册失败", MessageBoxButtons.OK);
            }
            else if (result == "Success: register successfully")
            {
                txtUsername.Text = txtPassword.Text = txtRepeat.Text = "";
                MessageBox.Show("请返回登录账号", "注册成功", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
            else MessageBox.Show("连接服务器失败", "注册失败", MessageBoxButtons.OK);
            this.Enabled = true;
        }
    }
}
