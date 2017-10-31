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
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace PhanMemQuanLyNhanKhau
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        #region các objects và biến toàn cục
        // objects
        public string initialCatalog = "",
                        dataSource = "",
                        userId = "",
                        password = "";
        // các đối tượng xử lí chuỗi kết nối của EF tự phát sinh
        private EntityConnectionStringBuilder entityCnxStringBuilder = null;
        private SqlConnectionStringBuilder sqlCnxStringBuilder = null;
        // các đối tượng xử lí dữ liệu
        private static QuanLyNhanKhauEntities dbs = new QuanLyNhanKhauEntities();

        // chuỗi kết nối
        private string strConnectionString;
        // Đối tượng kết nối
        SqlConnection conn = null;
        #endregion

        // hàm khởi tạo
        public FormLogin()
        {
            InitializeComponent();
            ActiveControl = btnLogin;
        }

        #region các method hỗ trợ
        // các method hỗ trợ
        // function thử kết nối
        private void TestConnection()
        {
            if (!string.IsNullOrEmpty(txtbUserName.Text) &&
                !string.IsNullOrEmpty(txtbServerName.Text) &&
                !string.IsNullOrEmpty(txtbPassword.Text))
            {
                try
                {
                    cbboxDatabaseNames.Items.Clear();
                    // thực hiện kết nối để lấy tên cơ sở dữ liệu
                    strConnectionString =
                        "Server=" + txtbServerName.Text +
                        ";User Id=" + txtbUserName.Text +
                        ";Password=" + txtbPassword.Text;
                    // Khởi động connection
                    conn = new SqlConnection(strConnectionString);
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    conn.Open();
                    // truy vấn tên database
                    string query = "SELECT name FROM sys.databases";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    // đổ ra combo box
                    while (dr.Read())
                    {
                        cbboxDatabaseNames.Items.Add(dr[0]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối đến dữ liệu !\n" + "Chi tiết: " +
                    ex.Message,
                    "Không kết nối được dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                // kiếm tra xem đã chọn database chưa 
                if (!string.IsNullOrEmpty(cbboxDatabaseNames.Text))
                {
                    btnLogin.Enabled = true;
                }
                else btnLogin.Enabled = false;
            }
            else btnLogin.Enabled = false;
        }

        // function kiếm trạng thái nút Login
        private void CheckLoginAndReloadDBButton()
        {
            if (!string.IsNullOrEmpty(txtbUserName.Text) &&
                !string.IsNullOrEmpty(txtbServerName.Text) &&
                !string.IsNullOrEmpty(txtbPassword.Text))
            {
                btnReloadDatabases.Enabled = true;
                if (!string.IsNullOrEmpty(cbboxDatabaseNames.Text))
                    btnLogin.Enabled = true;
                else btnLogin.Enabled = false;
            }
            else
            {
                btnReloadDatabases.Enabled = false;
                btnLogin.Enabled = false;
            }
        }


        // tải trạng thái mặc định
        private void LoadDefaultValues()
        {
            txtbServerName.Text = "(local)\\SQLEXPRESS";
            txtbUserName.Text = "sa";
            txtbPassword.Text = "";
            cbboxDatabaseNames.Text = "MyHospitalVer2";
        }

        // xem xét nếu có thay đổi thì phải thực hiện đổi chuỗi kết nối
        private void IfInfoChanged()
        {
            if (!string.Equals(txtbServerName.Text, sqlCnxStringBuilder.DataSource))
                sqlCnxStringBuilder.DataSource = txtbServerName.Text;
            if (!string.Equals(txtbUserName.Text, sqlCnxStringBuilder.UserID))
                sqlCnxStringBuilder.UserID = txtbUserName.Text;
            if (!string.Equals(cbboxDatabaseNames.Text, sqlCnxStringBuilder.InitialCatalog))
                sqlCnxStringBuilder.InitialCatalog = cbboxDatabaseNames.Text;
            // cập nhật lại chuỗi kết nối - quan trọng
            dbs.Database.Connection.ConnectionString = sqlCnxStringBuilder.ConnectionString;
        }

        // load các dữ liệu vào property của project
        private void LoadValuesToProjectsProperties()
        {
            // load tên máy chủ
            PhanMemQuanLyNhanKhau.Properties.Settings.Default.ServerName =
                txtbServerName.Text;
            // load tên người dùng
            PhanMemQuanLyNhanKhau.Properties.Settings.Default.UserName =
                txtbUserName.Text;
            // load mật khẩu
            PhanMemQuanLyNhanKhau.Properties.Settings.Default.Password =
                txtbPassword.Text;
            // load tên Database
            PhanMemQuanLyNhanKhau.Properties.Settings.Default.DatabaseName =
                cbboxDatabaseNames.Text;
            // save lại
            PhanMemQuanLyNhanKhau.Properties.Settings.Default.Save();
        }

        private void LoadValuesFromProjectsProperties()
        {
            txtbServerName.Text =
                PhanMemQuanLyNhanKhau.Properties.Settings.Default.ServerName;
            txtbUserName.Text =
                PhanMemQuanLyNhanKhau.Properties.Settings.Default.UserName;
            txtbPassword.Text =
                PhanMemQuanLyNhanKhau.Properties.Settings.Default.Password;
            cbboxDatabaseNames.Text =
                PhanMemQuanLyNhanKhau.Properties.Settings.Default.DatabaseName;
        }
        #endregion

        #region controls trong form
        private void FormLogin_Load(object sender, EventArgs e)
        {
            // khởi tạo các đối tượng xử lí chuỗi kết nối
            // chuyển thành đối tượng EntityConnectionStringBuilder
            this.entityCnxStringBuilder = new EntityConnectionStringBuilder
                (System.Configuration.ConfigurationManager
                    .ConnectionStrings["QuanLyNhanKhauEntities"].ConnectionString);

            // chuyển thành đối tượng SqlConnectionStringBuilder để truy cập
            // các property
            this.sqlCnxStringBuilder = new SqlConnectionStringBuilder
                (entityCnxStringBuilder.ProviderConnectionString);

            // truyền vào txtb, cbbox
            // sử dụng sự kiện nút tải lại mặc định
            LoadValuesFromProjectsProperties();

            // load lên và kiểm tra trạng thái cho các nút
            CheckLoginAndReloadDBButton();
        }

        private void btnReloadDatabases_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void btnLoadDefault_Click(object sender, EventArgs e)
        {
            LoadDefaultValues();
        }

        private void txtbUserName_TextChanged(object sender, EventArgs e)
        {
            CheckLoginAndReloadDBButton();
        }

        private void txtbPassword_TextChanged(object sender, EventArgs e)
        {
            CheckLoginAndReloadDBButton();
        }

        private void txtbServerName_TextChanged(object sender, EventArgs e)
        {
            CheckLoginAndReloadDBButton();
        }


        private void btnChangeValues_Click(object sender, EventArgs e)
        {
            // mở form mới
            FormSoftwareAdministratorLogin f =
                new FormSoftwareAdministratorLogin(txtbServerName, cbboxDatabaseNames);
            f.Show();
            btnLoadDefault.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormDataDisplay f = null;
            try
            {
                // lấy password từ textbox vào vì ko có trong chuỗi kết nối
                ConnectionsUtilities.setPassword(sqlCnxStringBuilder, dbs, txtbPassword.Text);

                // kiểm tra xem có thông tin thay đổi ko?
                IfInfoChanged();

                // mở form hiển thị dữ liệu
                f = new FormDataDisplay(dbs);
                //f.dgvBenhNhan.DataSource = dbs.ufnDanhSachCaNhan().ToList();
                f.ServerName.Caption = f.ServerName.Caption + txtbServerName.Text;
                f.Username.Caption = f.Username.Caption + txtbUserName.Text;
                f.DbName.Caption = f.DbName.Caption + cbboxDatabaseNames.Text;

                // kiểm tra điều kiện nhớ
                if (chboxRemember.Checked == true)
                    LoadValuesToProjectsProperties();

                // cài đặt sự kiện
                f.Closed += (s, args) => this.Close();
                this.Hide();
                f.Show();
            }
            catch (Exception ex)
            {
                //f.Close();
                MessageBox.Show("Lỗi kết nối đến dữ liệu !\n" + "Chi tiết: " +
                    ex.Message,
                    "Không kết nối được dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion
    }
}