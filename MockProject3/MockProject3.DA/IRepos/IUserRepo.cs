using System;
using System.Collections.Generic;
using MockProject3.DA.Models;

namespace MockProject3.DA.IRepos
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsersByDate(DateTime datetime);
        IEnumerable<User> GetUsersBetweenDates(DateTime Start, DateTime End);
        IEnumerable<User> GetUsersBetweenDatesAtLocation(DateTime Start, DateTime End, string location);
    }
}
