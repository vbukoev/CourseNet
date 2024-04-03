using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class ChangedUsernameOfUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("76d3d210-1cd7-4671-b5f2-fe2d852b2393"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cc82f169-0e9b-46b5-b255-b436e757539b"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("556ef159-d702-4b2e-9829-96adcf643df3"), 0, "2b5598a7-19e0-43bd-a121-71577368aca4", "test@students.com", false, "Student", "Studentov", false, null, "test@students.com", "TEST", "AQAAAAEAACcQAAAAEGtnSPhUNvh2PgES0KAx6g1y6tYihr3N1RdXYMeQTzeGh99onWkyOdBNDviBeMzVyA==", null, false, null, false, "test@students.com" },
                    { new Guid("600b8960-0a29-4061-a53a-50331e6aa0cf"), 0, "39d11e92-c450-46a2-b325-fe01d0061d24", "admin@admins.com", false, "Admin", "Adminov", false, null, "admin@admins.com", "ADMIN", "AQAAAAEAACcQAAAAEFHo92X2kfkHaGNMHgv5UrG+AGh9aqFxmO7A8pzOrSCBVXSF9tRsCVYaxFlWMJWQvQ==", null, false, null, false, "admin@admins.com" }
                });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Този материал представя основните принципи на обектно-ориентираното програмиране (OOP), включително инкапсулация, наследяване и полиморфизъм.");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Този материал представя теми по програмирането на C#,включително работа с LINQ, асинхронно програмиране и напреднали структури на данни.");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Този материал представя основни концепции и технологии в областта на базите данни, включително релационни бази данни, SQL заявки и моделиране на данни.");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Този материал представя основни концепции в областта на бизнеса,включително управление на проекти, маркетинг и стратегическо планиране.");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Този материал представя основни принципи на дизайна, включителноцветове, композиция и типография.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("556ef159-d702-4b2e-9829-96adcf643df3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("600b8960-0a29-4061-a53a-50331e6aa0cf"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("76d3d210-1cd7-4671-b5f2-fe2d852b2393"), 0, "7bcef810-487d-4b2f-b20d-558f0a9e8aec", "admin@admins.com", false, "Admin", "Adminov", false, null, "admin@admins.com", "ADMIN", "AQAAAAEAACcQAAAAEHivRs38wnNAt5A2qRQvoiQNSGtVEZDaMekQYbQf1LF1BZW0zVo45n8skm9aHltKVQ==", null, false, null, false, "admin" },
                    { new Guid("cc82f169-0e9b-46b5-b255-b436e757539b"), 0, "c60600ec-2d16-45f0-89e1-c9056661c7a5", "test@students.com", false, "Student", "Studentov", false, null, "test@students.com", "TEST", "AQAAAAEAACcQAAAAEP+speOgxR1w+DjtQ3Kn+K55nH6g0xPQazClJ2yJMUsirUaHK+NC7Rfv1IJLjMj9eA==", null, false, null, false, "test" }
                });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Този материал представя основните принципи на обектно-ориентираното програмиране (OOP)(https://bg.wikipedia.org/wiki/%D0%9E%D0%B1%D0%B5%D0%BA%D1%82%D0%BD%D0%BE_%D0%BE%D1%80%D0%B8%D0%B5%D0%BD%D1%82%D0%B8%D1%80%D0%B0%D0%BD%D0%BE_%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%B8%D1%80%D0%B0%D0%BD%D0%B5), включително инкапсулация, наследяване и полиморфизъм.");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Този материал представя теми по програмирането на C#(https://bg.wikipedia.org/wiki/C_Sharp),включително работа с LINQ, асинхронно програмиране(https://learn.microsoft.com/bg-bg/dotnet/csharp/asynchronous-programming/) и напреднали структури на данни.");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Този материал представя основни концепции и технологии в областта на базите данни(https://bg.wikipedia.org/wiki/%D0%91%D0%B0%D0%B7%D0%B0_%D0%B4%D0%B0%D0%BD%D0%BD%D0%B8), включително релационни бази данни, SQL заявки и моделиране на данни.");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Този материал представя основни концепции в областта на бизнеса(https://bg.wikipedia.org/wiki/%D0%91%D0%B8%D0%B7%D0%BD%D0%B5%D1%81),включително управление на проекти, маркетинг и стратегическо планиране.");

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Този материал представя основни принципи на дизайна(https://bg.wikipedia.org/wiki/%D0%94%D0%B8%D0%B7%D0%B0%D0%B9%D0%BD), включителноцветове, композиция и типография.");
        }
    }
}
