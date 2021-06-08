using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Enums;
using TimeTracking.Domain.Core.Interfaces;

namespace TimeTracking.Domain.Core.Entities
{
    public class Exercise : Activity, IExercise
    {
        public TypeOfExercise ExerciseType { get; set; }


        public Exercise()
        {
        }

        public Exercise(TimeSpan duration, TypeOfExercise exerciseType) : base(duration)
        {
            Type = TypeOfActivity.Exercise;
            ExerciseType = exerciseType;

        }

        public override string Print()
        {
            string elapsedTime = String.Format("{0:00} hours {1:00} minutes {2:00} seconds", (int)Duration.TotalHours, (int)Duration.TotalMinutes, (int)Duration.TotalSeconds);

            return $"\nType of activity: {Type}\n" +
                $"Type of exercise: {ExerciseType}\n" +
                $"Duration: {elapsedTime}";
        }
    }
}
