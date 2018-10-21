using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.Data
{
    public class Class
    {
        //Variables.
        private int _classRoomID;
        private DateTime _classRoomYear;
        private int _gradeID;
        private string _section;
        private bool _status;
        private Teacher _teacher;

        //Getters and Setters
        public int ClassRoomID { get => _classRoomID; set => _classRoomID = value; }
        public DateTime ClassRoomYear { get => _classRoomYear; set => _classRoomYear = value; }
        public int GradeID { get => _gradeID; set => _gradeID = value; }
        public string Section { get => _section; set => _section = value; }
        public bool Status { get => _status; set => _status = value; }
        public Teacher Teacher { get => _teacher; set => _teacher = value; }

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
