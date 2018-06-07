using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MockProject3.DA.Migrations
{
    public partial class initialcreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    AddressId = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Name",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    First = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Last = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Middle = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    NameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Name", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    BatchId = table.Column<Guid>(nullable: false),
                    BatchName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    BatchOccupancy = table.Column<int>(nullable: false),
                    BatchSkill = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batches_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Occupancy = table.Column<int>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    Vacancy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: true),
                    BatchId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: true),
                    Type = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Name_NameId",
                        column: x => x.NameId,
                        principalTable: "Name",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_AddressId",
                table: "Batches",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AddressId",
                table: "Rooms",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BatchId",
                table: "Users",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NameId",
                table: "Users",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoomId",
                table: "Users",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Name");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
