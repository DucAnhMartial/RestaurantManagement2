//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace coderush.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DON_DAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_DAT()
        {
            this.HOA_DON = new HashSet<HOA_DON>();
        }
    
        public string MADONDAT { get; set; }
        public string MAKH { get; set; }
        public int SOBAN { get; set; }
        public string HINHTHUC { get; set; }
    
        public virtual BAN BAN { get; set; }
        public virtual KHACH_HANG KHACH_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOA_DON> HOA_DON { get; set; }
    }
}
