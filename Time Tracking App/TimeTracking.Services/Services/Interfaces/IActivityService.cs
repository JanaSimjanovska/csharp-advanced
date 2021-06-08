using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Entities;

namespace TimeTracking.Services.Services.Interfaces
{
    public interface IActivityService<T> where T : Activity
    {
        T Record(T activity);
        T GetById(int id);
        bool IsDbEmpty();
    }
}
