using RegiStar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel
{
    public class CourseViewModel : BaseClass
    {
        private tblCours _course;
        public tblCours Course
        {
            get
            {
                return _course;
            }
            set
            {
                _course = value;
                OnPropertyChanged("Course");
            }
        }

        private tblBook _book;
        public tblBook Book
        {
            get;set;
        }

        public CourseViewModel(tblCours cours)
        {
            Course = cours;
        }

        public CourseViewModel()
        {
            
        }



    }
}
