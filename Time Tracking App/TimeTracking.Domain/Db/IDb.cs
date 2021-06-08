using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Entities;

namespace TimeTracking.Domain.Db
{
    public interface IDb<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void RemoveById(int id);
        void Update(T entity);
    }
}
