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
using RegiStar.Data;

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
            //Pull the infromation from the text box and make sure its an int.
            try
            {
                int UserID = Convert.ToInt32(txtUserID.Text);
                pullUsers(UserID);
            }
            catch
            {
                MessageBox.Show("The userID entered must be a numeric value!");
            }
        }

        private void pullUsers(int userID)
        {
            try
            {
                //Start a new connection to the server.
                using (SqlConnection conn = new SqlConnection(ConnectionInfo.connectionString))
                {
                    //Open the connection.
                    conn.Open();

                    //Create query to be executed.
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tblUsers WHERE userID=" + userID, conn)){

                        //Open reader to receive values.
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //If we weren't able to pull the userID then throw a new exception.
                            if (!reader.HasRows)
                                throw new Exception("Unable to find the user in our database.");


                            //Check the if the password was submitted.
                            if (txtPassword.Password.Length == 0)
                                throw new Exception("You failed to enter a password.");


                            //While we receive the values from the database:
                            while (reader.Read())
                            {
                                //Check if the passwords are the same.
                                if (reader.GetString(1) == txtPassword.Password)
                                {
                                    //Read their access level and display the correct window.
                                    if (reader.GetInt32(2) == 1)
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
                                else
                                {
                                    throw new Exception("Incorrect password.");
                                }
                            }
                        }
                    }
                }
            }

            //Catch any of our exception and show them to the user.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
