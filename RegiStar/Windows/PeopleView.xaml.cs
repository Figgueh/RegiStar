﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegiStar.Data;

namespace RegiStar.Windows
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class PeopleView : Window
    {
        //Constructor when sending the window nothing
        public PeopleView()
        {
            InitializeComponent();
        }

        //Constructor when sending the window a student.
        public PeopleView(Student student)
        {
            InitializeComponent();
            stackStudent.Visibility = Visibility.Visible;

            if (student.FirstName != null)
            {
                this.DataContext = student;
                this.Title = "Edit student :";
                labelHeader.Content = "Editing student " + student.FullName;
            }
            else
            {
                this.DataContext = new Student();
                this.Title = "New student :";
                labelHeader.Content = "Please enter the following information to create a new student.";
            }
                

        }

        //Constructor when sending the window a student.
        public PeopleView(Teacher teacher)
        {
            InitializeComponent();
            stackTeacher.Visibility = Visibility.Visible;


            if (teacher.FirstName != null)
            {
                this.DataContext = teacher;
                this.Title = "Edit teacher :";
                labelHeader.Content = "Editing teacher " + teacher.FullName;
            }
            else
            {
                this.DataContext = new Teacher();
                this.Title = "New teacher :";
                labelHeader.Content = "Please enter the following information to create a new teacher.";
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}