//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoBrandingSEO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SaveGioHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SaveGioHang()
        {
            this.profilegiohangs = new HashSet<profilegiohang>();
        }
    
        public int masave { get; set; }
        public Nullable<int> maKH { get; set; }
    
        public virtual Khachhang Khachhang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<profilegiohang> profilegiohangs { get; set; }
    }
}
