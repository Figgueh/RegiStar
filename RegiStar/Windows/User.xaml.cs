using RegiStar.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data.SqlClient;

namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>






    public partial class User : Window
    {

        //Variables:
        private ObservableCollection<Course> coursesList;

        //Objects:
        Course courses;

        public User()
        {
            InitializeComponent();
            coursesList = new ObservableCollection<Course>();


            //Get lists.
            getCourses();

            //Bind data to controls.
            lstListOfClasses.ItemsSource = coursesList;
        }



        private void getCourses()
        {
            //Setup connection to database.
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LSPNA6P;Initial Catalog=wpfRegistar;Integrated Security=True"))
            {
                //Open the connection.
                conn.Open();

                //Create query.
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tblCourses", conn))
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
                                //courses = new Course(
                                //Convert.ToInt32(reader["courseID"]),
                                //reader["name"].ToString(),
                                //reader["description"].ToString(),
                                //Convert.ToInt32(reader["gradeID"]),
                                //Convert.ToInt32(reader["isbn"]),
                                //Convert.ToInt32(reader["studentID"]),
                                //Convert.ToInt32(reader["timeID"])
                                //);

                                coursesList.Add(courses);
                            }
                            catch
                            {
                                MessageBox.Show("Failed to create course");
                            }
                        }
                    }
                }
            }
        }





        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAcademicDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
