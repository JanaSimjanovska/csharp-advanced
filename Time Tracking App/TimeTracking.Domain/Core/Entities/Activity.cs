using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Enums;
using TimeTracking.Domain.Core.Interfaces;


namespace TimeTracking.Domain.Core.Entities
{
    public abstract class Activity : BaseEntity, IActivity
    {
        public TypeOfActivity Type { get; set; }
        public TimeSpan Duration { get; set; }

        public Activity()
        {
        }

        public Activity(TimeSpan duration)
        {
            Duration = duration;
        }

    }
}
