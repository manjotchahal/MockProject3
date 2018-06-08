using System;
using System.Collections.Generic;
using System.Text;
using MockProject3.DA.Models;

namespace MockProject3.DA.Repos
{
    public interface IRepo<T>
    {
        IEnumerable<string> GetLocations();
        IEnumerable<T> Get();
        IEnumerable<T> GetByDate(DateTime datetime);
        IEnumerable<T> GetBetweenDates(DateTime Start, DateTime End);
        IEnumerable<T> GetBetweenDatesAtLocation(DateTime Start, DateTime End, string location);
    }
}
