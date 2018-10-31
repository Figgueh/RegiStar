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
using AutoMapper;
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
        tblCours Course; 
        tblTeacher Teacher;
        public tblBook Book { get; set; }

        public CourseWindow()
        {
            InitializeComponent();
        }

        //Constructor for editing course
        public CourseWindow(tblCours course) : this()
        {
            courseViewModel = new CourseViewModel(course);
            this.DataContext = courseViewModel;
            this.Title = "Edit course :";
            labelHeader.Content = "Editing course " + course.name;


        }

        //Constructor for new course.
        public CourseWindow(tblCours course, int newestCourseID) : this()
        {
            courseViewModel = new CourseViewModel(course, newestCourseID);
            this.DataContext = courseViewModel;
            this.Title = "New course :";
            labelHeader.Content = "Please enter the following information to create a new Course.";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Course = (tblCours)this.DataContext;
            courseViewModel.Save(Course);

        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            Selector bookSelector = new Selector(Book);
            bookSelector.Show();
            // PLACE HERE

            //((CourseViewModel)((Window)this.Parent).DataContext).Book = Mapper.Map<tblBook>(bookSelector.listBooks.SelectedItem);


            //if (((SelectorViewModel)DataContext).SelectedBook != null)
            //{
            //    txtBook.Text = ((SelectorViewModel)DataContext).SelectedBook.isbn.ToString();
            //}
            var x = Book;


        }

        private void btnTeacher_Click(object sender, RoutedEventArgs e)
        {
            Selector teacherSelector = new Selector(Teacher);
            teacherSelector.Show();
        }
    }
}
