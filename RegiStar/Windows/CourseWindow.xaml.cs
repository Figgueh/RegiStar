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

namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for NewCourse.xaml
    /// </summary>
    public partial class CourseWindow : Window
    {
        tblCours newCourse;

        public CourseWindow(tblCours course)
        {
            InitializeComponent();

            if (course.name != null)
            {
                this.DataContext = course;
                this.Title = "Edit course :";
                labelHeader.Content = "Editing course " + course.name;
            }
            else
            {
                this.DataContext = new tblCours();
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
        }

        private void btnTeacher_Click(object sender, RoutedEventArgs e)
        {
            Selector teacherSelector = new Selector(new tblTeacher());
            teacherSelector.Show();
        }
    }
}
