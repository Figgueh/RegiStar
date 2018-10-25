namespace RegiStar.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblGrade
    {
        [Key]
        public int gradeID { get; set; }

        public int studentID { get; set; }

        public int courseID { get; set; }

        public int grade { get; set; }

        [StringLength(250)]
        public string teacherComments { get; set; }

        public virtual tblCours tblCours { get; set; }

        public virtual tblStudent tblStudent { get; set; }
    }
}
