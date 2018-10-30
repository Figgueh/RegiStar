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
            //Every time the user selected a new item, update the student class list.
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
            PeopleView newStudent = new PeopleView(new tblStudent(), AdminView.NewestStudent);
            newStudent.Show();
            listStudent.ItemsSource = AdminView.getStudentsInClass();

        }

        //Edit Student
        private void btnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            if(AdminView.selectedStudentList != null)
            {
                PeopleView editStudent = new PeopleView(AdminView.selectedStudentList);
                editStudent.Show();
            }
            else
            {
                MessageBox.Show("You haven't selected a student from the dowpdown list yet!", "ERROR: Please make a selection.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        //New teacher
        private void btnNewTeacher_Click(object sender, RoutedEventArgs e)
        {
            PeopleViewTeacher newTeacher = new PeopleViewTeacher(new tblTeacher(), AdminView.NewestTeacher);
            newTeacher.Show();
        }

        //Edit Teacher
        private void btnEditTeacher_Click(object sender, RoutedEventArgs e)
        {
            if(AdminView.TeacherForCourse != null)
            {
                PeopleViewTeacher editTeacher = new PeopleViewTeacher(AdminView.TeacherForCourse);
                editTeacher.Show();
            }
            else
            {
                MessageBox.Show("You haven't selected a coruse from the dowpdown list yet!", "ERROR: Please make a selection.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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
            if(AdminView.selectedCourseList != null)
            {
                CourseWindow editCourseWindow = new CourseWindow(AdminView.selectedCourseList);
                
                editCourseWindow.Show();
            }
            else
            {
                MessageBox.Show("You haven't selected a coruse from the dowpdown list yet!", "ERROR: Please make a selection.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Remove all students
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(AdminView.selectedCourseList != null)
            {
                AdminView.DeleteAll();
                listStudent.ItemsSource = AdminView.getStudentsInClass();
            }
            else
            {
                MessageBox.Show("You haven't selected a coruse from the dowpdown list yet!", "ERROR: Please make a selection.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Remove the selected coruse
        private void btnRemoveClass_Click(object sender, RoutedEventArgs e)
        {
            if(AdminView.selectedCourseList != null)
            {
                AdminView.RemoveClass();
                ddlClass.ItemsSource = AdminView.getClasses();
            }
            else
            {
                MessageBox.Show("You haven't selected a coruse from the dowpdown list yet!", "ERROR: Please make a selection.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        //Remove selected student
        private void btnRemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            if(AdminView.selectedStudentsInClass != null)
            {
                AdminView.RemoveSelectedStudent();
                listStudent.ItemsSource = AdminView.getStudentsInClass();
            }
            else
            {
                MessageBox.Show("You haven't selected a student from the list yet!", "ERROR: Please make a selection.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
