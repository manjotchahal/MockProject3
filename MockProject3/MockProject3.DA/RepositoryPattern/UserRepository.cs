using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MockProject3.DA;
using MockProject3.DA.Models;

namespace MockProject3.DA.RepositoryPattern
{
    public class UserRepository : IRepository<User>, IDisposable
    {
        private ForecastContext _context;

        public UserRepository(ForecastContext db = null)
        {
            _context = db ?? new ForecastContext();
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Count(e => e.UserId == id) > 0;
        }

        public IQueryable<User> Get()
        {
            return _context.Users;
        }

        public User Get(Guid id)
        {

            User user = _context.Users.Find(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
    }
}