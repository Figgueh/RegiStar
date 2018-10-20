﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegiStar.Data
{
    public class Student
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
        private string _phone;
        private bool _status;

        //Getters and setters.
        public int StudentID { get => _studentID; set => _studentID = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime Dob { get => _dob; set => _dob = value; }
        public DateTime JoinDate { get => _joinDate; set => _joinDate = value; }
        public string Address { get => _address; set => _address = value; }
        public string City { get => _city; set => _city = value; }
        public string Region { get => _region; set => _region = value; }
        public string PostalCode { get => _postalCode; set => _postalCode = value; }
        public string Country { get => _country; set => _country = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public bool Status { get => _status; set => _status = value; }
    }
}