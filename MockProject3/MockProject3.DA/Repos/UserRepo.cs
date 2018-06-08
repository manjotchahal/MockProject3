using System;
using System.Collections.Generic;
using System.Text;
using MockProject3.DA.IRepos;
using MockProject3.DA.Models;

namespace MockProject3.DA.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly ForecastContext _context;
        public UserRepo(ForecastContext context)
        {
            _context = context;
        }

        public User GetUserByDate(DateTime datetime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public IEnumerable<User> GetUsersBetweenDates(DateTime Start, DateTime End)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersBetweenDatesAtLocation(DateTime Start, DateTime End, string location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersByDate(DateTime datetime)
        {
            throw new NotImplementedException();
        }
    }
}
