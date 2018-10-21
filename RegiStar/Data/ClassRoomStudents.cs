using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegiStar.Windows;

namespace RegiStar.Data
{
    public class ClassRoomStudents
    {
        private int _classRoomID;
        private int _studentID;

        public int ClassRoomID { get => _classRoomID; set => _classRoomID = value; }
        public int StudentID { get => _studentID; set => _studentID = value; }

        public ClassRoomStudents(int classRoomID, int studentID)
        {
            _classRoomID = classRoomID;
            _studentID = studentID;
        }

    }
}
