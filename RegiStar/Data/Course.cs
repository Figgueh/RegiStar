using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.Data
{
    public class Course : INotifyPropertyChanged
    {
        //Variables.
        private int _courseID;
        private string _name;
        private string _description;
        private int _gradeID;
        private int _isbn;
        private int _studentID;
        private int _timeID;



        public event PropertyChangedEventHandler PropertyChanged;

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
        public int GradeID
        {
            get { return this._gradeID; }
            set
            {
                _gradeID = value;
                OnPropertyChanged("GradeID");
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
        public int StudentID
        {
            get { return this._studentID; }
            set
            {
                _studentID = value;
                OnPropertyChanged("StudentID");
            }
        }
        public int TimeID
        {
            get { return this._timeID; }
            set
            {
                _timeID = value;
                OnPropertyChanged("TimeID");
            }
        }

        //Main Course Constructor
        public Course(int CourseID, string Name, string Description, int GradeID, int Isbn, int StudentID, int TimeID)
        {
            _courseID = CourseID;
            _name = Name;
            _description = Description;
            _gradeID = GradeID;
            _isbn = Isbn;
            _studentID = StudentID;
            _timeID = TimeID;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {5}", CourseID, Name, Description, GradeID, Isbn, StudentID, TimeID);
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
