using System;
using System.Windows;
using RegiStar.Windows;
using RegiStar.Model;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new MainModel())
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
                        User user = new User();
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
