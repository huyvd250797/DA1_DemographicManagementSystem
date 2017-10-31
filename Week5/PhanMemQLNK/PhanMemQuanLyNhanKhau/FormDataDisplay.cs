using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using System.IO;
using System.Globalization;

namespace PhanMemQuanLyNhanKhau
{
    public partial class FormDataDisplay : RibbonForm
    {
        #region properties và biến toàn cục
        private QuanLyNhanKhauEntities dbs;

        // properties
        public DevExpress.XtraGrid.GridControl dgvCaNhan
        {
            get
            {
                return gridControl1;
            }
        }

        public BarStaticItem ServerName
        {
            get
            {
                return barStaticItem1;
            }
        }

        public BarStaticItem Username
        {
            get
            {
                return barStaticItem2;
            }
        }

        public BarStaticItem DbName
        {
            get
            {
                return barStaticItem3;
            }
        }
        #endregion

        #region hàm khởi tạo
        public FormDataDisplay(QuanLyNhanKhauEntities dbs)
        {
            this.dbs = dbs;
            InitializeComponent();
            navigationPane1.LookAndFeel.UseDefaultLookAndFeel = false;
            navigationPane1.LookAndFeel.SkinName = "Blue";
        }

        #endregion

        #region các methods hỗ trợ việc truyền tải dữ liệu, Parse dữ liệu, báo lỗi khi chặn bắt biệt lệ
        // dành cho hình ảnh
        private bool PicModified = false;

