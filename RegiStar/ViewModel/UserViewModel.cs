using RegiStar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel


{
    public class UserViewModel:  BaseClass
    {
        //Variables:
        public List<tblCours> courseList;
        public List<tblCours> selList;

       
        public ObservableCollection<tblCours> coursesList { get; set; }
        public ObservableCollection<tblCours> selectedList { get; set; } = new ObservableCollection<tblCours>();

        private tblCours _selectedCours;
        public tblCours selectedCours { get { return _selectedCours; } set { _selectedCours = value; OnPropertyChanged("selectedCours"); } }

        public tblUser userinfo{ get; set; }



        public UserViewModel()
        {

            GetCourses();


        }

        public void addCourse()
        {
            selectedList.Add(selectedCours);
        }


        public ObservableCollection<tblCours> GetCourses()
        {
            using (var dbInfo = new RegistarModel())
            {
                //Fetech the courses.
                var query = dbInfo.tblCourses.ToList<tblCours>();

                //Initialize the list to the list of students
                courseList = new List<tblCours>(query);
                coursesList = new ObservableCollection<tblCours>(courseList);
            }

            //return the newly initlaized list.
            return coursesList;
        }

    }
}
