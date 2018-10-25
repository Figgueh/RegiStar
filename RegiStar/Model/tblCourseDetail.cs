namespace RegiStar.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCourseDetail
    {
        [Key]
        public int courseDetail { get; set; }

        public int courseID { get; set; }

        public DateTime start { get; set; }

        public DateTime finish { get; set; }

        public virtual tblCours tblCours { get; set; }
    }
}
