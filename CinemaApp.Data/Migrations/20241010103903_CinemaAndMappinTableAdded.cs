using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CinemaAndMappinTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("5df5914f-9f47-4074-9d96-65f2ad688848"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("b1fbc843-c474-4a67-a6c5-08e61051b858"));

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.CinemaId);
                });

            migrationBuilder.CreateTable(
                name: "CinemasMovies",
                columns: table => new
                {
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemasMovies", x => new { x.MovieId, x.CinemaId });
                    table.ForeignKey(
                        name: "FK_CinemasMovies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "CinemaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CinemasMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CinemasMovies_CinemaId",
                table: "CinemasMovies",
                column: "CinemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemasMovies");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("46371a51-e904-4dd2-92e6-5029e70042d0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("a4c35f44-9b95-4867-a375-5bcdc190a230"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("5df5914f-9f47-4074-9d96-65f2ad688848"), "Something about friends and death evading stuff", "Someone2", 90, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1988), "FinalDestination" },
                    { new Guid("b1fbc843-c474-4a67-a6c5-08e61051b858"), "Thats a very stupid movie indeed!!!", "SomeDirector1", 120, "Horror", new DateTime(2024, 10, 2, 14, 22, 12, 304, DateTimeKind.Local).AddTicks(6093), "Joker" }
                });
        }
    }
}
