using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegiStar.Windows;

namespace RegiStar.ViewModel
{
    public class ClassRoomStudents : BaseClass
    {
        private Course _classRoomID;
        private Student _studentID;

        public Course ClassRoomID
        {
            get { return this._classRoomID; }
            set
            {
                _classRoomID = value;
                OnPropertyChanged("ClassRoomID");
            }
        }
        public Student StudentID
        {
            get { return this._studentID; }
            set
            {
                _studentID = value;
                OnPropertyChanged("StudentID");
            }
        }


        public ClassRoomStudents(Course classRoomID, Student studentID)
        {
            _classRoomID = classRoomID;
            _studentID = studentID;
        }

        public override string ToString()
        {
            return StudentID.FirstName + " " + StudentID.LastName;
        }

    }
}
