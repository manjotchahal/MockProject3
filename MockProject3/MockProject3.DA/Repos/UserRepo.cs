﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MockProject3.DA;
using MockProject3.DA.Models;

namespace MockProject3.DA.Repos
{
    public class UserRepo : IRepo<User>, IDisposable
    {
        private readonly IForecastContext _context;
        public UserRepo(IForecastContext context)
        {
            _context = context;
        }

        public IEnumerable<string> GetLocations()
        {
            return _context.Users.Select(r => r.Location).Where(r => r != null).Distinct();
        }

        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        public IEnumerable<User> GetBetweenDates(DateTime Start, DateTime End)
        {
            return _context.Users.Where(u => u.Created <= Start && (u.Deleted > End || u.Deleted == null));
        }

        public IEnumerable<User> GetBetweenDatesAtLocation(DateTime Start, DateTime End, string location)
        {
            return _context.Users.Where(u => u.Created <= Start && (u.Deleted > End || u.Deleted == null) && u.Location == location);
        }

        public IEnumerable<User> GetByDate(DateTime datetime)
        {
            return _context.Users.Where(u => u.Created <= datetime && (u.Deleted == null || u.Deleted > datetime));
        }

        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
    }
}
