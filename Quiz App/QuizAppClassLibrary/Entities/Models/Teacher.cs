using QuizAppClassLibrary.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppClassLibrary.Entities.Models
{
    public class Teacher : Person
    {
        public Role Role { get; set; }

        public Teacher()
        {
        }


        public Teacher(string name, string username, string pass, Role role = Role.Teacher) : base(name, username, pass)
        {

        }

    }
}
