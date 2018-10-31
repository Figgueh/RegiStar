using RegiStar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel


{
    public class UserViewModel : BaseClass
    {
        //Variables:
        public List<tblCours> courseList;
        public List<tblCours> selList;


        private ObservableCollection<tblCours> _coursesList { get; set; }
        private ObservableCollection<tblCours> _selectedList { get; set; }

        public ObservableCollection<tblCours> coursesList { get { return _coursesList; } set { _coursesList = value; OnPropertyChanged("coursesList"); } }
        public ObservableCollection<tblCours> selectedList { get { return _selectedList; } set { _selectedList = value; OnPropertyChanged("selectedList"); } }

        private tblCours _selectedCours;
        public tblCours selectedCours { get { return _selectedCours; } set { _selectedCours = value; OnPropertyChanged("selectedCours"); } }

        private tblCours _deletedCours;
        public tblCours deletedCours { get { return _deletedCours; } set { _deletedCours = value; OnPropertyChanged("deletedCours"); } }

        public tblUser userinfo { get; set; }



        public UserViewModel()
        {




        }

        public void addCourse()
        {
            selectedList.Add(selectedCours);

                var result = coursesList.Where(p => !selectedList.Any(p2 => p2.courseID == p.courseID));
                coursesList = new ObservableCollection<tblCours>(result);


        }

        public void removeCourse()
        {
            var sel = deletedCours;
            selectedList.Remove(deletedCours);
            coursesList.Add(sel);


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




                //courseList = new List<tblCours>(dc2);
                coursesList = new ObservableCollection<tblCours>(avCourses);
                selectedList = new ObservableCollection<tblCours>(dc);
            }


        }

        public void UpdateStudentCourses()
        {
            using (var dbInfo = new RegistarDbContext())
            {
                var stud = dbInfo.tblStudents.Where(b => b.userID == userinfo.userID).FirstOrDefault();
                if (selectedList == null)
                {

                    stud.tblCourses.Clear();
                    dbInfo.SaveChanges();
                    return;
                }

                var coursesFromSelListHS = new HashSet<int>(selectedList.Select(s => s.courseID));
                var coursesFromStudentDB = new HashSet<int>(stud.tblCourses.Select(c => c.courseID));


                foreach (var course in dbInfo.tblCourses)
                {
                    if (coursesFromSelListHS.Contains(course.courseID))
                    {
                        if (!coursesFromStudentDB.Contains(course.courseID))
                        {
                            stud.tblCourses.Add(course);
                            //stud.Courses.Add(course);
                        }
                    }
                    else
                    {
                        if (coursesFromStudentDB.Contains(course.courseID))
                        {
                            stud.tblCourses.Remove(course);
                        }
                    }
                }
                dbInfo.SaveChanges();
            }
        }

    }
}

