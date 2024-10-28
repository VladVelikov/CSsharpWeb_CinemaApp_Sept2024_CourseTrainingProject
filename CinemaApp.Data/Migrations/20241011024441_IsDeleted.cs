using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("1f036f88-2982-4d35-9b1c-2cfce55cbd66"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("5cc75bc9-0e46-4b4d-9582-3e6fff499a13"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("7016eeea-55c1-45eb-9a5e-6d76699913c6"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("46371a51-e904-4dd2-92e6-5029e70042d0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("a4c35f44-9b95-4867-a375-5bcdc190a230"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CinemasMovies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "CinemaId", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("2c9bc91b-1712-45be-8e23-2c14e400e5d7"), "Varna", "Cinemax" },
                    { new Guid("5f4c8dfd-5e2a-45eb-b90e-f9f5fb0b17a3"), "Plovdiv", "Cinema city" },
                    { new Guid("ad50839e-c1ee-42aa-a85a-20996ab4a56a"), "Sofia", "Cinema city" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("586f6beb-4978-4f49-97c2-b62030c8ec1d"), "Something about friends and death evading stuff", "Someone2", 90, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1988), "FinalDestination" },
                    { new Guid("ef61e5b2-28ad-4fcb-9ba9-7eaac028f8e0"), "Thats a very stupid movie indeed!!!", "SomeDirector1", 120, "Horror", new DateTime(2024, 10, 11, 5, 44, 40, 917, DateTimeKind.Local).AddTicks(8791), "Joker" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("2c9bc91b-1712-45be-8e23-2c14e400e5d7"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("5f4c8dfd-5e2a-45eb-b90e-f9f5fb0b17a3"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("ad50839e-c1ee-42aa-a85a-20996ab4a56a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("586f6beb-4978-4f49-97c2-b62030c8ec1d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ef61e5b2-28ad-4fcb-9ba9-7eaac028f8e0"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CinemasMovies");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "CinemaId", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("1f036f88-2982-4d35-9b1c-2cfce55cbd66"), "Plovdiv", "Cinema city" },
                    { new Guid("5cc75bc9-0e46-4b4d-9582-3e6fff499a13"), "Varna", "Cinemax" },
                    { new Guid("7016eeea-55c1-45eb-9a5e-6d76699913c6"), "Sofia", "Cinema city" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("46371a51-e904-4dd2-92e6-5029e70042d0"), "Something about friends and death evading stuff", "Someone2", 90, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1988), "FinalDestination" },
                    { new Guid("a4c35f44-9b95-4867-a375-5bcdc190a230"), "Thats a very stupid movie indeed!!!", "SomeDirector1", 120, "Horror", new DateTime(2024, 10, 10, 13, 39, 3, 252, DateTimeKind.Local).AddTicks(2234), "Joker" }
                });
        }
    }
}
