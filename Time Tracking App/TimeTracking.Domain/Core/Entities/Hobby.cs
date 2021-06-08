using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Interfaces;
using TimeTracking.Domain.Core.Enums;

namespace TimeTracking.Domain.Core.Entities
{
    public class Hobby : Activity, IHobby
    {
        public TypeOfHobby Name { get; set; }

        public Hobby()
        {
        }

        public Hobby(TimeSpan duration, TypeOfHobby name) : base(duration)
        {
            Type = TypeOfActivity.Hobby;
            Name = name;
        }

        public override string Print()
        {
            string elapsedTime = String.Format("{0:00} hours {1:00} minutes {2:00} seconds", (int)Duration.TotalHours, (int)Duration.TotalMinutes, (int)Duration.TotalSeconds);

            return $"\nType of activity: {Type}\n" +
                $"Type of hobby: {Name}\n" +
                $"Duration: {elapsedTime}";
        }
    }
}
