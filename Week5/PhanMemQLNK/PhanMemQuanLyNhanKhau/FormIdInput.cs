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
    public partial class FormIdInput : DevExpress.XtraEditors.XtraForm
    {
        #region references
        // references
        private QuanLyNhanKhauEntities dbs;
        private DevExpress.XtraGrid.GridControl gc;
        private DevExpress.XtraGrid.Views.Grid.GridView gv; 
        #endregion

        #region hàm khởi tạo
        // hàm khởi tạo
        public FormIdInput(QuanLyNhanKhauEntities dbs, DevExpress.XtraGrid.GridControl gc, DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            InitializeComponent();
            this.dbs = dbs;
            this.gc = gc;
            this.gv = gv;
        } 
        #endregion

        #region nút hoàn tất
        // nút hoàn tất
        private void btnHoanTatCMND_Click(object sender, EventArgs e)
        {
            // lấy dữ liệu từ text box
            var cmnd = txtbCMND.Text;
            if (!string.IsNullOrEmpty(cmnd) || !string.IsNullOrWhiteSpace(cmnd))
            {
                // tìm kiếm và đổ dữ liệu ra gridView1
                // đếm xem người đang tìm kiếm nằm ở hàng mấy
                int i = -1;
                var DanhSachCaNhan = dbs.ufnDanhSachCaNhan().ToList();
                if (DanhSachCaNhan.Count() != 0)
                {
                    foreach (var cn in DanhSachCaNhan)
                    {
                        i += 1;
                        if (cn.SoCMND.Trim() == cmnd.Trim()) break;
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu trống!",
                        "Không tìm thấy",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                gc.DataSource = DanhSachCaNhan;
                gv.FocusedRowHandle = i;
                // nếu i bằng -1 thì thông báo
                if (i == -1)
                {
                    MessageBox.Show("Người này chưa có thông tin trong hệ thống, Xin khai báo thông tin cá nhân trước!",
                        "Không tìm thấy",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    this.Close();
                    MessageBox.Show("Tìm thấy người này trong cơ sở dữ liệu!",
                        "Tìm thấy hồ sơ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("CMND không được để trống!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        } 
        #endregion
    }
}