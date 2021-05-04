using System;
using System.Collections.Generic;
using System.Text;
using QuizAppClassLibrary.Entities.Enums;

namespace QuizAppClassLibrary.Entities.Models
{
    public class Student : Person
    {
        public Role Role { get; set; }
        public bool HasTakenQuiz { get; set; }

        public Grade GradeFromQuiz { get; set; } 
        public Student()
        {
        }

        public Student(string name, string username, string pass) : base(name, username, pass)
        {
            Role = Role.Student;
            HasTakenQuiz = false;
        }


        public void PrintStudentQuizInfo()
        {
            if (!HasTakenQuiz)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Student {FullName} hasn't taken the quiz yet.");

            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Student {FullName} got a grade {GradeFromQuiz} on the quiz.");

            }

            Console.ResetColor();        
        }
    }
}
