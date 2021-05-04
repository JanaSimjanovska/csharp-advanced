using System;
using System.Collections.Generic;
using System.Text;
using QuizAppClassLibrary.Entities.Enums;
using QuizAppClassLibrary.Entities.Models;
using QuizAppClassLibrary;
using System.Linq;

namespace QuizAppServices
{
    public class QuizAppServiceClass
    {

        #region Press any key 
        public static void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue");
            char anyKey = Console.ReadKey(true).KeyChar;
        }

        #endregion


        #region Attempt Checker

        public static void HowManyAttempts(int counter)
        {
            switch (counter)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nThis is your first invalid attempt to log in. You now have two left.");
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nThis is your second invalid attempt to log in. Be careful, you only have one attempt left.");
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThis was your third incorrect attempt. Bye bye.");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
            Console.ResetColor();
        }

        #endregion


        #region Main Menu and Login

        public static void MainMenuLogin(List<Person> members, List<Teacher> teachers, List<Student> students)
        {
            int loginAttempts = 1;


            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\n=======================================================\n");
                Console.ResetColor();
                Console.WriteLine("Welcome to the coolest school. Go ahead and login :)");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\n=======================================================\n");
                Console.ResetColor();

                PressAnyKey();

                Person memberLoggingIn = LoginVerification(members);

                if (memberLoggingIn == null)
                {
                    Console.Clear();
                    HowManyAttempts(loginAttempts);
                    loginAttempts++;
                    PressAnyKey();
                }

                else
                {
                    foreach (Teacher teacher in teachers)
                    {
                        if (memberLoggingIn.Username == teacher.Username)
                            TeacherLogin(members, teachers, students, memberLoggingIn);
                    }

                    foreach (Student student in students)
                    {
                        if (memberLoggingIn.Username == student.Username)
                            TakeQuiz(members, teachers, students, memberLoggingIn);
                    }
                }
            }
        }


        public static Person LoginVerification(List<Person> members)
        {
            Console.Clear();

            Console.WriteLine("\nEnter username:");
            string username = Console.ReadLine();

            Console.WriteLine("\nEnter password:");
            string password = Console.ReadLine();

            foreach (Person member in members)
            {
                if (username == member.Username && password == member.Password) return member;
            }
            return null;
        }



        #endregion


        #region Quiz Flow

        public static Tuple<List<Person>, List<Student>> TakeQuiz(List<Person> members, List<Teacher> teachers, List<Student> students, Person memberLoggingIn)
        {

            Student loggedInStudent = (Student)memberLoggingIn;

            if (loggedInStudent.HasTakenQuiz)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou have already taken the quiz.");
                Console.ResetColor();
                PressAnyKey();
                return new Tuple<List<Person>, List<Student>>(members, students);

            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nHere comes today's quiz! Ready?");
            Console.ResetColor();
            PressAnyKey();
            Console.Clear();

            int correctAnswersCounter = 0;
            string userAnswer = "";

            foreach (KeyValuePair<string, int> entry in QuizDB.AllQuestionsWithCorrectAnswer)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(entry.Key);
                userAnswer = Console.ReadLine();
                bool isAnswerASuccess = int.TryParse(userAnswer, out int parsedAnswer);

                while (true)
                {
                    if (!isAnswerASuccess || parsedAnswer < 1 || parsedAnswer > 4)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("\nYou can only choose a number from 1 to 4. Please try again.");
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.WriteLine(entry.Key);

                        userAnswer = Console.ReadLine();
                        isAnswerASuccess = int.TryParse(userAnswer, out parsedAnswer);
                        continue;
                    }

                    else
                        break;

                }

                if (entry.Value == parsedAnswer)
                    correctAnswersCounter++;
                Console.Clear();

            }

            // Delov podolu e nekako duplo kod, ama prviot del so updatedStudent e edinstveniot nacin na kojsto uspeav da gi update-nam vrednostite na logiraniot student vo listata na studenti, kako podocna bi se prikazale tocni podatoci na logiran nastavnik, a bez vtoriot del pa ne mi registrirase deka studentot vekje go resil kvizot, pa  morav da gi ostaam dvete. Sigurna sum deka kje mi kazete prosto resenie i kje imam "AAAAAAA" moment, ama sea stvarno ne mi teknuva.

            Student updatedStudent = students.FirstOrDefault(x => x.FullName == loggedInStudent.FullName);
            if (updatedStudent != null)
            {
                updatedStudent.HasTakenQuiz = true;

                if (correctAnswersCounter == 0 || correctAnswersCounter == 1)
                    updatedStudent.GradeFromQuiz = Grade.F;
                else
                    updatedStudent.GradeFromQuiz = (Grade)correctAnswersCounter;
            }


            loggedInStudent.HasTakenQuiz = true;
            if (correctAnswersCounter == 0 || correctAnswersCounter == 1)
                loggedInStudent.GradeFromQuiz = Grade.F;
            else
                loggedInStudent.GradeFromQuiz = (Grade)correctAnswersCounter;



            switch ((int)loggedInStudent.GradeFromQuiz)
            {

                case 0:
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nYour quiz grade is {loggedInStudent.GradeFromQuiz}.\n" +
                        $"Study harder for the next quiz.");
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nYour quiz grade is {loggedInStudent.GradeFromQuiz}.\n" +
                        $"You passed, but just barely. Roll up your sleeves for the next quiz.");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"\nYour quiz grade is {loggedInStudent.GradeFromQuiz}.\n" +
                        $"Good effort, but there's still room for improvement.");
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nYour quiz grade is {loggedInStudent.GradeFromQuiz}.\n" +
                        $"Almost perfect! Good job.");
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYour quiz grade is {loggedInStudent.GradeFromQuiz}.\n" +
                        $"Excellent job. Keep up the hard work.");
                    break;
                default:
                    break;

            }

            Console.ResetColor();
            PressAnyKey();
            MainMenuLogin(members, teachers, students);
            return new Tuple<List<Person>, List<Student>>(members, students);

        }

        #endregion


        #region Login as Teacher and see Quiz Info

        public static void TeacherLogin(List<Person> members, List<Teacher> teachers, List<Student> students, Person memberLoggingIn)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Teacher loggedInTeacher = (Teacher)memberLoggingIn;
            Console.WriteLine($"\nWelcome, teacher {loggedInTeacher.FullName}!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nHere are the quiz results for all the students:\n");

            int counter = 1;
            students.ForEach(x =>
            {
                Console.Write($"{counter}. "); 
                x.PrintStudentQuizInfo();
                counter++;
            });

            PressAnyKey();
            MainMenuLogin(members, teachers, students);

        }

        #endregion
    }
}
