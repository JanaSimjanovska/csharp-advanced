using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Entities;

namespace TimeTracking.Domain.Core.Interfaces
{
    public interface IUser
    {

        string FirstName { get; set; }

        string LastName { get; set; }

        int Age { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        bool isAccountDeactivated { get; set; }



    }
}
