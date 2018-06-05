using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MockProject3.DA.Models;

namespace MockProject3.DA
{
    class ForecastContext: DbContext
    {
        public ForecastContext() : base(Configuration.Get)
        {

        }

        public ForecastContext(string connectionString) : this(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Users> Rooms { get; set; }
        public DbSet<Users> Batches { get; set; }

        //IDbSet<TEntity> IDbContext.Set<TEntity>()
        //{
        //    return base.Set<TEntity>();
        //}

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
