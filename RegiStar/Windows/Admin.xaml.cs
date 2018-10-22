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

        //Objects:
        Student student;
        Class classes;
        Teacher teacher;
        ClassRoomStudents classOfStudent;

        

        public Admin()
        {
            //Initialize lists.
            studentList = new ObservableCollection<Student>();
            classList = new ObservableCollection<Class>();
            classStudentList = new ObservableCollection<ClassRoomStudents>();
            InitializeComponent();


            //Get lists.
            getStudents();
            getClasses();

            //Bind data to controls.
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

        public void getStudents()
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
            //Get the selected item in the dropdown list as a class.
            Class selectedClass = ddlClass.SelectedItem as Class;

            //Pass the classroomID to the function that returns the list of students in that class.
            getClassStudentList(selectedClass.ClassRoomID);

            //Bind it to the listbox.
            listStudent.ItemsSource = classStudentList;

            //Show the user the name of the class thats selected.
            labelClass.Content = getClassName(selectedClass);

        }

        private void getClassStudentList(int classRoomID)
        {
            //Clear the list
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

                            //Get the student ID:
                            int studentID = Convert.ToInt32(reader["studentID"]);
                            Class classRoom = ddlClass.SelectedItem as Class;


                            //look in the list of students for the student.
                            foreach (Student student in studentList)
                            {
                                if(student.StudentID == studentID)
                                {
                                    classOfStudent = new ClassRoomStudents(classRoom, student);
                                    classStudentList.Add(classOfStudent);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            //Add the selected students to the selected list.
            student = ddlStudent.SelectedItem as Student;
            classes = ddlClass.SelectedItem as Class;
            classOfStudent = new ClassRoomStudents(classes, student);

            //Save to the database.
            save(classOfStudent);

            classStudentList.Add(classOfStudent);

            //Bind it to the listbox.
            listStudent.ItemsSource = classStudentList;

        }

        private string getClassName(Class _class)
        {
            string className;
            //Get the GradeID of the class
            int classGradeID = _class.GradeID;

            //Setup connection to database.
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7C48ELV;Initial Catalog=wpfRegistar;Integrated Security=True"))
            {
                //Open the connection.
                conn.Open();

                //Create query.
                using (SqlCommand cmd = new SqlCommand("SELECT name FROM dbo.tblGrades WHERE gradeID=" + classGradeID, conn))
                {
                    className = cmd.ExecuteScalar() as string;
                }
            }
            return className;
        }

        private void save(ClassRoomStudents classOfStudent)
        {
            //Setup connection to database.
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7C48ELV;Initial Catalog=wpfRegistar;Integrated Security=True"))
            {
                //Open the connection.
                conn.Open();

                //Create query.
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.tblClassRoomStudents(classRoomID, studentID) VALUES(@ClassRoomID, @StudentID)", conn))
                {
                    //Create the Parameters
                    cmd.Parameters.AddWithValue("@ClassRoomID", classOfStudent.ClassRoomID.ClassRoomID);
                    cmd.Parameters.AddWithValue("@StudentID", classOfStudent.StudentID.StudentID);

                    //Send the Data
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnNewStudent_Click(object sender, RoutedEventArgs e)
        {
            PeopleView studentView = new PeopleView(new Student());
            studentView.Show();
        }

        private void btnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            //Get the selected item.
            var selected = listStudent.SelectedValue as ClassRoomStudents;

            //Pull the student from the selected item.
            Student selectedStudent = selected.StudentID;

            //Send it to the constructor.
            PeopleView studentView = new PeopleView(selectedStudent);
            
            //Show the window.
            studentView.Show();
        }

        private void btnNewTeacher_Click(object sender, RoutedEventArgs e)
        {
            PeopleView teacherView = new PeopleView(new Teacher());
            teacherView.Show();

        }

        private void btnEditTeacher_Click(object sender, RoutedEventArgs e)
        {
            //Get the selected item.
            var selected = listStudent.SelectedValue as ClassRoomStudents;

            //Pull the class from the selected item.
            Class selectedClass = selected.ClassRoomID;

            //Pull the teacher from the selected class
            Teacher selectedTeacher = selectedClass.Teacher;

            PeopleView teacherView = new PeopleView(selectedTeacher);
            teacherView.Show();
        }
    }
}
