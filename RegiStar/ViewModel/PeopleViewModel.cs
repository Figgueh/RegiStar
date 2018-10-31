using RegiStar.Model;
using RegiStar.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        private tblUser _username;
        public tblUser Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
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

        public void saveTeacher()
        {
            using (RegistarDbContext db = new RegistarDbContext())
            {
                //Check if the tblUser already exists:
                if (Teacher.userID == 0)
                {
                    //Create the new user first:
                    //Get the newest userID
                    var userID = db.tblUsers.Select(u => u.userID).ToList();

                    var lastUserID = userID.Last();
                    lastUserID += 1;

                    //create a new holder.
                    Username = new tblUser { userID = lastUserID, password = Password, userAccess = 1 };

                    //Try to incert into tblUser
                    db.tblUsers.Add(Username);

                    //add the missing value into Student.
                    Teacher.userID = lastUserID;
                }

                //Select the student table.
                var Teachers = db.tblTeachers;

                //Try to create the new student.
                Teachers.Add(Teacher);

                db.SaveChanges();
            }

            //This will update the teacher number so that the user can enter multiple new teachers.
            //((AdminViewModel)this.DataContext).GetLatestTeacher();

            //TODO: Update list in dropdown list.
            //((AdminViewModel)DataContext).selectedTeacherList = ((AdminViewModel)DataContext).getClasses(); 
        }

        public void saveStudent()
        {
            using (RegistarDbContext db = new RegistarDbContext())
            {
                //Check if the tblUser already exists:
                if(Student.userID == 0)
                {
                    //Create the new user first:
                    //Get the newest userID
                    var userID = db.tblUsers.Select(u => u.userID).ToList();

                    var lastUserID = userID.Last();
                    lastUserID += 1;

                    //create a new holder.
                    Username = new tblUser { userID = lastUserID, password = Password, userAccess = 0 };

                    //Try to incert into tblUser
                    db.tblUsers.Add(Username);

                    //add the missing value into Student.
                    Student.userID = lastUserID;
                }

                //Select the student table.
                var Students = db.tblStudents;

                //Try to create the new student.
                Students.Add(Student);

                db.SaveChanges();
            }

            //TODO: Update list in dropdown list.
            //((AdminViewModel)DataContext).selectedStudentList = ((AdminViewModel)DataContext).getStudentNames(); 
        }

    }
}
