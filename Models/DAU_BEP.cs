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
    
    public partial class DAU_BEP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DAU_BEP()
        {
            this.MONs = new HashSet<MON>();
        }
    
        public string MADB { get; set; }
        public string TENDB { get; set; }
        public string QUEQUAN { get; set; }
        public string SDT { get; set; }
        public string CAPBAC { get; set; }
        public string LUONG { get; set; }
        public string MAPHANQUYEN { get; set; }
    
        public virtual QUYEN QUYEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MON> MONs { get; set; }
    }
}
