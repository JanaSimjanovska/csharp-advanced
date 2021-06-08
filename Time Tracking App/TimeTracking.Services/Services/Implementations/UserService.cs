using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTracking.Domain.Core.Entities;
using TimeTracking.Domain.Core.Enums;
using TimeTracking.Domain.Db;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Services.Interfaces;

namespace TimeTracking.Services.Services.Implementations
{
    public class UserService<T> : IUserService<T> where T : User
    {
        private IDb<T> _db;
        private static IActivityService<Exercise> _exerciseService = new ActivityService<Exercise>();
        private static IActivityService<Work> _workService = new ActivityService<Work>();
        private static IActivityService<Reading> _readingService = new ActivityService<Reading>();
        private static IActivityService<Hobby> _hobbyService = new ActivityService<Hobby>();

        public UserService()
        {
            _db = new FileSystemDb<T>();
        }
        public void ChangeFirstName(int userId, string firstName)
        {
            Console.Clear();

            T user = _db.GetById(userId);
            if (ValidationHelper.ValidateFirstName(firstName) == null)
            {
                MessageHelper.Color("[Error] First name not valid. Please try again!", ConsoleColor.Red);
                MessageHelper.PressAnyKey();
                return;
            }
            user.FirstName = firstName;
            _db.Update(user);
            MessageHelper.Color("First name successfuly changed!", ConsoleColor.Green);
            MessageHelper.PressAnyKey();
            Console.Clear();
        }

        public void ChangeLastName(int userId, string lastName)
        {
            Console.Clear();

            T user = _db.GetById(userId);
            if (ValidationHelper.ValidateLastName(lastName) == null)
            {
                MessageHelper.Color("[Error] Last name not valid. Please try again!", ConsoleColor.Red);
                MessageHelper.PressAnyKey();
                return;
            }
            user.LastName = lastName;
            _db.Update(user);
            MessageHelper.Color("Last name successfuly changed!", ConsoleColor.Green);
            MessageHelper.PressAnyKey();
            Console.Clear();

        }

        public void ChangePassword(int userId, string oldPassword, string newPassword)
        {
            Console.Clear();

            T user = _db.GetById(userId);
            if (user.Password != oldPassword)
            {
                MessageHelper.Color("[Error] Old password did not match", ConsoleColor.Red);
                MessageHelper.PressAnyKey();
                return;
            }
            if (ValidationHelper.ValidatePassword(newPassword) == null)
            {
                MessageHelper.Color("[Error] New password is not valid", ConsoleColor.Red);
                MessageHelper.PressAnyKey();
                return;
            }
            user.Password = newPassword;
            _db.Update(user);
            MessageHelper.Color("Password successfully changed!", ConsoleColor.Green);
            MessageHelper.PressAnyKey();
            Console.Clear();

        }

        public void DeactivateAccount(int userId)
        {
            Console.Clear();

            T user = _db.GetById(userId);
            user.isAccountDeactivated = true;
            _db.Update(user);
            MessageHelper.Color("Your account has been deactivated", ConsoleColor.Green);
            MessageHelper.PressAnyKey();
            Console.Clear();


        }
        public T GetById(int id)
        {
            return _db.GetById(id);
        }

        public bool IsDbEmpty()
        {
            return _db.GetAll().Count == 0;
        }

        public T Login(string username, string password)
        {
            T user = _db.GetAll()
                        .SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
            {
                MessageHelper.Color("[Error] No such user", ConsoleColor.Red);
                AttemptsChecker.HowManyAttempts();
                return null;
            }

            if (user.isAccountDeactivated)
            {
                MessageHelper.Color("Your account is deactivated. Would you like to activate it? Y/N", ConsoleColor.Yellow);
                ConsoleKey userChoice = Console.ReadKey(true).Key;

                while (userChoice != ConsoleKey.Y && userChoice != ConsoleKey.N)
                {
                    Console.Clear();
                    MessageHelper.Color("Please choose Y if you want to reactivate your account, and N if you don't.", ConsoleColor.Magenta);
                    userChoice = Console.ReadKey(true).Key;
                }

                if (userChoice == ConsoleKey.N) return null;

                user.isAccountDeactivated = false;
                _db.Update(user);
                Console.Clear();
                MessageHelper.Color($"Your account has been successfully activated", ConsoleColor.Green);
                MessageHelper.PressAnyKey();
            }


            Console.Clear();
            MessageHelper.Color($"\nWelcome {user.Username}", ConsoleColor.Green);
            return user;
        }

