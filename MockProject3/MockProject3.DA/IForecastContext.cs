using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using MockProject3.DA.Models;
using MockProject3.DA;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace MockProject3.DA
{
    public interface IForecastContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Batch> Batches { get; set; }
        int SaveChanges();
    }
}
