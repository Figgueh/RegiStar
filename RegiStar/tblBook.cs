//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegiStar
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblBook()
        {
            this.tblCourses = new HashSet<tblCours>();
        }
    
        public int isbn { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string synopsis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCours> tblCourses { get; set; }
    }
}