using RegiStar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel
{
    public class AcademicDetailsViewModel : BaseClass
    {
        public tblUser userinfo { get; set; }
        private int _attend;
        private tblStudent _student;
        private double _mediumGrade;

        private ObservableCollection<tblCours> _selectedList { get; set; }
        public ObservableCollection<tblCours> selectedList { get { return _selectedList; } set { _selectedList = value; OnPropertyChanged("selectedList"); } }


        public double mediumGrade
        {
            get
            {
                return _mediumGrade;
            }
            set
            {
                _mediumGrade = value;
                OnPropertyChanged("mediumGrade");
            }
        }


        public int attend
        {
            get
            {
                return _attend;
            }
            set
            {
                _attend = value;
                OnPropertyChanged("attend");
            }
        }


        public tblStudent student
        {
            get
            {
                return _student;
            }
            set
            {
                _student = value;
                OnPropertyChanged("student");
            }
        }


        public AcademicDetailsViewModel()
        {
            // getStudentNames();



        }



        public void GetCourses()
        {
            using (var dbInfo = new RegistarDbContext())
            {

                var allCourses = dbInfo.tblCourses.ToList<tblCours>();

                //Fetech the courses.
                var stud = dbInfo.tblStudents.Where(b => b.userID == userinfo.userID).FirstOrDefault();
                var dc = stud.tblCourses.ToList();


                var avCourses = allCourses.Except(dc);

                selectedList = new ObservableCollection<tblCours>(dc);
            }


        }


        public void getStudentNames()
        {

            using (RegistarDbContext dbInfo = new RegistarDbContext())
            {
                //Fetech the students.
                //var context = this.DataContext;
                var query = from st in dbInfo.tblStudents
                            where st.userID == userinfo.userID
                            select st;
                this.student = query.FirstOrDefault<tblStudent>();

            }
        }

        public void getAttendances()
        {

            using (RegistarDbContext dbInfo = new RegistarDbContext())
            {

                attend = (from st in dbInfo.tblAttendances
                          where st.studentID == student.studentID
                          select st).Count();


            }
        }


        public void getMedium()
        {

            using (RegistarDbContext dbInfo = new RegistarDbContext())
            {

                var grade = from st in dbInfo.tblGrades
                            where st.studentID == student.studentID
                            select st.grade;


                mediumGrade = grade.Average();
            }
        }

    }
}
