using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Enums;
using TimeTracking.Domain.Core.Interfaces;

namespace TimeTracking.Domain.Core.Entities
{
    public class Work : Activity, IWork
    {
        public Workplace WorkingPlace { get; set; }


        public Work()
        {
        }

        public Work(TimeSpan duration, Workplace workingplace) : base(duration)
        {
            Type = TypeOfActivity.Work;

            WorkingPlace = workingplace;

        }
        public override string Print()
        {
            string elapsedTime = String.Format("{0:00} hours {1:00} minutes {2:00} seconds", (int)Duration.TotalHours, (int)Duration.TotalMinutes, (int)Duration.TotalSeconds);

            return $"\nType of activity: {Type}\n" +
                $"Workplace: {WorkingPlace}\n" +
                $"Duration: {elapsedTime}";
        }
    }
}