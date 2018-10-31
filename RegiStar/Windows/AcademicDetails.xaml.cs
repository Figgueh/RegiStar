using RegiStar.Model;
using RegiStar.ViewModel;
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

namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for AcademicDetails.xaml
    /// </summary>
    public partial class AcademicDetails : Window
    {

        //public List<tblStudent> stList { get; set; }
        //public ObservableCollection<tblStudent> studList { get; set; }
        //public object userinfo;
        //public tblUser userinfo { get; set; }
        //public tblStudent student;

        private void Init()
        {
            InitializeComponent();
            this.DataContext = new AcademicDetailsViewModel();

        }

        public AcademicDetails()
        {
            Init();

        }

        public AcademicDetails(tblUser userinfo)
        {
            Init();
            ((AcademicDetailsViewModel)this.DataContext).userinfo = userinfo;

        }




        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ((AcademicDetailsViewModel)this.DataContext).getStudentNames();
            ((AcademicDetailsViewModel)this.DataContext).getAttendances();
            ((AcademicDetailsViewModel)this.DataContext).getMedium();
            ((AcademicDetailsViewModel)this.DataContext).GetCourses();
        }
    }
}
