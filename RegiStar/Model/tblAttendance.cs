namespace RegiStar.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblAttendance
    {
        [Key]
        public int attendanceID { get; set; }

        [Column(TypeName = "date")]
        public DateTime attendanceDate { get; set; }

        public int studentID { get; set; }

        public int courseID { get; set; }

        public bool status { get; set; }

        [StringLength(250)]
        public string remarks { get; set; }

        public virtual tblCours tblCours { get; set; }

        public virtual tblStudent tblStudent { get; set; }
    }
}
