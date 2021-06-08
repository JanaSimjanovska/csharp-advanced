using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Interfaces;

namespace TimeTracking.Domain.Core.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public abstract string Print();
    }
}
