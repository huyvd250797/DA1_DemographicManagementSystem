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
    
    public partial class NhanKhauTamVang
    {
        public string NguoiTamVang { get; set; }
        public string DiaChiTamVang { get; set; }
        public string DiaChiOTam { get; set; }
        public Nullable<System.DateTime> TamVangTu { get; set; }
        public Nullable<System.DateTime> TamVangDen { get; set; }
        public string GhiChu { get; set; }
    
        public virtual CaNhan CaNhan { get; set; }
        public virtual HoKhau HoKhau { get; set; }
    }
}
