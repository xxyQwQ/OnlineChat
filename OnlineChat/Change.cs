using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace OnlineChat
{
    public partial class frmChange : Form
    {
        private string Change(string getUsername, string getOld, string getNew)
        {
            string result = null;
            try
            {
                using (var client = new WebClient())
                {
                    var value = new NameValueCollection();
                    value["username"] = getUsername;
                    value["password"] = getOld;
                    value["change"] = getNew;
                    result = Encoding.Default.GetString(client.UploadValues("http://118.25.126.34/Project/OnlineChat/Control/Change.php", value));
                }
            }
            catch (Exception)
            {
                result = "Error: connection failed";
            }
            return result;
        }
        public frmChange()
        {
            InitializeComponent();
        }
        private void frmChange_Load(object sender, EventArgs e)
        {
            btnConfirm.Focus();
        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Global.ValidCharacters.Contains(e.KeyChar.ToString())) e.Handled = true;
        }
        private void txtOld_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Global.ValidCharacters.Contains(e.KeyChar.ToString())) e.Handled = true;
        }
        private void txtNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Global.ValidCharacters.Contains(e.KeyChar.ToString())) e.Handled = true;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("用户名不可为空", "修改失败", MessageBoxButtons.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(txtOld.Text))
            {
                MessageBox.Show("旧密码不可为空", "修改失败", MessageBoxButtons.OK);
                return;
            }
            if (String.IsNullOrWhiteSpace(txtNew.Text))
            {
                MessageBox.Show("新密码不可为空", "修改失败", MessageBoxButtons.OK);
                return;
            }
            if (txtOld.Text == txtNew.Text)
            {
                txtNew.Text = "";
                MessageBox.Show("新旧密码不可相同", "修改失败", MessageBoxButtons.OK);
                return;
            }
            this.Enabled = false;
            string result = Change(txtUsername.Text, txtOld.Text, txtNew.Text);
            if (result == "Error: no such username")
            {
                txtUsername.Text = txtOld.Text = txtNew.Text = "";
                MessageBox.Show("用户名不存在", "修改失败", MessageBoxButtons.OK);
            }
            else if (result == "Error: wrong password")
            {
                txtOld.Text = txtNew.Text = "";
                MessageBox.Show("旧密码不正确", "修改失败", MessageBoxButtons.OK);
            }
            else if (result == "Success: change successfully")
            {
                txtUsername.Text = txtOld.Text = txtNew.Text = "";
                MessageBox.Show("请返回登录账号", "修改成功", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
            else MessageBox.Show("连接服务器失败", "修改失败", MessageBoxButtons.OK);
            this.Enabled = true;
        }
    }
}
