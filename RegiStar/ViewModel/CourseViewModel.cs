using AutoMapper;
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

        private tblBook _book;
        public tblBook Book
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

        private tblTeacher _teacher;
        public tblTeacher Teacher
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
            Book = Mapper.Map<tblBook>(Book);
            Teacher = Mapper.Map<tblTeacher>(Teacher);
            if (Course != null)
            {
                //Book = Course;
                //Teacher = Course.tblTeacher;
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
