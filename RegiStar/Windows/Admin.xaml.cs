using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RegiStar.Model;
using RegiStar.ViewModel;


namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
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
            using (RegistarModel dbInfo = new RegistarModel())
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
            using (RegistarModel dbInfo = new RegistarModel())
            {
                //Fetech the courses.
                var query = dbInfo.tblCourses.ToList<tblCours>();

                //Initialize the list to the list of courses
                courseList = new List<tblCours>(query);
            }

            //return the newly initlaized list.
            return courseList;
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
            tblCours selectedClass = ddlClass.SelectedValue as tblCours;
            var selectedStudent = ddlStudent.SelectedValue as tblStudent;

            //Try to add the selected student into the selected class list.
            using(RegistarModel dbInfo = new RegistarModel())
            {
                var query = dbInfo.tblCourses
                    .Where(i => i.courseID == selectedClass.courseID)
                    .Select(l => l.tblStudents.ToList());

                //studentsInClass = new List<tblStudent>(query);
            }



        }
    }
}
