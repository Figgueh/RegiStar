using RegiStar.Model;
using RegiStar.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RegiStar.ViewModel
{
    public class AdminViewModel : BaseClass
    {

        tblCours course;
        tblStudent student;


        //Course list entities:
        private ObservableCollection<tblCours> _courseList;
        public ObservableCollection<tblCours> courseList
        {         
            get
            {
                    return _courseList;
            }
            set
            {
                    _courseList = value;
                    OnPropertyChanged("courseList");
            }
        }

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
        private ObservableCollection<tblStudent> _studentList;
        public ObservableCollection<tblStudent> studentList
        {
            get
            {
                return _studentList;
            }
            set
            {
                _studentList = value;
                OnPropertyChanged("studentList");
            }
        }

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
        private ObservableCollection<tblStudent> _studentsInClass;
        public ObservableCollection<tblStudent> studentsInClass
        {
            get
            {
                return _studentsInClass;
            }
            set
            {
                _studentsInClass = value;
                OnPropertyChanged("studentsInClass");
            }
        }

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

        private tblTeacher _teacherForCourse;
        public tblTeacher TeacherForCourse
        {
            get
            {
                return _teacherForCourse;
            }
            set
            {
                _teacherForCourse = value;
                OnPropertyChanged("TeacherForCourse");
            }
        }

        private string _classname;
        public string className
        {
            get
            {
                return _classname;
            }
            set
            {
                _classname = value;
                OnPropertyChanged("className");
            }
        }

        private int _newestStudent;
        public int NewestStudent
        {
            get
            {
                return _newestStudent;
            }
            set
            {
                _newestStudent = value;
                OnPropertyChanged("NewestStudent");
            }
        }

        private int _newestTeacher;
        public int NewestTeacher
        {
            get
            {
                return _newestTeacher;
            }
            set
            {
                _newestTeacher = value;
                OnPropertyChanged("NewestTeacher");
            }
        }

        public AdminViewModel()
        {
            getStudentNames();
            getClasses();
            GetLatestTeacher();
        }

        /// <summary>
        /// This function removes the selected class from the database.
        /// </summary>
        public void RemoveClass()
        {
            //Get the course we want to remove.
            course = selectedCourseList;

            //Display message to confirm action.
            switch (MessageBox.Show(
                String.Format("This will remove the course {0}. Are you sure you want to remove this course?", course.name),
                "WARNING: Are you sure you want to remove the course?", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                case MessageBoxResult.Yes:
                    using (RegistarDbContext db = new RegistarDbContext())
                    {
                        var classList = db.tblCourses
                            .Where(id => id.courseID == course.courseID)
                            .Select(c => c).FirstOrDefault();

                        db.tblCourses.Remove(classList);
                        db.SaveChanges();
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }

        /// <summary>
        /// This function takes which ever values that are in the drop down list,
        /// Then tries to add the selected student into the selected course.
        /// </summary>
        public void addStudent()
        {
            //Get the course ID thats been selected.
            var selectedCourseID = selectedCourseList.courseID;

            using (RegistarDbContext db = new RegistarDbContext())
            {
                //Find the course in the database.
                var course = db.tblCourses.Where(c => c.courseID == selectedCourseID).FirstOrDefault();

                //Find the student to add from the database.
                var student = db.tblStudents.Where(s => s.studentID == selectedStudentList.studentID).FirstOrDefault();

                if (checkIfExists(course, student))
                    MessageBox.Show("The student is already in the list!", "ERROR: ", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    //Add it to the coruses student list.
                    course.tblStudents.Add(student);
                    db.SaveChanges();
                    MessageBox.Show(String.Format("{0} was successfully enrolled in {1}!", student.fullName, course.name), "Student successfully added!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        /// <summary>
        /// Takes the course and student
        /// Then loops threw each student in the selected class
        /// returns true if the student already exists
        /// </summary>
        /// <param name="cours">The selected course from the dropdown list</param>
        /// <param name="student">The selected student from the dropdown list</param>
        /// <returns></returns>
        public bool checkIfExists(tblCours cours, tblStudent student)
        {
            foreach(var item in cours.tblStudents)
            {
                if (item.studentID == student.studentID)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// This function prompts you with a messagebox that as if you want to remove all the students from the list,
        /// It then removes each student.
        /// </summary>
        public void DeleteAll()
        {
            //Get the course that we want to remove.
            course = selectedCourseList;

            //Display message to confirm action.
            switch (MessageBox.Show(
                String.Format("This will remove all the students from {0}. Are you sure you want to perform this action?",course.name), 
                "WARNING: Are you sure you want to clear the class list?", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    using(RegistarDbContext db = new RegistarDbContext())
                    {
                        //Select all the classes with the course ID.
                        var classList = db.tblCourses.Where(c => c.courseID == course.courseID).FirstOrDefault();

                        //Select all the students you want to delete.
                        var studentsInClass = db.tblCourses
                            .Where(n => n.courseID == course.courseID)
                            .SelectMany(s => s.tblStudents);

                        //For each of the students that we want to delete:
                        foreach (var item in studentsInClass)
                        {
                            //Remove it from the student list in the coresponding course list.
                            classList.tblStudents.Remove(item);
                        }
                        db.SaveChanges();
                        MessageBox.Show(String.Format("{0} was cleared successfully!", course.name), "Course successfully cleared", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        /// <summary>
        /// This function gets the student that you've selected in the class list,
        /// Then removes it.
        /// </summary>
        public void RemoveSelectedStudent()
        {
            //Get the course that we want to remove from.
            course = selectedCourseList;


            using (RegistarDbContext db = new RegistarDbContext())
            {
                //Get the class list.
                var classList = db.tblCourses.Where(c => c.courseID == course.courseID).FirstOrDefault();

                //Get the student infromation from the database.
                var studentToRemove = db.tblStudents.Where(s => s.studentID == selectedStudentsInClass.studentID).FirstOrDefault();

                //Remove the selected student.
                classList.tblStudents.Remove(studentToRemove);

                db.SaveChanges();
                MessageBox.Show(String.Format("{0} was removed successfully!", studentToRemove.fullName), "Student successfully removed", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }


        /// <summary>
        /// This function gets all the students in the selected class,
        /// then sends all the information into a list of Students for the listView.
        /// </summary>
        /// <returns>List of tblStudent in each course.</returns>
        public ObservableCollection<tblStudent> getStudentsInClass()
        {
            //Clear the list.
            studentsInClass = new ObservableCollection<tblStudent>();

            //Declate variables.
            int selectedClassID;


            if (selectedCourseList != null)
            {
                //Select the class ID from the dropdown list.
                selectedClassID = selectedCourseList.courseID;

                //Select the name from the classID in the dropdown list.
                className = selectedCourseList.name;


                //Get all the students from the selected class.
                using (RegistarDbContext dbInfo = new RegistarDbContext())
                {

                    var classList = dbInfo.tblCourses.AsNoTracking()
                        .Where(n=>n.courseID == selectedClassID)
                        .SelectMany(s => s.tblStudents).ToList();

                    TeacherForCourse = dbInfo.tblCourses
                        .Where(c => c.courseID == selectedClassID)
                        .Select(t => t.tblTeacher).FirstOrDefault();

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

            //Get the last student ID and add 1 for the new student.
            NewestStudent = studentList.Select(s => s.studentID).Last() + 1;

            //return the newly initlaized list.
            return studentList;
        }

        /// <summary>
        /// This function runs a query that selected the latest teacher and adds 1 to the value so that we can create a new teacher.
        /// </summary>
        public void GetLatestTeacher()
        {
            using(RegistarDbContext db = new RegistarDbContext())
            {
                //Get the last teacher ID and add 1 for the newest Teacher.
                var getNewestTeacher = db.tblTeachers.Select(t => t.teacherID).ToList();

                NewestTeacher = getNewestTeacher.Last() + 1;
            }
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
