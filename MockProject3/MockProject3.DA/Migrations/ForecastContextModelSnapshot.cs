﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MockProject3.DA;

namespace MockProject3.DA.Migrations
{
    [DbContext(typeof(ForecastContext))]
    partial class ForecastContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MockProject3.DA.Models.Batch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("Technology")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("Total");

                    b.HasKey("Id");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("MockProject3.DA.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasMaxLength(200);

                    b.Property<int>("Capacity");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("RoomID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("MockProject3.DA.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasMaxLength(200);

                    b.Property<int>("BatchID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int?>("RoomID");

                    b.HasKey("UserID");

                    b.HasIndex("BatchID");

                    b.HasIndex("RoomID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MockProject3.DA.Models.User", b =>
                {
                    b.HasOne("MockProject3.DA.Models.Batch", "Batch")
                        .WithMany("Users")
                        .HasForeignKey("BatchID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MockProject3.DA.Models.Room", "Room")
                        .WithMany("Users")
                        .HasForeignKey("RoomID");
                });
#pragma warning restore 612, 618
        }
    }
}
