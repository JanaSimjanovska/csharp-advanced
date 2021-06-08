using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Enums;

namespace TimeTracking.Domain.Core.Interfaces
{
    public interface IExercise
    {
        TypeOfExercise ExerciseType { get; set; }
    }
}
