//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhanMemQuanLyNhanKhau
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhanKhauTamTru
    {
        public string NguoiTamTru { get; set; }
        public string ThongTinHoKhau { get; set; }
        public string QuanHeVoiChuHo { get; set; }
        public Nullable<System.DateTime> NgayDKTTR { get; set; }
        public Nullable<bool> DangKyTheoKT3 { get; set; }
        public string ThongTinKT3 { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> DangKyTheoGiay { get; set; }
        public string MaGiayTamTru { get; set; }
    
        public virtual CaNhan CaNhan { get; set; }
        public virtual HoKhau HoKhau { get; set; }
        public virtual KT3 KT3 { get; set; }
    }
}
