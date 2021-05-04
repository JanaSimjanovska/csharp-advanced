using QuizAppClassLibrary.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizAppClassLibrary
{
    public static class SchoolMembersDB 
    {
        public static List<Student> Students { get; set; }
        public static List<Teacher> Teachers { get; set; }
        public static List<Person> Members { get; set; }

        static SchoolMembersDB()
        {
            Members = new List<Person>()
            {
                new Student("Jana Simjanovska", "janaS", "jana123"),
                new Student("Marta Spasovska", "martaS", "marta123"),
                new Student("Ivan Jamandilovski", "ivanJ", "ivan123"),
                new Student("Sanja Karakashova", "sanjaK", "sanja123"),
                new Student("Nikola Sheskokalov", "nikolaS", "nikola123"),
                new Student("Leart Kamberi", "leartK", "leart123"),
                new Teacher("Kristina Spasevska", "kikiS", "kiki123"),
                new Teacher("Panche Manaskov", "paneM", "pane123"),
            };


            Teachers = new List<Teacher>()
            {
                new Teacher("Kristina Spasevska", "kikiS", "kiki123"),
                new Teacher("Panche Manaskov", "paneM", "pane123"),
            };

            Students = new List<Student>()
            {
                new Student("Jana Simjanovska", "janaS", "jana123"),
                new Student("Marta Spasovska", "martaS", "marta123"),
                new Student("Ivan Jamandilovski", "ivanJ", "ivan123"),
                new Student("Sanja Karakashova", "sanjaK", "sanja123"),
                new Student("Nikola Sheskokalov", "nikolaS", "nikola123"),
                new Student("Leart Kamberi", "leartK", "leart123"),
            };

        }

    }
}
