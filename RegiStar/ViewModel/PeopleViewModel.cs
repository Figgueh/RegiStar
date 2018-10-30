using RegiStar.Model;
using RegiStar.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel
{
    public class PeopleViewModel : BaseClass
    {
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

        private tblStudent _student;
        public tblStudent Student
        {
            get
            {
                return _student;
            }
            set
            {
                _student = value;
                OnPropertyChanged("Student");
            }
        }

        public PeopleViewModel(tblStudent tblStudent)
        {
            Student = tblStudent;
        }

        public PeopleViewModel(tblTeacher teacher)
        {
            Teacher = teacher;
        }

        public void saveStudent(tblStudent student)
        {
            using(RegistarDbContext db = new RegistarDbContext())
            {
                //Select the student table.
                var Students = db.tblStudents;
                

                Students.Add(student);
                db.SaveChanges();
            }

            
            //listStudent.ItemsSource = AdminView.getStudentsInClass();
        }

    }
}
