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
    
    public partial class CaNhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaNhan()
        {
            this.HoKhaus = new HashSet<HoKhau>();
            this.KT3 = new HashSet<KT3>();
        }
    
        public string SoCMND { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string NguyenQuan { get; set; }
        public Nullable<System.DateTime> NgayCap { get; set; }
        public string NoiCap { get; set; }
        public byte[] HinhAnh { get; set; }
        public string TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoKhau> HoKhaus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KT3> KT3 { get; set; }
        public virtual NhanKhauTamTru NhanKhauTamTru { get; set; }
        public virtual NhanKhauTamVang NhanKhauTamVang { get; set; }
        public virtual NhanKhauThuongTru NhanKhauThuongTru { get; set; }
    }
}
