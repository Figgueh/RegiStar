using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel
{
    public class Course : BaseClass
    {
        //Variables.
        private int _courseID;
        private string _name;
        private string _description;
        private int _isbn;
        private int _teacherID;
        private int _section;


        //Getters and Setters
        public int CourseID
        {
            get { return this._courseID; }
            set
            {
                _courseID = value;
                OnPropertyChanged("CourseID");
            }
        }
        public string Name
        {
            get { return this._name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Description
        {
            get { return this._description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        public int Isbn
        {
            get { return this._isbn; }
            set
            {
                _isbn = value;
                OnPropertyChanged("Isbn");
            }
        }
        public int TeacherID
        {
            get { return this._teacherID; }
            set
            {
                _teacherID = value;
                OnPropertyChanged("StudentID");
            }
        }
        public int Section
        {
            get { return this._section; }
            set
            {
                _section = value;
                OnPropertyChanged("TimeID");
            }
        }

        //Main Course Constructor
        public Course(int CourseID, string Name, string Description, int Isbn, int TeacherID, int Section)
        {
            _courseID = CourseID;
            _name = Name;
            _description = Description;
            _isbn = Isbn;
            _teacherID = TeacherID;
            _section = Section;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {5}", CourseID, Name, Description, GradeID, Isbn, StudentID, TimeID);
        }
    }
}
