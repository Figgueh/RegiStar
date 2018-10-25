using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.ViewModel
{
    public class Student : BaseClass
    {
        //Variables
        private int _studentID;
        private string _firstName;
        private string _lastName;
        private DateTime _dob;
        private DateTime _joinDate;
        private string _address;
        private string _city;
        private string _region;
        private string _postalCode;
        private string _country;
        private string _email;
        private string _phone;
        private bool _status;

        //Getters and setters.
        public int StudentID
        {
            get { return this._studentID; }
            set
            {
                _studentID = value;
                OnPropertyChanged("StudentID");
            }
        }
        public string FirstName
        {
            get { return this._firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return this._lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public DateTime Dob
        {
            get { return this._dob; }
            set
            {
                _dob = value;
                OnPropertyChanged("Dob");
            }
        }
        public DateTime JoinDate
        {
            get { return this._joinDate; }
            set
            {
                _joinDate = value;
                OnPropertyChanged("JoinDate");
            }
        }
        public string Address
        {
            get { return this._address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }
        public string City
        {
            get { return this._city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }
        public string Region
        {
            get { return this._region; }
            set
            {
                _region = value;
                OnPropertyChanged("Region");
            }
        }
        public string PostalCode
        {
            get { return this._postalCode; }
            set
            {
                _postalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }
        public string Country
        {
            get { return this._country; }
            set
            {
                _country = value;
                OnPropertyChanged("Country");
            }
        }
        public string Email
        {
            get { return this._email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Phone
        {
            get { return this._phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
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
        public string FullName
        {
            get
            {
                OnPropertyChanged("FirstName");
                OnPropertyChanged("LastName");
                return _firstName + " " + _lastName;
            }
        }

        public Student()
        {

        }

        //Full Constructor for student.
        public Student(int studentID, string firstName, string lastName, DateTime dob, DateTime joinDate, string address, string city, string region, string postalcode, string country, string email, string phone, bool status)
        {
            _studentID = studentID;
            _firstName = firstName;
            _lastName = lastName;
            _dob = dob;
            _joinDate = joinDate;
            _address = address;
            _city = city;
            _region = region;
            _postalCode = postalcode;
            _country = country;
            _email = email;
            _phone = phone;
            _status = status;
        }
    }
}
