using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoviUrlAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("08c8292c-39ee-44d0-9981-8aa01d27e26e"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("7310ad9d-e63f-4f52-8709-8739b784272e"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("c642cf06-97de-4698-9287-72079bf3d876"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("17017f81-32b2-4261-86d1-544939f29636"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("904b2047-358c-483a-82df-b9693cdf111e"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                defaultValue: "~/images/No_Image_Available.jpg");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "CinemaId", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("13e7190b-0d85-464a-8c19-a15c27b2ce07"), "Plovdiv", "Cinema city" },
                    { new Guid("912175b5-9873-46ca-a650-7d9090fca5e2"), "Sofia", "Cinema city" },
                    { new Guid("d8b2417d-5e61-41a9-8cf6-5cc5f2a69990"), "Varna", "Cinemax" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("35bd7e28-d190-4796-a719-e7b2707bd96f"), "Thats a very stupid movie indeed!!!", "SomeDirector1", 120, "Horror", new DateTime(2024, 10, 14, 10, 50, 55, 126, DateTimeKind.Local).AddTicks(9043), "Joker" },
                    { new Guid("7e6a1043-ab3f-42ae-b314-87a5ea02f814"), "Something about friends and death evading stuff", "Someone2", 90, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1988), "FinalDestination" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("13e7190b-0d85-464a-8c19-a15c27b2ce07"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("912175b5-9873-46ca-a650-7d9090fca5e2"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("d8b2417d-5e61-41a9-8cf6-5cc5f2a69990"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("35bd7e28-d190-4796-a719-e7b2707bd96f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7e6a1043-ab3f-42ae-b314-87a5ea02f814"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "CinemaId", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("08c8292c-39ee-44d0-9981-8aa01d27e26e"), "Plovdiv", "Cinema city" },
                    { new Guid("7310ad9d-e63f-4f52-8709-8739b784272e"), "Sofia", "Cinema city" },
                    { new Guid("c642cf06-97de-4698-9287-72079bf3d876"), "Varna", "Cinemax" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("17017f81-32b2-4261-86d1-544939f29636"), "Thats a very stupid movie indeed!!!", "SomeDirector1", 120, "Horror", new DateTime(2024, 10, 14, 10, 38, 5, 171, DateTimeKind.Local).AddTicks(3217), "Joker" },
                    { new Guid("904b2047-358c-483a-82df-b9693cdf111e"), "Something about friends and death evading stuff", "Someone2", 90, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1988), "FinalDestination" }
                });
        }
    }
}
