using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegiStar.Model;
using RegiStar.ViewModel;

namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class PeopleView : Window
    {
        tblStudent _student;
        tblTeacher _teacher;
        PeopleViewModel peopleViewModel;

        //Constructor when sending the window nothing
        public PeopleView()
        {
            InitializeComponent();
        }


        //Constructor when sending the window a student.
        public PeopleView(tblStudent student)
        {
            _student = student;
            InitializeComponent();
            peopleViewModel = new PeopleViewModel(_student);
            this.DataContext = peopleViewModel;
            stackStudent.Visibility = Visibility.Visible;

            if (student.firstName != null)
            {
                this.Title = "Edit student :";
                labelHeader.Content = "Editing student " + student.fullName;
            }
            else
            {
                this.Title = "New student :";
                labelHeader.Content = "Please enter the following information to create a new student.";
            }
                

        }

        //Constructor when sending the window a student.
        public PeopleView(tblTeacher teacher)
        {
            _teacher = teacher;
            InitializeComponent();
            peopleViewModel = new PeopleViewModel(_teacher);
            this.DataContext = peopleViewModel;
            stackTeacher.Visibility = Visibility.Visible;



            if (teacher.firstName != null)
            {
                this.Title = "Edit teacher :";
                labelHeader.Content = "Editing teacher " + teacher.fullName;
            }
            else
            {
                this.Title = "New teacher :";
                labelHeader.Content = "Please enter the following information to create a new teacher.";
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            peopleViewModel.saveStudent(_student);
        }
    }
}
