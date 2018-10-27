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
            //Ask how we can remove this.
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
            PeopleView editTeacher = new PeopleView(AdminView.selectedCourseList.tblTeacher);
            editTeacher.Show();
        }

        
    }
}
