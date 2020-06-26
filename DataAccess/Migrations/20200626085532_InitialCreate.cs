using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    LogTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    DealerName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LogTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[] { 1, 1, new DateTime(2020, 6, 26, 11, 55, 31, 666, DateTimeKind.Local).AddTicks(4176), "Login" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2020, 6, 26, 11, 55, 31, 652, DateTimeKind.Local).AddTicks(6245), "CallCenter" },
                    { 2, 2, new DateTime(2020, 6, 26, 11, 55, 31, 660, DateTimeKind.Local).AddTicks(3184), "Dealer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "CreatedBy", "CreatedDate", "DealerId", "DealerName", "Email", "FullName", "IsActive", "Password", "Phone", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Test mah. Test sokak.", "İstanbul", 1, new DateTime(2020, 6, 26, 11, 55, 31, 664, DateTimeKind.Local).AddTicks(9527), 123123, "Dealer1", null, "Test", true, "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195", "5552223355", 1, 1, new DateTime(2020, 6, 26, 11, 55, 31, 664, DateTimeKind.Local).AddTicks(7804) },
                    { 2, null, null, 1, new DateTime(2020, 6, 26, 11, 55, 31, 665, DateTimeKind.Local).AddTicks(8788), null, null, null, "Dealer2", true, "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195", null, 2, 1, new DateTime(2020, 6, 26, 11, 55, 31, 665, DateTimeKind.Local).AddTicks(8747) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "LogTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
