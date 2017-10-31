using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PhanMemQuanLyNhanKhau
{
    public partial class FormSoftwareAdministratorLogin : DevExpress.XtraEditors.XtraForm
    {
        #region các biến toàn cục
        // các biến toàn cục
        private TextBox txtbServerName;
        private System.Windows.Forms.ComboBox cbboxDatabaseNames;
        private string username = "ADMIN";
        private string password = "kinlove32";
        #endregion

        #region hàm khởi tạo
        public FormSoftwareAdministratorLogin(TextBox txtbServerName, System.Windows.Forms.ComboBox cbboxDatabaseNames)
        {
            this.txtbServerName = txtbServerName;
            this.cbboxDatabaseNames = cbboxDatabaseNames;
            InitializeComponent();
        }
        #endregion

        #region method hỗ trợ
        // method hỗ trợ
        private void CheckLoginButton()
        {
            if (!string.IsNullOrEmpty(txtbAdminPassword.Text) &&
                !string.IsNullOrEmpty(txtbAdminUserName.Text))
                btnAdminLogin.Enabled = true;
            else btnAdminLogin.Enabled = false;
        }
        #endregion

        #region các controls
        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            if (string.Equals(txtbAdminUserName.Text, username, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(txtbAdminPassword.Text, password, StringComparison.OrdinalIgnoreCase))
            {
                this.Hide();
                txtbServerName.Enabled = true;
                cbboxDatabaseNames.Enabled = true;
            }
            else MessageBox.Show(
                    "Tài khoản quản trị viên không đúng!",
                    "Lỗi đăng nhập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void btnAdminQuit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtbAdminUserName_TextChanged(object sender, EventArgs e)
        {
            CheckLoginButton();
        }

        private void txtbAdminPassword_TextChanged(object sender, EventArgs e)
        {
            CheckLoginButton();
        } 
        #endregion
    }
}