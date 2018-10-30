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
            this.Title = "Please select one of the follow Books.";
            listBooks.Visibility = Visibility.Visible;

        }

        public Selector(tblTeacher teacher) : this()
        {
            this.Title = "Please select one of the follow Teachers.";
            listTeachers.Visibility = Visibility.Visible;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
