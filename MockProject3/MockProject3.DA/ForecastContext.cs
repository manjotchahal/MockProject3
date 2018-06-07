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
    public class ForecastContext: DbContext
    {
        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("Creating db");
        //    ForecastContext db = new ForecastContext();
        //    db.SaveChanges();
        //}

        public ForecastContext()
        {
        }

        public ForecastContext(DbContextOptions<ForecastContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=dotnetdb.cn1ktfvmabbg.us-east-2.rds.amazonaws.com;Initial Catalog=ForecastDB2;User ID=sqladmin;Password=password123");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Batch> Batches { get; set; }

        public override int SaveChanges()
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("Created").CurrentValue = DateTime.Now;
                E.Property("Modified").CurrentValue = DateTime.Now;
            });

            var ModifiedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            ModifiedEntities.ForEach(E =>
            {
                E.Property("Modified").CurrentValue = DateTime.Now;
            });
            return base.SaveChanges();
        }
    }
}
