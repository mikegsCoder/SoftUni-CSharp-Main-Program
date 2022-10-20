using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "84323ef1-1aa9-4a64-bc88-183cce025616", 0, "d83446eb-7cbc-4b06-a22a-05552d9321df", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEG5Z3sThEggzTjBlDtVAamQwTg4KODfTWg4NDpWAapsKjaEmnBX7oze98wjI+RAkng==", null, false, "68bb9896-fe98-41a4-b830-0a4d22e8d5d2", false, "guest" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 20, 12, 41, 19, 259, DateTimeKind.Local).AddTicks(6010), "Learn using ASP.NET Core Identity", "84323ef1-1aa9-4a64-bc88-183cce025616", "Prepare for ASP.NET fundamentals exam" },
                    { 2, 3, new DateTime(2022, 5, 20, 12, 41, 19, 259, DateTimeKind.Local).AddTicks(6051), "Learn using EF Core and MS SQL Server Management Studio", "84323ef1-1aa9-4a64-bc88-183cce025616", "Improve EF Core skills" },
                    { 3, 2, new DateTime(2022, 10, 10, 12, 41, 19, 259, DateTimeKind.Local).AddTicks(6056), "Learn using ASP.NET Core Identity", "84323ef1-1aa9-4a64-bc88-183cce025616", "Improve ASP.NET Core skills" },
                    { 4, 2, new DateTime(2021, 10, 20, 12, 41, 19, 259, DateTimeKind.Local).AddTicks(6059), "Prepare for silving old Mid and Final exams", "84323ef1-1aa9-4a64-bc88-183cce025616", "Prepare for C# Fundamentals Exam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "84323ef1-1aa9-4a64-bc88-183cce025616");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
