using RegiStar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel
{
    public class CourseViewModel : BaseClass
    {
        private tblCours _course;
        public tblCours Course
        {
            get
            {
                return _course;
            }
            set
            {
                _course = value;
                OnPropertyChanged("Course");
            }
        }

        private int _newestCourseID;
        public int NewestCourseID
        {
            get
            {
                return _newestCourseID;
            }
            set
            {
                _newestCourseID = value;
                OnPropertyChanged("NewestCourseID");
            }
        }

        private int _book;
        public int Book
        {
            get
            {
                return _book;
            }
            set
            {
                _book = value;
                OnPropertyChanged("Book");
            }
        }

        private int _teacher;
        public int Teacher
        {
            get
            {
                return _teacher;
            }
            set
            {
                _teacher = value;
                OnPropertyChanged("Teacher");
}
        }

        public CourseViewModel()
        {
            if(Course != null)
            {
                Book = Course.isbn;
                Teacher = Course.teacherID;
            }
        }

        public CourseViewModel(tblCours course, int newestCourseID) : this()
        {
            Course = course;
            NewestCourseID = newestCourseID;
        }

        public CourseViewModel(tblCours course) : this()
        {
            if(course != null)
            {
                Course = course;
            }
        }

        public void Save(tblCours newCourse)
        {
            using (RegistarDbContext db = new RegistarDbContext())
            {
                //Add new newest course ID to the course.
                if(newCourse.courseID == 0)
                newCourse.courseID = NewestCourseID;


                db.tblCourses.Add(newCourse);
                db.SaveChanges();
            }
        }
    }
}
