using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        //Variables:
        private ObservableCollection<Student> studentList;
        Student student;

        public Admin()
        {
            studentList = new ObservableCollection<Student>();

            InitializeComponent();
            getStudents();

            ddlStudent.ItemsSource = studentList;
            listStudent.ItemsSource = studentList;
            

        }

        private void getStudents()
        {
            //Setup connection to database.
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7C48ELV;Initial Catalog=wpfRegistar;Integrated Security=True"))
            {
                //Open the connection.
                conn.Open();

                //Create query.
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tblStudents", conn))
                {

                    //Setup reader to interpret the data.
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        //While reading the data:
                        while (reader.Read())
                        {
                            //Create a new student with the data.
                            try
                            {
                                student = new Student(
                                Convert.ToInt32(reader["studentID"]),
                                reader["firstName"].ToString(),
                                reader["lastName"].ToString(),
                                Convert.ToDateTime(reader["dob"]),
                                Convert.ToDateTime(reader["joinDate"]),
                                reader["address"].ToString(),
                                reader["city"].ToString(),
                                reader["region"].ToString(),
                                reader["postalCode"].ToString(),
                                reader["country"].ToString(),
                                reader["email"].ToString(),
                                reader["phone"].ToString(),
                                Convert.ToBoolean(reader["status"])
                                );
                            }
                            catch
                            {
                                MessageBox.Show("Failed to create student");
                            }

                            //Then add the student to the list of students.
                            studentList.Add(student);
                        }
                    }
                }
            }
        }
    }
}
