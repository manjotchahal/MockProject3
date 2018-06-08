﻿using System;
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
    /// <summary>
    /// A ForecastContext instance represents a session with the database and is used to query and save instances of the entities.
    /// </summary>
    /// <remarks>
    /// A ForecastContext instance contains DbSets of Users, Rooms, Batches, Addresses, and Names.
    /// </remarks>
    public class ForecastContext: DbContext
    {
        /// <summary>
        /// The ForecastContext constructor is the constructor for the context.
        /// </summary>
        /// <remarks>
        /// This constructor pulls the connection string from the appsettings.json configuration file.
        /// </remarks>
        /// <param name="options">Provides the options configurations for the ForecastContext, pulled from appsettings.json.</param>
        public ForecastContext(DbContextOptions<ForecastContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Name> Names { get; set; }
        
        /// <summary>
        /// Saves all changes made in this context to the database as well as update the Created and Modified fields for each set.
        /// </summary>
        /// <returns>Returns the number of state entries written to the database.</returns>
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
