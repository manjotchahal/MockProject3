using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MockProject3.DAL.Models
{
    public partial class ForecastDB1Context : DbContext
    {
        public ForecastDB1Context()
        {
        }

        public ForecastDB1Context(DbContextOptions<ForecastDB1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Batches> Batches { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=dotnetdb.cn1ktfvmabbg.us-east-2.rds.amazonaws.com;Initial Catalog=ForecastDB1;User ID=sqladmin;Password=password123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batches>(entity =>
            {
                entity.ToTable("Batches", "Forecast");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Technology).IsRequired();
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.ToTable("Rooms", "Forecast");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Gender).IsRequired();

                entity.Property(e => e.Modified).HasColumnType("datetime");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Forecast");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Gender).IsRequired();

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BatchId)
                    .HasConstraintName("FK__Users__BatchId__4E88ABD4");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Users__RoomId__4D94879B");
            });
        }
    }
}
