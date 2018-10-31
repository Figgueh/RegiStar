using AutoMapper;
using RegiStar.Maps;
using RegiStar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel
{
    public class SelectorViewModel : BaseClass
    {
        private ObservableCollection<tblBook> _books;
        public ObservableCollection<tblBook> Books
        {
            get
            {
                return _books;
            }
            set
            {
                _books = value;
                OnPropertyChanged("Books");
            }
        }

        private ObservableCollection<tblTeacher> _teachers;
        public ObservableCollection<tblTeacher> Teachers
        {
            get
            {
                return _teachers;
            }
            set
            {
                _teachers = value;
                OnPropertyChanged("Teachers");
            }
        }

        private tblBook _selectedBook;
        public tblBook SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;

                OnPropertyChanged("SelectedBook");
            }
        }

        private int _bookNumber;
        public int bookNumber
        {
            get
            {
                return _bookNumber;
            }
            set
            {
                _bookNumber = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        private tblTeacher _selectedTeacher;
        public tblTeacher SelectedTeacher
        {
            get
            {
                return _selectedTeacher;
            }
            set
            {
                _selectedTeacher = value;
                OnPropertyChanged("SelectedTeacher");
            }
        }



        public SelectorViewModel()
        {
            Books = GetBooks();
            Teachers = GetTeachers();
        }



        public void getSelectedBook()
        {
            var book = Mapper.Map<tblBook>(SelectedBook);
        }

        public void getSelectedTeacher()
        {
            var teacher = Mapper.Map<tblTeacher>(SelectedTeacher);
        }

        public ObservableCollection<tblTeacher> GetTeachers()
        {
            Teachers = new ObservableCollection<tblTeacher>();

            using (RegistarDbContext db = new RegistarDbContext())
            {
                var query = from t in db.tblTeachers
                            select t;

                Teachers = new ObservableCollection<tblTeacher>(query);
            }

            return Teachers;
        }


        public ObservableCollection<tblBook> GetBooks()
        {
            Books = new ObservableCollection<tblBook>();

            using (RegistarDbContext db = new RegistarDbContext())
            {
                var query = db.tblBooks.Select(b => b).ToList();

                Books = new ObservableCollection<tblBook>(query);
            }

            return Books;
        }
    }
}
