using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Entities;

namespace TimeTracking.Services.Services.Interfaces
{
    public interface IUserService<T> where T : User
    {
        T Register(T user);
        T Login(string username, string password);

        void ChangePassword(int userId, string oldPassword, string newPassword);
        void ChangeFirstName(int userId, string firstName);
        void ChangeLastName(int userId, string lastName);

        void DeactivateAccount(int userId);

        void UpdateActivityList(int userId, Activity activity);

        void DisplayStats(int userId, int chosenOption);

        T GetById(int id);
        bool IsDbEmpty();
    }
}
