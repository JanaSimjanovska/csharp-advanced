using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Interfaces;

namespace TimeTracking.Domain.Core.Entities
{
    public class User : BaseEntity, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Exercise> TrackedExercisesDb { get; set; }
        public List<Work> TrackedWorkDb { get; set; }
        public List<Reading> TrackedReadingDb { get; set; }
        public List<Hobby> TrackedHobbiesDb { get; set; }

        public bool isAccountDeactivated { get; set; }

        public User()
        {
        }

        public User(string first, string last, int age, string username, string pass)
        {
            FirstName = first;
            LastName = last;
            Age = age;
            Username = username;
            Password = pass;
            TrackedExercisesDb = new List<Exercise>();
            TrackedWorkDb = new List<Work>();
            TrackedReadingDb = new List<Reading>();
            TrackedHobbiesDb = new List<Hobby>();
            isAccountDeactivated = false;
        }

        public override string Print()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
