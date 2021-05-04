using System;
using System.Collections.Generic;
using QuizAppClassLibrary;
using QuizAppClassLibrary.Entities.Models;
using QuizAppServices;


namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region School Members DB

            List<Student> students = new List<Student>()
            {
                new Student("Jana Simjanovska", "janaS", "jana123"),
                new Student("Marta Spasovska", "martaS", "marta123"),
                new Student("Ivan Jamandilovski", "ivanJ", "ivan123"),
                new Student("Sanja Karakashova", "sanjaK", "sanja123"),
                new Student("Nikola Sheskokalov", "nikolaS", "nikola123"),
                new Student("Leart Kamberi", "leartK", "leart123"),
            };

            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher("Kristina Spasevska", "kikiS", "kiki123"),
                new Teacher("Panche Manaskov", "paneM", "pane123"),
            };

            List<Person> members = new List<Person>()
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


            #endregion

            try
            {

                Console.Clear();
                QuizAppServiceClass.MainMenuLogin(members, teachers, students);

            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("\nOops, something went wrong :( Let's see what...");
                Console.WriteLine($"\n{ex.Message}");
                Console.WriteLine("\nPlease try again.");
                QuizAppServiceClass.PressAnyKey();
                QuizAppServiceClass.MainMenuLogin(members, teachers, students);

            }


        }
    }
}
