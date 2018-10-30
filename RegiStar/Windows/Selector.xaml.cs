using AutoMapper;
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
    /// Interaction logic for Selector.xaml
    /// </summary>
    public partial class Selector : Window
    {
        SelectorViewModel selectorViewModel = new SelectorViewModel();

        public Selector()
        {
            InitializeComponent();
            this.DataContext = selectorViewModel;
        }

        public Selector(tblBook book) : this()
        {
            this.Title = "Books Selection";
            listBooks.Visibility = Visibility.Visible;
            btnSelectBook.Visibility = Visibility.Visible;

        }

        public Selector(tblTeacher teacher) : this()
        {
            this.Title = "Teacher Selection";
            listTeachers.Visibility = Visibility.Visible;
            btnSelectTeacher.Visibility = Visibility.Visible;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSelectBook_Click(object sender, RoutedEventArgs e)
        {
            //selectorViewModel.getSelectedBook();
          
            ((CourseViewModel)((Window)this.Parent).DataContext).Book = Mapper.Map<tblBook>(selectorViewModel.SelectedBook);


            //    //Target the dataContext in the CorseViewModel so that we can show the user the update value.
            //    //if (selectorViewModel.SelectedBook != null)
            //        //((CourseViewModel)DataContext).Book = selectorViewModel.SelectedBook;
            //    else
            //    {
            //        MessageBox.Show("You must select one of the books for the class.");
            //        this.DialogResult = false;

            //    }
        }

        private void btnSelectTeacher_Click(object sender, RoutedEventArgs e)
        {
            //Target the dataContext in the CorseViewModel so that we can show the user the update value.
            //if (selectorViewModel.SelectedTeacher != null)
                //((CourseViewModel)DataContext).Teacher = selectorViewModel.SelectedTeacher;
            //else
            //{
            //    MessageBox.Show("You must select one of the teachers for the class.");
            //    this.DialogResult = false;
            //}
        }
    }
}
