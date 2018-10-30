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
    public partial class PeopleViewTeacher : Window
    {
        tblTeacher teacher;
        PeopleViewModel peopleViewModel;

        //Constructor when sending the window nothing
        public PeopleViewTeacher()
        {
            InitializeComponent();
        }


        //Constructor when sending a new teacher
        public PeopleViewTeacher(tblTeacher teacher, int newestID) : this()
        {
            //Create a new teacher with the newest teacherID
            teacher = new tblTeacher { teacherID = newestID };

            //Send it to the view model.
            peopleViewModel = new PeopleViewModel(teacher);
            this.DataContext = peopleViewModel;

            //Show the teacher controls.
            passwordStack.Visibility = Visibility.Visible;
            this.Title = "New teacher :";
            labelHeader.Content = "Please enter the following information to create a new teacher.";
        }

        //Constructor when editing teacher.
        public PeopleViewTeacher(tblTeacher teacher) : this()
        {
            //Send it to the view model.
            peopleViewModel = new PeopleViewModel(teacher);
            this.DataContext = peopleViewModel;

            //Show the teacher controls.
            this.Title = "Edit teacher :";
            labelHeader.Content = "Editing teacher " + teacher.fullName;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            peopleViewModel.saveTeacher();
            this.Close();
        }
    }
}
