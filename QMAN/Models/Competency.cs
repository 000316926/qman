//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QMAN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class competency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public competency()
        {
            this.crn_detail = new HashSet<crn_detail>();
            this.subject = new HashSet<subject>();
        }
    
        public string TafeCompCode { get; set; }
        public string NationalCompCode { get; set; }
        public string CompetencyName { get; set; }
        public int Hours { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crn_detail> crn_detail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<subject> subject { get; set; }
    }
}
