using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TimeTracking.Services.Services.Interfaces;
using TimeTracking.Domain.Core.Entities;
using TimeTracking.Domain.Db;

namespace TimeTracking.Services.Services.Implementations
{
    public class ActivityService<T> : IActivityService<T> where T : Domain.Core.Entities.Activity
    {
        private IDb<T> _db;

        public ActivityService()
        {
            _db = new FileSystemDb<T>();
        }
        public T GetById(int id)
        {
            return _db.GetById(id);
        }

        public bool IsDbEmpty()
        {
            return _db.GetAll().Count == 0;
        }

        public T Record(T activity)
        {

            int id = _db.Insert(activity);
            return _db.GetById(id);
        }
    }
}
