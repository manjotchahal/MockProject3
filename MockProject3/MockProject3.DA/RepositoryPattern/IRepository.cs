using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockProject3.DA.RepositoryPattern
{
    public interface IRepository<T> 
    {
        IQueryable<T> Get();
        T Get(Guid id);
    }
}