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
        DbSet<Address> Addresses { get; set; }
        DbSet<Batch> Batches { get; set; }
        DbSet<Name> Names{ get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Snapshot> Snapshots { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