        public T Register(T user)
        {
            if (user.FirstName == null ||
                user.LastName == null ||
                user.Username == null ||
                user.Password == null ||
                user.Age == 0)
            {
                MessageHelper.Color("[Error] Invalid info!", ConsoleColor.Red);
                MessageHelper.PressAnyKey();

                return null;
            }

            foreach (var x in _db.GetAll())
            {
                if (user.Username == x.Username)
                {
                    MessageHelper.Color("[Error] Username already exists", ConsoleColor.Red);
                    MessageHelper.PressAnyKey();

                    return null;

                }
            }
            foreach (var x in _db.GetAll())
            {
                if (user.Password == x.Password)
                {
                    MessageHelper.Color("[Error] Password already exists", ConsoleColor.Red);
                    MessageHelper.PressAnyKey();

                    return null;

                }
            }

            int id = _db.Insert(user);

            if(user.Id != 1) // ova e za da izlaga na sam start pri povikuvanje na seed, da ne se startuva aplikacijata so ova :)
            {
                MessageHelper.Color($"\nRegistration successful. Go ahead and explore the options that our app offers.", ConsoleColor.Green);
                MessageHelper.PressAnyKey();
            }
                
            Console.Clear();
            return _db.GetById(id);
        }

        public void UpdateActivityList(int userId, Activity activity)
        {
            T user = _db.GetById(userId);
            if (activity == null)
            {
                MessageHelper.Color("[Error] Activity not valid. Please try again!", ConsoleColor.Red);
                MessageHelper.PressAnyKey();

                return;
            }

            if(activity.GetType() == typeof(Exercise))
                user.TrackedExercisesDb.Add(_exerciseService.Record((Exercise)activity));

            if (activity.GetType() == typeof(Work))
                user.TrackedWorkDb.Add(_workService.Record((Work)activity));

            if (activity.GetType() == typeof(Reading))
                user.TrackedReadingDb.Add(_readingService.Record((Reading)activity));

            if (activity.GetType() == typeof(Hobby))
                user.TrackedHobbiesDb.Add(_hobbyService.Record((Hobby)activity));

            _db.Update(user);
            MessageHelper.Color($"\nActivity successfully tracked.", ConsoleColor.Green);
            MessageHelper.Color($"{activity.Print()}", ConsoleColor.DarkCyan);
            MessageHelper.PressAnyKey();
            Console.Clear();

        }

        #region Display statistics method

