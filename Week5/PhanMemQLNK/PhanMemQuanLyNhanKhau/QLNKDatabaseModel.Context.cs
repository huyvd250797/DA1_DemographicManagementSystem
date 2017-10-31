﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QuanLyNhanKhauEntities : DbContext
    {
        public QuanLyNhanKhauEntities()
            : base("name=QuanLyNhanKhauEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CaNhan> CaNhans { get; set; }
        public virtual DbSet<HoKhau> HoKhaus { get; set; }
        public virtual DbSet<KT3> KT3 { get; set; }
        public virtual DbSet<NhanKhauTamTru> NhanKhauTamTrus { get; set; }
        public virtual DbSet<NhanKhauTamVang> NhanKhauTamVangs { get; set; }
        public virtual DbSet<NhanKhauThuongTru> NhanKhauThuongTrus { get; set; }
    
        [DbFunction("QuanLyNhanKhauEntities", "ufnDanhSachCaNhan")]
        public virtual IQueryable<ufnDanhSachCaNhan_Result> ufnDanhSachCaNhan()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnDanhSachCaNhan_Result>("[QuanLyNhanKhauEntities].[ufnDanhSachCaNhan]()");
        }
    
        [DbFunction("QuanLyNhanKhauEntities", "ufnDanhSachTamTruCoKT3")]
        public virtual IQueryable<ufnDanhSachTamTruCoKT3_Result> ufnDanhSachTamTruCoKT3()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnDanhSachTamTruCoKT3_Result>("[QuanLyNhanKhauEntities].[ufnDanhSachTamTruCoKT3]()");
        }
    
        [DbFunction("QuanLyNhanKhauEntities", "ufnDanhSachTamTruKhongKT3")]
        public virtual IQueryable<ufnDanhSachTamTruKhongKT3_Result> ufnDanhSachTamTruKhongKT3()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnDanhSachTamTruKhongKT3_Result>("[QuanLyNhanKhauEntities].[ufnDanhSachTamTruKhongKT3]()");
        }
    
        [DbFunction("QuanLyNhanKhauEntities", "ufnThongTinHoKhauCuThe")]
        public virtual IQueryable<ufnThongTinHoKhauCuThe_Result> ufnThongTinHoKhauCuThe(string masohokhau)
        {
            var masohokhauParameter = masohokhau != null ?
                new ObjectParameter("masohokhau", masohokhau) :
                new ObjectParameter("masohokhau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnThongTinHoKhauCuThe_Result>("[QuanLyNhanKhauEntities].[ufnThongTinHoKhauCuThe](@masohokhau)", masohokhauParameter);
        }
    
        [DbFunction("QuanLyNhanKhauEntities", "ufnThongTinKT3CuThe")]
        public virtual IQueryable<ufnThongTinKT3CuThe_Result> ufnThongTinKT3CuThe(string masokt3)
        {
            var masokt3Parameter = masokt3 != null ?
                new ObjectParameter("masokt3", masokt3) :
                new ObjectParameter("masokt3", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnThongTinKT3CuThe_Result>("[QuanLyNhanKhauEntities].[ufnThongTinKT3CuThe](@masokt3)", masokt3Parameter);
        }
    }
}