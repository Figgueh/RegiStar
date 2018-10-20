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
        private int _courseID;
        private string _name;
        private string _description;
        private int _gradeID;

        //Getters and Setters.
        public int CourseID { get => _courseID; set => _courseID = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public int GradeID { get => _gradeID; set => _gradeID = value; }
    }
}
