using RegiStar.Model;
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

namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for Selector.xaml
    /// </summary>
    public partial class Selector : Window
    {
        public Selector()
        {
            InitializeComponent();
        }

        public Selector(tblBook book)
        {
            GetBooks();
            //this.DataContext = book;
        }
        public Selector(tblTeacher teacher)
        {
            GetTeachers();
            //this.DataContext = teacher;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            //Get the selected item:

        }

        public void GetTeachers()
        {
            using(RegistarDbContext db = new RegistarDbContext())
            {
                var query = from t in db.tblTeachers
                            select t;

                listContent.ItemsSource = query;
            }
        }

        public void GetBooks()
        {
            using (RegistarDbContext db = new RegistarDbContext())
            {
                var query = db.tblBooks.Select(b => b).ToList();

                listContent.ItemsSource = query;
            }
        }
    }
}
