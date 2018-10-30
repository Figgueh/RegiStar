namespace RegiStar.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RegistarDbContext : DbContext
    {
        public RegistarDbContext()
            : base("name=RegistarModel")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAttendance> tblAttendances { get; set; }
        public virtual DbSet<tblBook> tblBooks { get; set; }
        public virtual DbSet<tblCourseDetail> tblCourseDetails { get; set; }
        public virtual DbSet<tblCours> tblCourses { get; set; }
        public virtual DbSet<tblGrade> tblGrades { get; set; }
        public virtual DbSet<tblStudent> tblStudents { get; set; }
        public virtual DbSet<tblTeacher> tblTeachers { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBook>()
                .HasMany(e => e.tblCourses)
                .WithRequired(e => e.tblBook)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCours>()
                .Property(e => e.section)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblCours>()
                .HasMany(e => e.tblAttendances)
                .WithRequired(e => e.tblCours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCours>()
                .HasMany(e => e.tblCourseDetails)
                .WithRequired(e => e.tblCours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCours>()
                .HasMany(e => e.tblGrades)
                .WithRequired(e => e.tblCours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCours>()
                .HasMany(e => e.tblStudents)
                .WithMany(e => e.tblCourses)
                .Map(m => m.ToTable("tblClassRoomStudents").MapLeftKey("courseID").MapRightKey("studentID"));

            modelBuilder.Entity<tblStudent>()
                .HasMany(e => e.tblAttendances)
                .WithRequired(e => e.tblStudent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblStudent>()
                .HasMany(e => e.tblGrades)
                .WithRequired(e => e.tblStudent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblTeacher>()
                .HasMany(e => e.tblCourses)
                .WithRequired(e => e.tblTeacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblStudents)
                .WithRequired(e => e.tblUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblTeachers)
                .WithRequired(e => e.tblUser)
                .WillCascadeOnDelete(false);
        }
    }
}
