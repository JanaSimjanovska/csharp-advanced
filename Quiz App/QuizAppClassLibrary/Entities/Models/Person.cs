using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppClassLibrary.Entities.Models
{
    public abstract class Person
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public Person()
        {

        }

        public Person(string name, string username, string pass)
        {
            FullName = name;
            Username = username;
            Password = pass;
        }

    }
}
