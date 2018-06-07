﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MockProject3.DA;
using System;

namespace MockProject3.DA.Migrations
{
    [DbContext(typeof(ForecastContext))]
    [Migration("20180607175236_pedro-update")]
    partial class pedroupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MockProject3.DA.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasMaxLength(255);

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<Guid>("AddressId");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasMaxLength(25);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasMaxLength(2);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasMaxLength(5);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("MockProject3.DA.Models.Batch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.Property<Guid>("BatchId");

                    b.Property<string>("BatchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("BatchOccupancy");

                    b.Property<string>("BatchSkill")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("MockProject3.DA.Models.Name", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("First")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Last")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Middle")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<Guid>("NameId");

                    b.HasKey("Id");

                    b.ToTable("Name");
                });

            modelBuilder.Entity("MockProject3.DA.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Occupancy");

                    b.Property<Guid>("RoomId");

                    b.Property<int>("Vacancy");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("MockProject3.DA.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<Guid>("BatchId");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("NameId");

                    b.Property<Guid?>("RoomId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BatchId");

                    b.HasIndex("NameId");

                    b.HasIndex("RoomId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MockProject3.DA.Models.Batch", b =>
                {
                    b.HasOne("MockProject3.DA.Models.Address", "Address")
                        .WithMany("Batches")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MockProject3.DA.Models.Room", b =>
                {
                    b.HasOne("MockProject3.DA.Models.Address", "Address")
                        .WithMany("Rooms")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MockProject3.DA.Models.User", b =>
                {
                    b.HasOne("MockProject3.DA.Models.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId");

                    b.HasOne("MockProject3.DA.Models.Batch", "Batch")
                        .WithMany("Users")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MockProject3.DA.Models.Name", "Name")
                        .WithMany("Users")
                        .HasForeignKey("NameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MockProject3.DA.Models.Room", "Room")
                        .WithMany("Users")
                        .HasForeignKey("RoomId");
                });
#pragma warning restore 612, 618
        }
    }
}