        // các methods hỗ trợ
        private string GetNormalInfo(TextBox txtb)
        {
            var text = txtb.Text;
            if (!string.IsNullOrWhiteSpace(text))
                return text;
            else return null;
        }
        private string GetGenderInfo(RadioButton rbtnNam, RadioButton rbtnNu)
        {
            if (rbtnNam.Checked && !rbtnNu.Checked) return "Nam";
            else if (!rbtnNam.Checked && rbtnNu.Checked) return "Nữ";
            else return null;
        }
        private string GetDateInfo(DateTimePicker txtbDate)
        {
            var date = txtbDate.Text;
            if (!string.IsNullOrWhiteSpace(date))
            {
                var mydate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                return mydate.ToString("MM-dd-yyyy");
            }
            else return null;
        }
        private string GetConditionsInfo(RadioButton rbtnBT, RadioButton rbtnCC)
        {
            if (rbtnBT.Checked && !rbtnCC.Checked) return "Bình Thường";
            else if (!rbtnBT.Checked && rbtnCC.Checked) return "Cấp Cứu";
            else return null;
        }
        private byte[] GetPictureInfo(Image img)
        {
            if (PicModified)
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    img.Save(mStream, img.RawFormat);
                    return mStream.ToArray();
                }
            }
            else return null;
        }
        private void ErrorInform(Exception ex)
        {
            MessageBox.Show("Lỗi kết nối đến dữ liệu !\n\n" + "Chi tiết: \n" +
                    ex.Message + "\n\n" + "Nguyên Nhân: \n" + ex.InnerException.Message,
                    "Lỗi bất ngờ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        // dành cho nút sửa ảnh
        private static byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }
        // dành phần load hình ảnh lên pic box
        private void LoadPictureToPictureBox(string col, Label label, string labelCaption, PictureBox pictureBox)
        {
            try
            {
                Byte[] pic = null;
                pic = (Byte[])(gridView1.GetFocusedRowCellValue(col));
                if (pic != null)
                {
                    label.Text = "";
                    MemoryStream mem = new MemoryStream(pic);
                    pictureBox.Image = Image.FromStream(mem);
                }
                else
                {
                    label.Text = labelCaption;
                    pictureBox.Image = PhanMemQuanLyNhanKhau.Properties.Resources.person_male1600;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Đã xảy ra lỗi khi load hình ảnh!\n" + "Chi tiết: " +
                //    ex.Message,
                //    "Lỗi Bất Ngờ",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error);
            }
        }
        private void LoadPictureToPictureBox(Byte[] pic, Label label, string labelCaption, PictureBox pictureBox)
        {
            try
            {
                if (pic != null)
                {
                    label.Text = "";
                    MemoryStream mem = new MemoryStream(pic);
                    pictureBox.Image = Image.FromStream(mem);
                }
                else
                {
                    label.Text = labelCaption;
                    pictureBox.Image = PhanMemQuanLyNhanKhau.Properties.Resources.person_male1600;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Đã xảy ra lỗi khi load hình ảnh!\n" + "Chi tiết: " +
                //    ex.Message,
                //    "Lỗi Bất Ngờ",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error);
            }
        }
        #endregion

        #region các trạng thái mặc định
        // kiểm tra dữ liệu đã được load lên chưa
        #region dành cho phần thông tin cá nhân
        private void ThongTinCaNhan_Controls_DefaultState()
        {
            // control trên ribbon
            // lựa chọn page dành cho thông tin cá nhân
            ribbonPage1.Visible = true;
            ribbonControl1.SelectedPage = ribbonPage1;
            // che các page còn lại
            ribbonPage2.Visible = false;
            // các controls
            btnThemCaNhan.Enabled = true;
            btnSuaCaNhan.Enabled = true;
            btnXoaCaNhan.Enabled = true;
            btnCapNhatChinhSua.Enabled = false;
            btnTaiLaiToanBo.Enabled = true;

            // thanh navigate
            navigationPane1.SelectedPage = navigationPage1;

            // content trong navigate
            panel1.Enabled = false;

            // grid view
            gridControl1.Enabled = true;
        }
        private void ThongTinCaNhan_LoadContent(bool haveData)
        {
            if(haveData)
            {
                // phần text box
                txtbCMND.Text = gridView1.GetFocusedRowCellDisplayText("SoCMND");
                txtbHoTen.Text = gridView1.GetFocusedRowCellDisplayText("HoTen");
                #region kiểm tra giới tính
                if (gridView1.GetFocusedRowCellDisplayText("GioiTinh").Equals("Nam"))
                {
                    rbtnNam.Checked = true;
                    rbtnNu.Checked = false;
                }
                else
                {
                    rbtnNam.Checked = false;
                    rbtnNu.Checked = true;
                }
                #endregion
                txtbNgaySinh.Text = gridView1.GetFocusedRowCellDisplayText("NgaySinh");
                txtbNoiSinh.Text = gridView1.GetFocusedRowCellDisplayText("NoiSinh");
                txtbNguyenQuan.Text = gridView1.GetFocusedRowCellDisplayText("NguyenQuan");
                txtbNgayCapCMND.Text = gridView1.GetFocusedRowCellDisplayText("NgayCap");
                txtbNoiCapCMND.Text = gridView1.GetFocusedRowCellDisplayText("NoiCap");
                txtbTinhTrang.Text = gridView1.GetFocusedRowCellDisplayText("TrangThai");

                // phần hình ảnh
                LoadPictureToPictureBox("HinhAnh", label21, "Chưa có hình ảnh", picAvatar);
            }
            else
            {
                // phần text box
                txtbCMND.Text = "";
                txtbHoTen.Text = "";
                rbtnNu.Checked = false;
                rbtnNam.Checked = false;
                txtbNgaySinh.Text = "";
                txtbNoiSinh.Text = "";
                txtbNguyenQuan.Text = "";
                txtbNgayCapCMND.Text = "";
                txtbNoiCapCMND.Text = "";
                txtbTinhTrang.Text = "";

                // phần hình ảnh
                picAvatar.Image = PhanMemQuanLyNhanKhau.Properties.Resources.person_male1600;
                label21.Text = "Chưa có hình ảnh";
            }
        }
        private void ThongTinCaNhan_Flag_DefaultState()
        {
            themCaNhanFlag = false;
            suaCaNhanFlag = false;
        }
        private void ThongTinCaNhan_DefaultState(string cmnd)
        {
            ThongTinCaNhan_Controls_DefaultState();

            // grid control - dữ liệu chưa được tải lên 
            // đếm xem người vừa thêm vào nằm ở hàng mấy
            int i = 0;
            var DanhSachCaNhan = dbs.ufnDanhSachCaNhan().ToList();
            if (!string.IsNullOrEmpty(cmnd) || !string.IsNullOrWhiteSpace(cmnd))
            {
                i = -1;
                foreach (var cn in DanhSachCaNhan)
                {
                    i += 1;
                    if (cn.SoCMND.Trim() == cmnd.Trim()) break;
                }
            }
            dgvCaNhan.DataSource = DanhSachCaNhan;
            gridView1.FocusedRowHandle = i;
            // đẩy dữ liệu lên các field
            if (DanhSachCaNhan.Count() != 0)
            {
                ThongTinCaNhan_LoadContent(true);
            }
            else
            {
                ThongTinCaNhan_LoadContent(false);
            }

            // cài đặt cờ hiệu
            ThongTinCaNhan_Flag_DefaultState();
        }
        #endregion

        #region dành cho phần thông tin tạm trú
        private void ThongTinTamTru_Controls_DefaultState()
        {
            // control trên ribbon
            // lựa chọn page dành cho thông tin tạm trú
            ribbonPage2.Visible = true;
            ribbonControl1.SelectedPage = ribbonPage2;
            // che các page còn lại
            ribbonPage1.Visible = false;
            // các controls
            btnDKTTRMoi.Enabled = true;
            btnDKTTRDangChon.Enabled = true;
            btnSuaThongTinTTR.Enabled = true;
            btnChuyenThuongTru.Enabled = true;
            btnXoaThongTinTTR.Enabled = true;
            btnHoanTatDKTTR.Enabled = false;
            btnTaiLaiTTR.Enabled = true;
            // phần check
            barButtonItem1.Enabled = true;
            barButtonItem2.Enabled = true;
            barButtonItem3.Enabled = true;

            // thanh navigate
            navigationPane1.SelectedPage = navigationPage2;

            // content trong navigate
            panel2.Enabled = false;

            // grid view
            gridControl1.Enabled = true;
        }
        private void ThongTinTamTru_LoadContent(bool haveData)
        {
            if (haveData)
            {
                #region phần hộ khẩu
                // phần hộ khẩu
                txtbTTRMaSoHoKhau.Text = gridView1.GetFocusedRowCellDisplayText("ttrMaSoHoKhau");
                txtbTTRSoNha.Text = gridView1.GetFocusedRowCellDisplayText("ttrSoNha");
                txtbTTRDuong.Text = gridView1.GetFocusedRowCellDisplayText("ttrDuong");
                txtbTTRPhuong.Text = gridView1.GetFocusedRowCellDisplayText("ttrPhuong");
                txtbTTRQuan.Text = gridView1.GetFocusedRowCellDisplayText("ttrQuan");
                txtbTTRThanhPho.Text = gridView1.GetFocusedRowCellDisplayText("ttrThanhPho");
                #endregion

                #region phần sơ lược chủ hộ
                // sơ lược về chủ hộ
                lblTenChuHoTTR.Text = gridView1.GetFocusedRowCellDisplayText("ttrHoTenChuHo");
                lblGioiTinhChuHoTTR.Text = gridView1.GetFocusedRowCellDisplayText("ttrGioiTinhChuHo");
                lblNgaySinhChuHoTTR.Text = gridView1.GetFocusedRowCellDisplayText("ttrNgaySinhChuHo");
                lblCMNDChuHoTTR.Text = "CMND: " + gridView1.GetFocusedRowCellDisplayText("ttrCMNDChuHo");
                LoadPictureToPictureBox("ttrHinhAnhChuHo", label16, "Chưa có hình ảnh", picHinhAnhChuHoTTR);
                #endregion

                #region thông tin chung
                // thông tin chung
                txtbTTRQHvChuHo.Text = gridView1.GetFocusedRowCellDisplayText("ttrQuanHeVoiChuHo");
                txtbNgayDKTTR.Text = gridView1.GetFocusedRowCellDisplayText("NgayDKTTR");
                #endregion

                #region giấy tạm trú
                // giấy tạm trú
                txtbMaGiayTTR.Text = gridView1.GetFocusedRowCellDisplayText("MaGiayTamTru");
                #endregion

                #region sổ kt3
                // sổ kt3
                txtbMaSoKT3.Text = gridView1.GetFocusedRowCellDisplayText("MaSoKT3");
                txtbNgayLapSoKT3.Text = gridView1.GetFocusedRowCellDisplayText("NgayCapSo");
                #endregion

                #region thông tin chủ sổ kt3
                // thông tin chủ sổ kt3
                lblTenChuKT3.Text = gridView1.GetFocusedRowCellDisplayText("HoTenChuSo");
                lblGioiTinhChuKT3.Text = gridView1.GetFocusedRowCellDisplayText("GioiTinhChuSo");
                lblNgaySinhChuKT3.Text = gridView1.GetFocusedRowCellDisplayText("NgaySinhChuSo");
                lblCMNDChuKT3.Text = "CMND: " + gridView1.GetFocusedRowCellDisplayText("SoCMNDChuSo");
                LoadPictureToPictureBox("HinhAnhChuSo", label18, "Chưa có hình ảnh", picChuSoKT3);
                #endregion

                #region điều kiện
                // điều kiện
                if ((string.IsNullOrEmpty(txtbMaSoKT3.Text) || string.IsNullOrWhiteSpace(txtbMaSoKT3.Text))
                    && (string.IsNullOrEmpty(txtbMaGiayTTR.Text) || string.IsNullOrWhiteSpace(txtbMaGiayTTR.Text))
                    && (string.IsNullOrEmpty(txtbTTRMaSoHoKhau.Text) || string.IsNullOrWhiteSpace(txtbTTRMaSoHoKhau.Text)))
                {
                    // enable
                    btnDKTTRDangChon.Enabled = true;
                    // disable
                    btnSuaThongTinTTR.Enabled = false;
                    btnXoaThongTinTTR.Enabled = false;
                    btnChuyenThuongTru.Enabled = false;
                }
                else
                {
                    // enable
                    btnSuaThongTinTTR.Enabled = true;
                    btnXoaThongTinTTR.Enabled = true;
                    btnChuyenThuongTru.Enabled = true;
                    // disable
                    btnDKTTRDangChon.Enabled = false;
                } 
                #endregion
            }
            else
            {
                #region phần hộ khẩu
                // phần hộ khẩu
                txtbTTRMaSoHoKhau.Text = "";
                txtbTTRSoNha.Text = "";
                txtbTTRDuong.Text = "";
                txtbTTRPhuong.Text = "";
                txtbTTRQuan.Text = "";
                txtbTTRThanhPho.Text = "";
                #endregion

                #region phần sơ lược chủ hộ
                // sơ lược về chủ hộ
                lblTenChuHoTTR.Text = "Chưa rõ ?";
                lblGioiTinhChuHoTTR.Text = "Chưa rõ ?";
                lblNgaySinhChuHoTTR.Text = "Chưa rõ ?";
                lblCMNDChuHoTTR.Text = "Chưa rõ ?";
                picHinhAnhChuHoTTR.Image = PhanMemQuanLyNhanKhau.Properties.Resources.person_male1600;
                label16.Text = "Chưa rõ ?";
                #endregion

                #region thông tin chung
                // thông tin chung
                txtbTTRQHvChuHo.Text = "";
                txtbNgayDKTTR.Text = "";
                #endregion

                #region giấy tạm trú
                // giấy tạm trú
                txtbMaGiayTTR.Text = "";
                #endregion

                #region sổ kt3
                // sổ kt3
                txtbMaSoKT3.Text = "";
                txtbNgayLapSoKT3.Text = "";
                #endregion

                #region thông tin chủ sổ kt3
                // thông tin chủ sổ kt3
                lblTenChuKT3.Text = "Chưa rõ ?";
                lblGioiTinhChuKT3.Text = "Chưa rõ ?";
                lblNgaySinhChuKT3.Text = "Chưa rõ ?";
                lblCMNDChuKT3.Text = "Chưa rõ ?";
                picChuSoKT3.Image = PhanMemQuanLyNhanKhau.Properties.Resources.person_male1600;
                label18.Text = "Chưa rõ ?";
                #endregion
            }
        }
        private void ThongTinTamTru_Flag_DefaultState()
        {
            themTamTruMoiFlag = false;
            themTamTruHienTaiFlag = false;
            suaTamTruHienTaiFlag = false;
        }
        private void ThongTinTamTru_DefaultState(string cmnd)
        {
            ThongTinTamTru_Controls_DefaultState();

            // grid control - dữ liệu chưa được tải lên 
            // đếm xem người vừa thêm vào nằm ở hàng mấy
            int i = 0;
            var DanhSachCaNhan = dbs.ufnDanhSachCaNhan().ToList();
            if (!string.IsNullOrEmpty(cmnd) || !string.IsNullOrWhiteSpace(cmnd))
            {
                i = -1;
                foreach (var cn in DanhSachCaNhan)
                {
                    i += 1;
                    if (cn.SoCMND.Trim() == cmnd.Trim()) break;
                }
            }
            dgvCaNhan.DataSource = DanhSachCaNhan;
            gridView1.FocusedRowHandle = i;
            // đẩy dữ liệu lên các field
            if (DanhSachCaNhan.Count() != 0)
            {
                ThongTinTamTru_LoadContent(true);
            }
            else
            {
                ThongTinTamTru_LoadContent(false);
            }

            ThongTinTamTru_Flag_DefaultState();
        }
        #endregion

        #region dành cho phần thông tin thường trú
        private void ThongTinThuongTru_Controls_DefaultState()
        {

        }
        private void ThongTinThuongTru_LoadContent(bool haveData)
        {

        }
        private void ThongTinThuongTru_Flag_DefaultState()
        {

        }
        private void ThongTinThuongTru_DefaultState(string cmnd)
        {

        }
        #endregion

        #region dành cho phần thông tin tạm vắng
        private void ThongTinTamVang_Controls_DefaultState()
        {

        }
        private void ThongTinTamVang_LoadContent(bool haveData)
        {

        }
        private void ThongTinTamVang_Flag_DefaultState()
        {

        }
        private void ThongTinTamVang_DefaultState(string cmnd)
        {

        }
        #endregion

        #endregion

        #region Các sự kiện của form
        private void FormDataDisplay_Load(object sender, EventArgs e)
        {
            ThongTinCaNhan_DefaultState(null);
        }
        private void FormDataDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result =
                    MessageBox.Show(this,
                    "Bạn thật sự muốn thoát?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                //try
                //{
                //    Environment.Exit(0);
                //}
                //catch (Exception) { }
                //this.Close();
                //khuyến cáo ko sử dụng this.Close();
                //do sẽ tái lập lại sự kiện Form đóng gây ra vòng lặp vô tận
                //Environment.Exit(0); h sẽ gây ra lỗi, trước đây vẫn hoạt động tốt
                //nhưng đã phát sinh trục trặc với các bản cập nhập gần đây của window
                //xem chi tiết :https://stackoverflow.com/questions/18036863/why-does-environment-exit-not-terminate-the-program-any-more
                e.Cancel = true;
            }
        }
        #endregion

        #region sự kiện thay đổi tab navigate
        private void navigationPane1_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            if (navigationPane1.SelectedPage == navigationPage1)
            {
                ThongTinCaNhan_Controls_DefaultState();
                ThongTinCaNhan_LoadContent(true);
            }
            else if (navigationPane1.SelectedPage == navigationPage2)
            {
                ThongTinTamTru_Controls_DefaultState();
                ThongTinTamTru_LoadContent(true);
            }
            else if (navigationPane1.SelectedPage == navigationPage3)
            {
                ThongTinThuongTru_Controls_DefaultState();
                ThongTinThuongTru_LoadContent(true);
            }
            else if (navigationPane1.SelectedPage == navigationPage4)
            {
                ThongTinTamVang_Controls_DefaultState();
                ThongTinTamVang_LoadContent(true);
            }
        }

        #endregion

        #region bấm 1 dòng hiện ra tất cả
        // methods hỗ trợ
        private void ThongTinCaNhan_DataBind()
        {
            if(navigationPane1.SelectedPage == navigationPage1)
            {
                ThongTinCaNhan_LoadContent(true);
            }
            else if (navigationPane1.SelectedPage == navigationPage2)
            {
                ThongTinTamTru_LoadContent(true);
            }
            else if (navigationPane1.SelectedPage == navigationPage3)
            {
                
            }
            else if (navigationPane1.SelectedPage == navigationPage4)
            {
                
            }
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            ThongTinCaNhan_DataBind();
        }
        #endregion

        #region các methods và cờ hiệu hỗ trợ cho các controls thêm sửa xóa
        // dành cho hàm xóa - thông báo và hỏi
        private bool DeletedTask_SafeKey(string warning)
        {
            DialogResult result =
                    MessageBox.Show(this,
                    warning,
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // dành cho hàm thêm 
        private void Insert_ContentState(string field)
        {
            
            switch (field)
            {
                // phần thông tin cá nhân
                case "ThongTinCaNhan":
                    #region content
                    panel1.Enabled = true;
                    ThongTinCaNhan_LoadContent(false);  // tẩy trắng
                    #endregion
                    #region các control trong ribbon
                    // các control trong ribbon
                    // disable toàn bộ phần cá nhân
                    btnThemCaNhan.Enabled = false;
                    btnSuaCaNhan.Enabled = false;
                    btnXoaCaNhan.Enabled = false;
                    // không được thao tác trên gridView
                    gridControl1.Enabled = false;
                    // chuẩn bị cập nhật thông tin
                    btnCapNhatChinhSua.Enabled = true;
                    #endregion
                    #region cài đặt cờ hiệu
                    // cài đặt cờ hiệu
                    themCaNhanFlag = true;
                    suaCaNhanFlag = false;
                    #endregion
                    break;
                // phần thông tin tạm trú
                case "ThongTinTamTru":
                    #region content
                    panel2.Enabled = true;
                    ThongTinTamTru_LoadContent(false);  // tẩy trắng
                    #endregion
                    #region các control trong ribbon
                    // các control trong ribbon
                    // disable toàn bộ
                    btnDKTTRMoi.Enabled = false;
                    btnDKTTRDangChon.Enabled = false;
                    btnSuaThongTinTTR.Enabled = false;
                    btnChuyenThuongTru.Enabled = false;
                    btnXoaCaNhan.Enabled = false;
                    // không được thao tác trên gridView
                    gridControl1.Enabled = false;
                    // chuẩn bị cập nhật thông tin
                    btnHoanTatDKTTR.Enabled = true;
                    #endregion
                    #region cài đặt cờ hiệu
                    // cài đặt cờ hiệu
                    themTamTruMoiFlag = false;
                    themTamTruHienTaiFlag = true;
                    suaTamTruHienTaiFlag = false;
                    #endregion
                    break;
                // phần thông tin thường trú
                case "ThongTinThuongTru":

                    break;
                // phần thông tin tạm vắng
                case "ThongTinTamVang":

                    break;
            }
        }
        // dành cho hàm sửa 
        private void Update_ContentState(string field)
        {

            switch (field)
            {
                // phần thông tin cá nhân
                case "ThongTinCaNhan":
                    #region content
                    panel1.Enabled = true; // ko tẩy trắng
                    #endregion
                    #region control trong ribbon
                    // các control trong ribbon
                    // disable toàn bộ phần xét nghiệm
                    btnThemCaNhan.Enabled = false;
                    btnSuaCaNhan.Enabled = false;
                    btnXoaCaNhan.Enabled = false;
                    // không được thao tác trên gridView
                    gridControl1.Enabled = false;
                    // chuẩn bị cập nhật thông tin
                    btnCapNhatChinhSua.Enabled = true;
                    #endregion
                    #region cài đặt cờ hiệu
                    // cài đặt cờ hiệu
                    themCaNhanFlag = false;
                    suaCaNhanFlag = true;
                    #endregion
                    break;
                // phần thông tin tạm trú
                case "ThongTinTamTru":
                    #region content
                    panel2.Enabled = true; // ko tẩy trắng
                    #endregion
                    #region control trong ribbon
                    // các control trong ribbon
                    // disable toàn bộ
                    btnDKTTRMoi.Enabled = false;
                    btnDKTTRDangChon.Enabled = false;
                    btnSuaThongTinTTR.Enabled = false;
                    btnChuyenThuongTru.Enabled = false;
                    btnXoaCaNhan.Enabled = false;
                    // không được thao tác trên gridView
                    gridControl1.Enabled = false;
                    // chuẩn bị cập nhật thông tin
                    btnHoanTatDKTTR.Enabled = true;
                    #endregion
                    #region cài đặt cờ hiệu
                    // cài đặt cờ hiệu
                    themTamTruMoiFlag = false;
                    themTamTruHienTaiFlag = false;
                    suaTamTruHienTaiFlag = true;
                    #endregion
                    break;
                // phần thông tin thường trú
                case "ThongTinThuongTru":

                    break;
                // phần thông tin tạm vắng
                case "ThongTinTamVang":

                    break;
            }
        }
        #endregion

        #region các controls và views trong phần thông tin cá nhân
        // các cờ hiệu
        private bool themCaNhanFlag = false;
        private bool suaCaNhanFlag = false;
        //
        private void btnThemCaNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Insert_ContentState("ThongTinCaNhan");
        }

        private void btnSuaCaNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Update_ContentState("ThongTinCaNhan");
        }
        
        private void btnXoaCaNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            // khởi tạo trạng thái mặc định
            if (DeletedTask_SafeKey("Bạn có chắc bạn muốn xóa người này?"))
            {
                try
                {
                    // gọi sp delete theo các trường hợp
                    
                    // thông báo
                    MessageBox.Show("Xóa thông tin thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    // về trạng thái mặc định
                    ThongTinCaNhan_DefaultState(null);
                }
                catch (Exception ex)
                {
                    ErrorInform(ex);
                }
            }
        }

        private void btnCapNhatChinhSua_ItemClick(object sender, ItemClickEventArgs e)
        {
            // kiểm tra cờ và gọi sp
            if (themCaNhanFlag == true && suaCaNhanFlag == false)
            {
                try
                {
                    var cmnd = GetNormalInfo(txtbCMND);
                    // gọi sp insert theo các trường hợp
                    //dbs.uspThemBenhNhan(
                    //    maso,
                    //    GetNormalInfo(txtbHoTen),
                    //    GetGenderInfo(rbtnNam, rbtnNu),
                    //    GetNormalInfo(txtbDiaChi),
                    //    GetDateInfo(txtbNgaySinh),
                    //    GetNormalInfo(txtbNoiSinh),
                    //    GetNormalInfo(txtbCMND),
                    //    GetNormalInfo(txtbSoDt),
                    //    GetNormalInfo(txtbNgheNghiep),
                    //    GetPictureInfo(picAvatar.Image),
                    //    GetNormalInfo(txtbEmail),
                    //    GetNormalInfo(txtbNhomMau),
                    //    GetNormalInfo(txtbDiUngThuoc),
                    //    GetNormalInfo(txtbMaGiuong),
                    //    GetConditionsInfo(rbtnBinhThuong, rbtnCapCuu)
                    //);
                    // thông báo
                    MessageBox.Show("Thêm mới thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    // tải trạng thái mặc định có chỉ định row được chọn
                    ThongTinCaNhan_DefaultState(cmnd);
                }
                catch (Exception ex)
                {
                    ErrorInform(ex);
                }
            }
            else if (themCaNhanFlag == false && suaCaNhanFlag == true)
            {
                try
                {
                    var cmnd = GetNormalInfo(txtbCMND);
                    // gọi sp update theo các trường hợp
                    //dbs.uspThemBenhNhan(
                    //    maso,
                    //    GetNormalInfo(txtbHoTen),
                    //    GetGenderInfo(rbtnNam, rbtnNu),
                    //    GetNormalInfo(txtbDiaChi),
                    //    GetDateInfo(txtbNgaySinh),
                    //    GetNormalInfo(txtbNoiSinh),
                    //    GetNormalInfo(txtbCMND),
                    //    GetNormalInfo(txtbSoDt),
                    //    GetNormalInfo(txtbNgheNghiep),
                    //    GetPictureInfo(picAvatar.Image),
                    //    GetNormalInfo(txtbEmail),
                    //    GetNormalInfo(txtbNhomMau),
                    //    GetNormalInfo(txtbDiUngThuoc),
                    //    GetNormalInfo(txtbMaGiuong),
                    //    GetConditionsInfo(rbtnBinhThuong, rbtnCapCuu)
                    //);
                    // thông báo
                    MessageBox.Show("Cập nhật thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    // tải trạng thái mặc định có chỉ định row được chọn
                    ThongTinCaNhan_DefaultState(cmnd);
                }
                catch (Exception ex)
                {
                    ErrorInform(ex);
                }
            }
        }

        private void btnTaiLaiToanBo_ItemClick(object sender, ItemClickEventArgs e)
        {
            ThongTinCaNhan_DefaultState(null);
        }

        private void btnSuaAnh_Click(object sender, EventArgs e)
        {
            // chọn từ máy tính đường dẫn hình ảnh
            OpenFileDialog ofd = new OpenFileDialog();  //mở để chọn file
            //
            //ofd.InitialDirectory = @"C:\";
            ofd.Title = "Chọn đường dẫn đến file hình ảnh";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Filter = "File hình ảnh (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            ofd.ReadOnlyChecked = true;
            ofd.ShowReadOnly = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fname = ofd.FileName;
                var photo = GetPhoto(fname);
                // lưu lại hình ảnh để tiếp tục sử dụng
                var original = new Bitmap(fname);
                // lưu vào hình mẫu
                picAvatar.Image = original;
                // sửa label
                label21.Text = "Đã chọn ảnh";
                // cài đặt cờ hiệu
                PicModified = true;
            }
        }

        #endregion

        #region các controls và views trong phần thông tin tạm trú
        // các cờ hiệu ở trạng thái mặc định
        private bool themTamTruMoiFlag = false;
        private bool themTamTruHienTaiFlag = false;
        private bool suaTamTruHienTaiFlag = false;
        // các control
        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            // hiển thị tất cả
            var HienThiTatCa = dbs.ufnDanhSachCaNhan().ToList();
            gridControl1.DataSource = HienThiTatCa;
            // tải dữ liệu lên
            gridView1.FocusedRowHandle = 0;
            ThongTinTamTru_LoadContent(true);
        }

        private void barCheckItem2_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            // hiển thị có tạm trú nhưng không KT3
            var HienThiTTRKoKT3 = dbs.ufnDanhSachTamTruKhongKT3().ToList();
            gridControl1.DataSource = HienThiTTRKoKT3;
            // tải dữ liệu lên
            gridView1.FocusedRowHandle = 0;
            ThongTinTamTru_LoadContent(true);
        }

        private void barCheckItem3_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            // hiển thị có tạm trú và có KT3
            var HienThiTTRCoKT3 = dbs.ufnDanhSachTamTruCoKT3().ToList();
            gridControl1.DataSource = HienThiTTRCoKT3;
            // tải dữ liệu lên
            gridView1.FocusedRowHandle = 0;
            ThongTinTamTru_LoadContent(true);
        }

        private void btnDKTTRMoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            // mở form mới yêu cầu nhập vào số CMND xem người đó đã có trong hệ thống chưa
            FormIdInput f1 = new FormIdInput(dbs, gridControl1, gridView1);
            f1.Show();
        }

        private void btnDKTTRDangChon_ItemClick(object sender, ItemClickEventArgs e)
        {
            Insert_ContentState("ThongTinTamTru");
        }

        private void btnSuaThongTinTTR_ItemClick(object sender, ItemClickEventArgs e)
        {
            Update_ContentState("ThongTinTamTru");
        }

        private void btnXoaThongTinTTR_ItemClick(object sender, ItemClickEventArgs e)
        {
            // khởi tạo trạng thái mặc định
            if (DeletedTask_SafeKey("Bạn có chắc bạn muốn xóa thông tin tạm trú của người này?"))
            {
                try
                {
                    // gọi sp delete theo các trường hợp

                    // thông báo
                    MessageBox.Show("Xóa thông tin thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    // về trạng thái mặc định
                    ThongTinTamTru_DefaultState(null);
                }
                catch (Exception ex)
                {
                    ErrorInform(ex);
                }
            }
        }

        private void btnHoanTatDKTTR_ItemClick(object sender, ItemClickEventArgs e)
        {
            // kiểm tra cờ và gọi sp
            if (themTamTruMoiFlag == true && themTamTruHienTaiFlag == false && suaTamTruHienTaiFlag == false)
            {
                try
                {
                    var cmnd = gridView1.GetFocusedRowCellDisplayText("SoCMND");
                    // gọi sp insert theo các trường hợp
                    
                    // thông báo
                    MessageBox.Show("Đăng kí tạm trú thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    // tải trạng thái mặc định có chỉ định row được chọn
                    ThongTinTamTru_DefaultState(cmnd);
                }
                catch (Exception ex)
                {
                    ErrorInform(ex);
                }
            }
            else if (themTamTruMoiFlag == false && themTamTruHienTaiFlag == true && suaTamTruHienTaiFlag == false)
            {
                try
                {
                    var cmnd = gridView1.GetFocusedRowCellDisplayText("SoCMND");
                    // gọi sp insert theo các trường hợp

                    // thông báo
                    MessageBox.Show("Đăng kí tạm trú thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    // tải trạng thái mặc định có chỉ định row được chọn
                    ThongTinTamTru_DefaultState(cmnd);
                }
                catch (Exception ex)
                {
                    ErrorInform(ex);
                }
            }
            else if (themTamTruMoiFlag == false && themTamTruHienTaiFlag == false && suaTamTruHienTaiFlag == true)
            {
                try
                {
                    var cmnd = gridView1.GetFocusedRowCellDisplayText("SoCMND");
                    // gọi sp update theo các trường hợp

                    // thông báo
                    MessageBox.Show("Cập nhật thông tin tạm trú thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    // tải trạng thái mặc định có chỉ định row được chọn
                    ThongTinTamTru_DefaultState(cmnd);
                }
                catch (Exception ex)
                {
                    ErrorInform(ex);
                }
            }
        }

        private void btnTaiLaiTTR_ItemClick(object sender, ItemClickEventArgs e)
        {
            ThongTinThuongTru_DefaultState(null);
        }

        private void txtbTTRMaSoHoKhau_TextChanged(object sender, EventArgs e)
        {
            // kiểm tra và tự sinh thông tin
            var ThongTinHoKhau = dbs.ufnThongTinHoKhauCuThe(txtbTTRMaSoHoKhau.Text).ToList();
            if (ThongTinHoKhau.Count() != 0)
            {
                foreach (var tt in ThongTinHoKhau)
                {
                    // điền vào các text box
                    txtbTTRSoNha.Text = tt.SoNha;
                    txtbTTRDuong.Text = tt.Duong;
                    txtbTTRPhuong.Text = tt.Phuong;
                    txtbTTRQuan.Text = tt.Quan;
                    txtbTTRThanhPho.Text = tt.ThanhPho;

                    // phần thông tin sơ lược chủ hộ
                    lblTenChuHoTTR.Text = tt.HoTenChuHo;
                    lblGioiTinhChuHoTTR.Text = tt.GioiTinhChuHo;
                    lblNgaySinhChuHoTTR.Text = tt.NgaySinhChuHo.ToString();
                    lblCMNDChuHoTTR.Text = "CMND: " + tt.CMNDChuHo;
                    LoadPictureToPictureBox((Byte[])tt.HinhAnhChuHo, label16, "Chưa có hình ảnh", picHinhAnhChuHoTTR);

                    break;
                }
            }
            else
            {
                // điền vào các text box
                txtbTTRSoNha.Text = "Chưa rõ ?";
                txtbTTRDuong.Text = "Chưa rõ ?";
                txtbTTRPhuong.Text = "Chưa rõ ?";
                txtbTTRQuan.Text = "Chưa rõ ?";
                txtbTTRThanhPho.Text = "Chưa rõ ?";

                // phần thông tin sơ lược chủ hộ
                lblTenChuHoTTR.Text = "Chưa rõ ?";
                lblGioiTinhChuHoTTR.Text = "Chưa rõ ?";
                lblNgaySinhChuHoTTR.Text = "Chưa rõ ?";
                lblCMNDChuHoTTR.Text = "Chưa rõ ?";
                txtbTTRSoNha.Text = "Chưa rõ ?";
                picHinhAnhChuHoTTR.Image = PhanMemQuanLyNhanKhau.Properties.Resources.person_male1600;
            }
        }

        private void txtbMaSoKT3_TextChanged(object sender, EventArgs e)
        {
            // kiểm tra và tự sinh thông tin
            var ThongTinKT3 = dbs.ufnThongTinKT3CuThe(txtbMaSoKT3.Text).ToList();
            if (ThongTinKT3.Count() != 0)
            {
                foreach (var tt in ThongTinKT3)
                {
                    // điền vào các text box
                    txtbNgayLapSoKT3.Text = tt.NgayCapSo.ToString();

                    // phần thông tin sơ lược chủ hộ
                    lblTenChuKT3.Text = tt.HoTenChuSo;
                    lblGioiTinhChuKT3.Text = tt.GioiTinhChuSo;
                    lblNgaySinhChuKT3.Text = tt.NgaySinhChuSo.ToString();
                    lblCMNDChuKT3.Text = "CMND: " + tt.SoCMNDChuSo;
                    LoadPictureToPictureBox((Byte[])tt.HinhAnhChuSo, label18, "Chưa có hình ảnh", picChuSoKT3);

                    break;
                }
            }
            else
            {
                // điền vào các text box
                txtbNgayLapSoKT3.Text = "Chưa rõ ?";

                // phần thông tin sơ lược chủ hộ
                lblTenChuKT3.Text = "Chưa rõ ?";
                lblGioiTinhChuKT3.Text = "Chưa rõ ?";
                lblNgaySinhChuKT3.Text = "Chưa rõ ?";
                lblCMNDChuKT3.Text = "Chưa rõ ?";
                label18.Text = "Chưa rõ ?";
                picChuSoKT3.Image = PhanMemQuanLyNhanKhau.Properties.Resources.person_male1600;
            }
        }

        private void btnChuyenThuongTru_ItemClick(object sender, ItemClickEventArgs e)
        {
            // khởi tạo trạng thái mặc định
            if (DeletedTask_SafeKey("Bạn có chắc bạn muốn chuyển trạng thái tạm trú thành thường trú cho người này?"))
            {
                try
                {
                    var cmnd = gridView1.GetFocusedRowCellDisplayText("SoCMND");
                    // gọi sp chuyển theo các trường hợp

                    // thông báo
                    MessageBox.Show("Chuyển trạng thái thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    // về trạng thái mặc định
                    ThongTinTamTru_DefaultState(cmnd);
                }
                catch (Exception ex)
                {
                    ErrorInform(ex);
                }
            }
        }
        #endregion
        
    }
}
