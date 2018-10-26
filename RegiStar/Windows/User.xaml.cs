using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.SqlClient;
using RegiStar.ViewModel;
using RegiStar.Model;

namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>






    public partial class User : Window
    {
        
        private void Init()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel();
        }

        public User()
        {
            Init();
        }

        public User(tblUser userinfo)
        {
            Init();
            ((UserViewModel)this.DataContext).userinfo = userinfo;
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            var context = (UserViewModel)this.DataContext;
            context.addCourse();
        }

        private void btnAcademicDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveClass_Click(object sender, RoutedEventArgs e)
        {
           // selectedCoursesList.Remove(lstSelectedClasses.SelectedValue as Course);
        }

        private void btnRemoveAll_Click(object sender, RoutedEventArgs e)
        {

          //  selectedCoursesList = new ObservableCollection<Course>();
           // lstSelectedClasses.ItemsSource = selectedCoursesList;

        }

        private void txtUserID_Loaded(object sender, RoutedEventArgs e)
        {
          //txtUserID.Text = Convert.ToString(userinfo.userID);
           
        }
    }
}
