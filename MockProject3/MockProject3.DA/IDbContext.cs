using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockProject3.DA
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>();
        int SaveChanges();
    }
}
