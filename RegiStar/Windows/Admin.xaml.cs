using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        AdminViewModel AdminView;

        public Admin()
        {
            InitializeComponent();
            AdminView = new AdminViewModel();
            this.DataContext = AdminView;
        }

        private void ddlClass_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            listStudent.ItemsSource = AdminView.getStudentsInClass();

        }

        //Add student to classlist.
        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            AdminView.addStudent();
            listStudent.ItemsSource = AdminView.getStudentsInClass();
        }


        //New student
        private void btnNewStudent_Click(object sender, RoutedEventArgs e)
        {
            PeopleView newStudent = new PeopleView(new tblStudent());
            newStudent.Show();
        }

        //Edit Student
        private void btnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            PeopleView editStudent = new PeopleView(AdminView.selectedStudentList);
            editStudent.Show();
        }

        //New teacher
        private void btnNewTeacher_Click(object sender, RoutedEventArgs e)
        {
            PeopleView newTeacher = new PeopleView(new tblTeacher());
            newTeacher.Show();
        }

        //Edit Teacher
        private void btnEditTeacher_Click(object sender, RoutedEventArgs e)
        {
            //TODO: FIND A WAY TO SEND THE TEACHER INFO.
            PeopleView editTeacher = new PeopleView(AdminView.selectedCourseList.tblTeacher);
            editTeacher.Show();
        }

        //New Course
        private void NewCourse_Click(object sender, RoutedEventArgs e)
        {
            CourseWindow newCourseWindow = new CourseWindow(new tblCours());
            newCourseWindow.Show();
        }

        //Edit Course
        private void EditCourse_Click(object sender, RoutedEventArgs e)
        {
            CourseWindow editCourseWindow = new CourseWindow(AdminView.selectedCourseList);
            editCourseWindow.Show();
        }

        //Remove all students
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminView.DeleteAll();
        }

        private void btnRemoveClass_Click(object sender, RoutedEventArgs e)
        {
            AdminView.RemoveClass();
        }
    }
}
