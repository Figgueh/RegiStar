using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel
{
    public class Class : BaseClass
    {
        //Variables.
        private int _classRoomID;
        private DateTime _classRoomYear;
        private int _gradeID;
        private string _section;
        private bool _status;
        private Teacher _teacher;

        //Getters and Setters
        public int ClassRoomID
        {
            get { return this._classRoomID; }
            set
            {
                _classRoomID = value;
                OnPropertyChanged("ClassRoomID");
            }
        }
        public DateTime ClassRoomYear
        {
            get { return this._classRoomYear; }
            set
            {
                _classRoomYear = value;
                OnPropertyChanged("ClassRoomYear");
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
        public string Section
        {
            get { return this._section; }
            set
            {
                _section = value;
                OnPropertyChanged("Section");
            }
        }
        public bool Status
        {
            get { return this._status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }
        public Teacher Teacher
        {
            get { return this._teacher; }
            set
            {
                _teacher = value;
                OnPropertyChanged("Teacher");
            }
        }

        //Main Class Constructor
        public Class(int classRoomID, DateTime classRoomYear, string section, int gradeID, bool status, Teacher teacher)
        {
            _classRoomID = classRoomID;
            _classRoomYear = classRoomYear;
            _gradeID = gradeID;
            _section = section;
            _status = status;
            _teacher = teacher;
        }
    }
}
