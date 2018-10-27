namespace RegiStar.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblTeacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTeacher()
        {
            tblCourses = new HashSet<tblCours>();
        }

        [Key]
        public int teacherID { get; set; }

        public int userID { get; set; }

        [Required]
        [StringLength(20)]
        public string firstName { get; set; }

        [Required]
        [StringLength(20)]
        public string lastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime dob { get; set; }

        [Column(TypeName = "date")]
        public DateTime joinDate { get; set; }

        [Required]
        [StringLength(60)]
        public string address { get; set; }

        [Required]
        [StringLength(15)]
        public string city { get; set; }

        [Required]
        [StringLength(15)]
        public string region { get; set; }

        [Required]
        [StringLength(10)]
        public string postalCode { get; set; }

        [Required]
        [StringLength(15)]
        public string country { get; set; }

        [Required]
        [StringLength(15)]
        public string phone { get; set; }

        [Required]
        [StringLength(30)]
        public string email { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCours> tblCourses { get; set; }

        public virtual tblUser tblUser { get; set; }

        public string fullName { get => firstName + " " + lastName; }
    }
}
