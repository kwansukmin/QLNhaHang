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
    
    public partial class NhomMon
    {
        public NhomMon()
        {
            this.ThucDons = new HashSet<ThucDon>();
        }
    
        public int NhomMonID { get; set; }
        public string TenNhomMon { get; set; }
        public int PhanLoaiID { get; set; }
        public string BiDanh { get; set; }
    
        public virtual PhanLoai PhanLoai { get; set; }
        public virtual ICollection<ThucDon> ThucDons { get; set; }
    }
}