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
        private ObservableCollection<Class> classList;
        private ObservableCollection<ClassRoomStudents> classStudentList;

        Student student;
        Class classes;
        Teacher teacher;
        ClassRoomStudents classOfStudent;

        public Admin()
        {
            studentList = new ObservableCollection<Student>();
            classList = new ObservableCollection<Class>();
            classStudentList = new ObservableCollection<ClassRoomStudents>();

            InitializeComponent();
            getStudents();
            getClasses();

            ddlStudent.ItemsSource = studentList;
            ddlClass.ItemsSource = classList;
            

        }



        private void getClasses()
        {
            //Setup connection to database.
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7C48ELV;Initial Catalog=wpfRegistar;Integrated Security=True"))
            {
                //Open the connection.
                conn.Open();

                //Create query.
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tblClassRooms", conn))
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
                                classes = new Class(
                                Convert.ToInt32(reader["classRoomID"]),
                                Convert.ToDateTime(reader["classRoomYear"]),
                                reader["section"].ToString(),
                                Convert.ToInt32(reader["gradeID"]),
                                Convert.ToBoolean(reader["status"]),
                                getTeacher(Convert.ToInt32(reader["teacherID"]))
                                );

                                classList.Add(classes);
                            }
                            catch
                            {
                                MessageBox.Show("Failed to create class");
                            }

                            //Then add the student to the list of students.
                            studentList.Add(student);
                        }
                    }
                }
            }
        }

        private Teacher getTeacher(int teacherID)
        {
            //Setup connection to database.
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7C48ELV;Initial Catalog=wpfRegistar;Integrated Security=True"))
            {
                //Open the connection.
                conn.Open();

                //Create query.
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tblTeachers WHERE teacherID=" + teacherID, conn))
                {

                    //Setup reader to interpret the data.
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        //While reading the data:
                        while (reader.Read())
                        {
                            teacher = new Teacher(
                                Convert.ToInt32(reader["teacherID"]),
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
                    }
                }
            }

            return teacher;
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

        private void ddlClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Class selectedClass = ddlClass.SelectedItem as Class;
            getClassStudentList(selectedClass.ClassRoomID);

            listStudent.ItemsSource = classStudentList;

        }

        private void getClassStudentList(int classRoomID)
        {
            //Clear the list.
            classStudentList = new ObservableCollection<ClassRoomStudents>();

            //Setup connection to database.
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7C48ELV;Initial Catalog=wpfRegistar;Integrated Security=True"))
            {
                //Open the connection.
                conn.Open();

                //Create query.
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tblClassRoomStudents WHERE classRoomID=" + classRoomID, conn))
                {

                    //Setup reader to interpret the data.
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        //While reading the data:
                        while (reader.Read())
                        {
                            classOfStudent = new ClassRoomStudents(classRoomID, Convert.ToInt32(reader["studentID"]));
                            classStudentList.Add(classOfStudent);
                        }
                    }
                }
            }
        }
    }
}
