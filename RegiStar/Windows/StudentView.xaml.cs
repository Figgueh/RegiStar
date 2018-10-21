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
using RegiStar.Data;

namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        //Constructor when sending the window nothing
        public StudentView()
        {
            this.DataContext = new Student();
            InitializeComponent();

            labelHeader.Content = "Please enter the following information to create a new student.";
        }

        //Constructor when sending the window a student.
        public StudentView(Student student)
        {
            this.DataContext = student;
            InitializeComponent();

            labelHeader.Content = "Editing student " + student.FullName;


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
