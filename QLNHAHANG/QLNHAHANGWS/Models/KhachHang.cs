//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNHAHANGWS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhachHang
    {
        public KhachHang()
        {
            this.DatHangs = new HashSet<DatHang>();
        }
    
        public int KhachHangID { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Email { get; set; }
        public string Hinh { get; set; }
    
        public virtual ICollection<DatHang> DatHangs { get; set; }
    }
}
