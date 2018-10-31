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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using RegiStar.Windows;
using RegiStar.ViewModel;
using RegiStar.Model;
using RegiStar.Maps;

namespace RegiStar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtUserID.Text = "1";
            txtPassword.Password = "admin";
            MyMapper.Initialize();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new RegistarDbContext())
            {
                try
                {
                    var userinfo = db.tblUsers.Find(Convert.ToInt32(txtUserID.Text));

                    if (userinfo == null)
                        throw new Exception("Unable to pull the user information.");

                    if (userinfo.password != txtPassword.Password)
                        throw new Exception("Incorrect password. Please try again.");

                    if(userinfo.userAccess == 1)
                    {
                        Admin admin = new Admin();
                        admin.Show();
                        this.Close();
                    }
                    else
                    {
                        User user = new User(userinfo);
                        user.Show();
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR : " + ex.Message.ToString());
                }

            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
