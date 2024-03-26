using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseNet.Data.Migrations
{
    public partial class SeedMaterials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "CourseId", "Description", "LectureId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Този материал представя основните принципи на обектно-ориентираното програмиране (OOP)(https://bg.wikipedia.org/wiki/%D0%9E%D0%B1%D0%B5%D0%BA%D1%82%D0%BD%D0%BE_%D0%BE%D1%80%D0%B8%D0%B5%D0%BD%D1%82%D0%B8%D1%80%D0%B0%D0%BD%D0%BE_%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%B8%D1%80%D0%B0%D0%BD%D0%B5), включително инкапсулация, наследяване и полиморфизъм.", 1, "Принципи на Обектно-ориентираното програмиране" },
                    { 2, null, "Този материал представя теми по програмирането на C#(https://bg.wikipedia.org/wiki/C_Sharp),включително работа с LINQ, асинхронно програмиране(https://learn.microsoft.com/bg-bg/dotnet/csharp/asynchronous-programming/) и напреднали структури на данни.", 2, "Програмиране на C#" },
                    { 3, null, "Този материал представя основни концепции и технологии в областта на базите данни(https://bg.wikipedia.org/wiki/%D0%91%D0%B0%D0%B7%D0%B0_%D0%B4%D0%B0%D0%BD%D0%BD%D0%B8), включително релационни бази данни, SQL заявки и моделиране на данни.", 3, "Основи на базите данни" },
                    { 4, null, "Този материал представя основни концепции в областта на бизнеса(https://bg.wikipedia.org/wiki/%D0%91%D0%B8%D0%B7%D0%BD%D0%B5%D1%81),включително управление на проекти, маркетинг и стратегическо планиране.", 4, "Основи на бизнеса" },
                    { 5, null, "Този материал представя основни принципи на дизайна(https://bg.wikipedia.org/wiki/%D0%94%D0%B8%D0%B7%D0%B0%D0%B9%D0%BD), включителноцветове, композиция и типография.", 5, "Дизайн принципи" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