        public void DisplayStats(int userId, int chosenOption)
        {
            T user = _db.GetById(userId);
            TimeSpan totalHours = new TimeSpan();
            TimeSpan totalReadingHours = new TimeSpan();
            TimeSpan totalExerciseHours = new TimeSpan();
            TimeSpan totalWorkHours = new TimeSpan();
            TimeSpan totalHobbyHours = new TimeSpan();
            TimeSpan totalAtHome = new TimeSpan();
            TimeSpan totalAtOffice = new TimeSpan();
            int totalPages = 0;



            switch (chosenOption)
            {
                case 1:
                    if(user.TrackedReadingDb.Count == 0)
                    {
                        Console.WriteLine("\nYou haven't tracked any reading activity.");
                        MessageHelper.PressAnyKey();

                        break;
                    }
                    user.TrackedReadingDb.ForEach(x =>
                    {
                        totalReadingHours += x.Duration;
                        totalPages += x.Pages;
                        
                    });
                    TimeSpan avgReading = totalReadingHours / user.TrackedReadingDb.Count;
                    Console.WriteLine($"\nTracked reading total time: {(int)totalReadingHours.TotalHours} hours");
                    Console.WriteLine($"\nAverage reading duration: {(int)avgReading.TotalMinutes} minutes");
                    Console.WriteLine($"\nTotal pages read: {totalPages}");

                    TypeOfLiterature maxTypeLitCount = user.TrackedReadingDb
                                        .Select(x => x.LiteratureType)
                                        .GroupBy(x => x)
                                        .OrderByDescending(x => x.Count())
                                        .Select(x => x.Key)
                                        .First();

                    Console.WriteLine($"\nFavorite type of literature: {maxTypeLitCount}");
                    MessageHelper.PressAnyKey();

                    break;

                case 2:
                    if (user.TrackedExercisesDb.Count == 0)
                    {
                        Console.WriteLine("\nYou haven't tracked any exercising activity.");
                        MessageHelper.PressAnyKey();

                        break;
                    }
                    user.TrackedExercisesDb.ForEach(x =>
                    {
                        totalExerciseHours += x.Duration;
                        
                    });
                    TimeSpan avgExercise = totalExerciseHours / user.TrackedExercisesDb.Count;
                    Console.WriteLine($"\nTracked exercise total time: {(int)totalExerciseHours.TotalHours} hours");
                    Console.WriteLine($"\nAverage exercise duration: {(int)avgExercise.TotalMinutes} minutes");

                    TypeOfExercise maxTypeExCount = user.TrackedExercisesDb
                                        .Select(x => x.ExerciseType)
                                        .GroupBy(x => x)
                                        .OrderByDescending(x => x.Count())
                                        .Select(x => x.Key)
                                        .First();

                    Console.WriteLine($"\nFavorite type of exercise: {maxTypeExCount}");
                    MessageHelper.PressAnyKey();

                    break;

                case 3:
                    if (user.TrackedWorkDb.Count == 0)
                    {
                        Console.WriteLine("\nYou haven't tracked any work activity.");
                        MessageHelper.PressAnyKey();

                        break;
                    }
                    user.TrackedWorkDb.ForEach(x =>
                    {
                        totalWorkHours += x.Duration;

                        totalAtHome = x.WorkingPlace == Workplace.FromHome ? totalAtHome += x.Duration : totalAtOffice += x.Duration;
                        
                        
                    });
                    TimeSpan avgWork = totalWorkHours / user.TrackedWorkDb.Count;
                    Console.WriteLine($"\nTracked work total time: {(int)totalWorkHours.TotalHours} hours");
                    Console.WriteLine($"\nAverage work session duration: {(int)avgWork.TotalMinutes} minutes");
                    Console.WriteLine($"\nFrom Home vs. At the Office work hours: {(int)totalAtHome.TotalHours} hours : {(int)totalAtOffice.TotalHours} hours");
                    MessageHelper.PressAnyKey();

                    break;

                case 4:
                    if (user.TrackedHobbiesDb.Count == 0)
                    {
                        Console.WriteLine("\nYou haven't tracked any hobbies.");
                        MessageHelper.PressAnyKey();

                        break;
                    }
                    Console.WriteLine("\nAll hobbies tracked:");
                    int num = 1;
                    user.TrackedHobbiesDb.ForEach(x =>
                    {
                        totalHobbyHours += x.Duration;
                        Console.WriteLine($"{num}.{x.Name}");
                        num++;
                        
                    });
                    TimeSpan avgHobby = totalHobbyHours / user.TrackedHobbiesDb.Count;
                    Console.WriteLine($"\nTracked hobbies total time: {(int)totalHobbyHours.TotalHours} hours");
                    Console.WriteLine($"\nAverage hobby activity duration: {(int)avgHobby.TotalMinutes} minutes");
                    MessageHelper.PressAnyKey();

                    break;

                case 5:
                    if(user.TrackedReadingDb.Count == 0 &&
                        user.TrackedExercisesDb.Count == 0 &&
                        user.TrackedWorkDb.Count == 0 &&
                        user.TrackedHobbiesDb.Count == 0)
                    {
                        Console.WriteLine("\nYou haven't tracked any activities.");
                        MessageHelper.PressAnyKey();
                        break;
                    }

                    foreach(var x in user.TrackedReadingDb)
                        totalHours += x.Duration;
                    foreach (var x in user.TrackedExercisesDb)
                        totalHours += x.Duration;
                    foreach (var x in user.TrackedWorkDb)
                        totalHours += x.Duration;
                    foreach (var x in user.TrackedHobbiesDb)
                        totalHours += x.Duration;
                        Console.WriteLine($"\nAll tracked activities total time: {(int)totalHours.TotalHours} hours");

                    List<int> activitiesCount = new List<int>() { user.TrackedReadingDb.Count, user.TrackedExercisesDb.Count, user.TrackedWorkDb.Count, user.TrackedHobbiesDb.Count };

                    int maxCount = activitiesCount.Max();

                    Console.WriteLine("\nFavorite activity (most tracked type):\n");

                    //string reading = user.TrackedReadingDb.Count == maxCount ? $"Reading - {maxCount} records." : null;
                    //string exercise = user.TrackedExercisesDb.Count == maxCount ? $"Exercise - {maxCount} records." : null;
                    //string work = user.TrackedWorkDb.Count == maxCount ? $"Work - {maxCount} records." : null;
                    //string hobby = user.TrackedHobbiesDb.Count == maxCount ? $"Hobby - {maxCount} records." : null;

                    //List<string> favActivity = new List<string>(){ reading, exercise, work, hobby };

                    //favActivity.ForEach(x =>
                    //{
                    //    if (x != null) Console.WriteLine(x);
                    //});

                    if (user.TrackedReadingDb.Count == maxCount)
                    {
                        Console.WriteLine($"Reading - {maxCount} records.");
                    }
                    if (user.TrackedExercisesDb.Count == maxCount)
                    {
                        Console.WriteLine($"Exercise - {maxCount} records.");
                    }
                    if (user.TrackedWorkDb.Count == maxCount)
                    {
                        Console.WriteLine($"Work - {maxCount} records.");
                    }
                    if (user.TrackedHobbiesDb.Count == maxCount)
                    {
                        Console.WriteLine($"Hobby - {maxCount} records.");
                    }

                    MessageHelper.PressAnyKey();

                    break;
                case 6:
                    break;
            }
            Console.Clear();

        }

        #endregion

    }
}
