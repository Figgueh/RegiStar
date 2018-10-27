using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using RegiStar.Model;
using RegiStar.ViewModel;

namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        //https://github.com/johnpapa/CodeCamper/blob/master/CodeCamper.Data/EFRepository.cs
        //Repo for managing list.

        //https://www.dofactory.com
        //For Design Pattern

        //snoop wpf
        //For WPF decompiler.

        AdminViewModel AdminView;

        public Admin()
        {
            InitializeComponent();
            AdminView = new AdminViewModel();
            this.DataContext = AdminView;
        }

        private void ddlClass_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //Ask how we can remove this.
            listStudent.ItemsSource = AdminView.getStudentsInClass();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            AdminView.addStudent();
        }
    }
}
