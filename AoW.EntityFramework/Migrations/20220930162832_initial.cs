using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AoW.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    Home = table.Column<int>(type: "INTEGER", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    SecondName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Profession = table.Column<string>(type: "TEXT", nullable: false),
                    Post = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkWear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkWear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraditionInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Term = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkWearID = table.Column<int>(type: "INTEGER", nullable: false),
                    StaffID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraditionInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraditionInfo_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraditionInfo_WorkWear_WorkWearID",
                        column: x => x.WorkWearID,
                        principalTable: "WorkWear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ProviderID = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkWerarID = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkWearId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptInfo_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptInfo_WorkWear_WorkWearId",
                        column: x => x.WorkWearId,
                        principalTable: "WorkWear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraditionInfo_StaffID",
                table: "ExtraditionInfo",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraditionInfo_WorkWearID",
                table: "ExtraditionInfo",
                column: "WorkWearID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptInfo_ProviderID",
                table: "ReceiptInfo",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptInfo_WorkWearId",
                table: "ReceiptInfo",
                column: "WorkWearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraditionInfo");

            migrationBuilder.DropTable(
                name: "ReceiptInfo");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "WorkWear");
        }
    }
}
