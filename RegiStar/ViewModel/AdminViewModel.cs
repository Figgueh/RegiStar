using RegiStar.Model;
using RegiStar.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel
{
    public class AdminViewModel : BaseClass
    {
        
        //Course list entities:
        public ObservableCollection<tblCours> courseList { get; set; }
        private tblCours _selectedCourseList;
        public tblCours selectedCourseList
        {
            get
            {
                return _selectedCourseList;
            }
            set
            {
                _selectedCourseList = value;
                OnPropertyChanged("selectedCourseList");
            }
        }

        //Student list entities:
        public ObservableCollection<tblStudent> studentList { get; set; }
        private tblStudent _selectedStudentList;
        public tblStudent selectedStudentList
        {
            get
            {
                return _selectedStudentList;
            }
            set
            {
                _selectedStudentList = value;
                OnPropertyChanged("selectedStudentList");
            }
        }

        //entities for the list of students in a class:
        public ObservableCollection<tblStudent> studentsInClass { get; set; }
        private tblStudent _selectedStudentsInClass;
        public tblStudent selectedStudentsInClass
        {
            get
            {
                return _selectedStudentsInClass;
            }
            set
            {
                _selectedStudentsInClass = value;
                OnPropertyChanged("selectedStudentsInClass");
            }
        }

        public AdminViewModel()
        {
            getStudentNames();
            getClasses();
        }

        public void addStudent()
        {
            using (RegistarDbContext db = new RegistarDbContext())
            {
                var query = db.tblCourses
                .Select(s => s.tblStudents);

                foreach (var item in query)
                {
                    item.Add(selectedStudentList);
                }
                db.SaveChanges();
            }

        }

        /// <summary>
        /// This function gets all the students in the selected class,
        /// then sends all the information into a list of Students for the listView.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<tblStudent> getStudentsInClass()
        {
            //Clear the list.
            studentsInClass = new ObservableCollection<tblStudent>();

            //Select the class ID from the dropdown list.
            int selectedClassID = selectedCourseList.courseID;


            //Get all the students from the selected class.
            using (RegistarDbContext dbInfo = new RegistarDbContext())
            {

                var classList = dbInfo.tblCourses
                    .Where(n=>n.courseID == selectedClassID)
                    .SelectMany(s => s.tblStudents).ToList();

                studentsInClass = new ObservableCollection<tblStudent>(classList);

                #region Old way for getting list then casting into new student.
                //Old way for getting list.
                //var list =
                //    from s in dbInfo.tblStudents
                //    from course in s.tblCourses
                //    where course.courseID == selectedClassID
                //    select new Student
                //    {
                //        FirstName = s.firstName,
                //        LastName = s.lastName,
                //        Address = s.address,
                //        City = s.city,
                //        Country = s.country,
                //        Dob = s.dob,
                //        Email = s.email,
                //        JoinDate = s.joinDate,
                //        Phone = s.phone,
                //        PostalCode = s.postalCode,
                //        Region = s.region,
                //        Status = s.status,
                //        StudentID = s.studentID
                //    };

                //foreach (var item in cs as IQueryable<tblStudent>)
                //{
                //    studentsInClass.Add(item);
                //}
                #endregion
            }
            return studentsInClass;
        }


        /// <summary>
        /// This function gets all the students in our table,
        /// then sends all the information into a list of tblStudents.
        /// </summary>
        /// <returns> The list of all the students in the database. </returns>
        public ObservableCollection<tblStudent> getStudentNames()
        {
            studentList = new ObservableCollection<tblStudent>();

            using (RegistarDbContext dbInfo = new RegistarDbContext())
            {
                //Fetech the students.
                var query = dbInfo.tblStudents.ToList<tblStudent>();

                //Initialize the list to the list of courses
                studentList = new ObservableCollection<tblStudent>(query);
            }

            //return the newly initlaized list.
            return studentList;
        }

        /// <summary>
        /// This function gets all the cources in our table,
        /// then sends all the information into a list of tblCources.
        /// </summary>
        /// <returns> The list of all the courses in the database. </returns>
        public ObservableCollection<tblCours> getClasses()
        {
            courseList = new ObservableCollection<tblCours>();

            using (RegistarDbContext dbInfo = new RegistarDbContext())
            {
                //Fetech the courses.
                var query = dbInfo.tblCourses.ToList<tblCours>();

                //Initialize the list to the list of courses
                courseList = new ObservableCollection<tblCours>(query);
            }

            //return the newly initlaized list.
            return courseList;
        }
    }
}
