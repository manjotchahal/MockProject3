using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public IEnumerable<User> GetUsersBetweenDates(DateTime Start, DateTime End)
        {
            return _context.Users.Where(u => u.Created <= Start && (u.Deleted > End || u.Deleted == null));
        }

        public IEnumerable<User> GetUsersBetweenDatesAtLocation(DateTime Start, DateTime End, string location)
        {
            return _context.Users.Where(u => u.Created <= Start && (u.Deleted > End || u.Deleted == null) && u.Location == location);
        }

        public IEnumerable<User> GetUsersByDate(DateTime datetime)
        {
            return _context.Users.Where(u => u.Created <= datetime && (u.Deleted == null || u.Deleted > datetime));
        }
    }
}
