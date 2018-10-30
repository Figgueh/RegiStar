using RegiStar.Model;
using System;
using System.Collections.Generic;
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


        public tblStudent student {
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
