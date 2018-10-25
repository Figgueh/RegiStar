namespace RegiStar.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCourses")]
    public partial class tblCours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCours()
        {
            tblAttendances = new HashSet<tblAttendance>();
            tblCourseDetails = new HashSet<tblCourseDetail>();
            tblGrades = new HashSet<tblGrade>();
            tblStudents = new HashSet<tblStudent>();
        }

        [Key]
        public int courseID { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        [StringLength(250)]
        public string description { get; set; }

        public int isbn { get; set; }

        public int teacherID { get; set; }

        [Required]
        [StringLength(2)]
        public string section { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAttendance> tblAttendances { get; set; }

        public virtual tblBook tblBook { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCourseDetail> tblCourseDetails { get; set; }

        public virtual tblTeacher tblTeacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGrade> tblGrades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblStudent> tblStudents { get; set; }
    }
}
