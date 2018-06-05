using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MockProject3.DA.Models;

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

        //connection string
        //    <add name="ForecastDb" connectionString="Data Source=dotnetdb.cn1ktfvmabbg.us-east-2.rds.amazonaws.com;Initial Catalog=ForecastDb;Persist Security Info=True;User ID=sqladmin;Password=password123" providerName="System.Data.SqlClient" />

        
        public ForecastContext(DbContextOptions<ForecastContext> options) : base(options)
        {

        }
        

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Batch> Batches { get; set; }

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
