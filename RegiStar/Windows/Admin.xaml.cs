using System.Collections.Generic;
using System.Linq;
using System.Windows;
using RegiStar.Model;
using RegiStar.ViewModel;

namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        //https://github.com/johnpapa/CodeCamper/blob/master/CodeCamper.Data/EFRepository.cs
        //Repo for managing list.

        //https://www.dofactory.com
        //For Design Pattern

        //snoop wpf
        //For WPF decompiler.

        public static List<tblStudent> studentList;
        public static List<tblCours> courseList;
        public static List<tblStudent> studentsInClass;


        public Admin()
        {
            InitializeComponent();

            //Initialize the list of students for the dropdown list.
            ddlStudent.ItemsSource = getStudentNames();
            ddlStudent.DisplayMemberPath = "firstName";

            //Initialize the list of courses for the dropdown list.
            ddlClass.ItemsSource = getClasses();
            ddlClass.DisplayMemberPath = "name";

        }

        /// <summary>
        /// This function gets all the students in our table,
        /// then sends all the information into a list of tblStudents.
        /// </summary>
        /// <returns> The list of all the students in the database. </returns>
        public List<tblStudent> getStudentNames()
        {
            using (MainModel dbInfo = new MainModel())
            {
                //Fetech the students.
                var query = dbInfo.tblStudents.ToList<tblStudent>();

                //Initialize the list to the list of students
                studentList = new List<tblStudent>(query);
            }

            //return the newly initlaized list.
            return studentList;
        }

        /// <summary>
        /// This function gets all the cources in our table,
        /// then sends all the information into a list of tblCources.
        /// </summary>
        /// <returns> The list of all the courses in the database. </returns>
        public List<tblCours> getClasses()
        {
            using (MainModel dbInfo = new MainModel())
            {
                //Fetech the courses.
                var query = dbInfo.tblCourses.ToList<tblCours>();

                //Initialize the list to the list of courses
                courseList = new List<tblCours>(query);
            }

            //return the newly initlaized list.
            return courseList;
        }

        public void getStudentsInClass()
        {
            Course selectedClass = ddlClass.SelectedValue as Course;

            //Try to add the selected student into the selected class list.
            using (MainModel dbInfo = new MainModel())
            {
               var query = from c in dbInfo.tblCourses                            
                            where(c.courseID == selectedClass.CourseID)
                            select c.tblStudents;

                foreach(var student in query)
                {
                    //studentsInClass.Add(new Student(student));
                }

            }
            listStudent.ItemsSource = studentsInClass;
        }



        /// <summary>
        /// This function gets the values selected in the dropdown list,
        /// then adds the selected student in the class list for the selected class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            //Get the selected values in the dropdown list.
            Course selectedClass = ddlClass.SelectedValue as Course;
            Student selectedStudent = ddlStudent.SelectedValue as Student;





        }

        private void ddlClass_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            getStudentsInClass();
        }
    }
}
