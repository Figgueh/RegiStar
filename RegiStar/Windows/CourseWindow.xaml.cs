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
    /// Interaction logic for NewCourse.xaml
    /// </summary>
    public partial class CourseWindow : Window
    {
        CourseViewModel courseViewModel;
        tblCours newCourse;

        public CourseWindow()
        {
            InitializeComponent();
        }

        public CourseWindow(tblCours course) : this()
        {
            if (course.name != null)
            {
                courseViewModel = new CourseViewModel(course);
                this.DataContext = courseViewModel;
                this.Title = "Edit course :";
                labelHeader.Content = "Editing course " + course.name;
            }
            else
            {
                courseViewModel = new CourseViewModel();
                this.DataContext = courseViewModel;
                this.Title = "New course :";
                labelHeader.Content = "Please enter the following information to create a new Course.";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            newCourse = (tblCours)this.DataContext;
            using(RegistarDbContext db = new RegistarDbContext())
            {
                db.tblCourses.Add(newCourse);
                db.SaveChanges();
            }

        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            Selector bookSelector = new Selector(new tblBook());
            bookSelector.Show();
            txtBook.Text = Convert.ToString(((SelectorViewModel)bookSelector.DataContext).SelectedBook.isbn);
            

        }

        private void btnTeacher_Click(object sender, RoutedEventArgs e)
        {
            Selector teacherSelector = new Selector(new tblTeacher());
            teacherSelector.Show();
        }
    }
}
