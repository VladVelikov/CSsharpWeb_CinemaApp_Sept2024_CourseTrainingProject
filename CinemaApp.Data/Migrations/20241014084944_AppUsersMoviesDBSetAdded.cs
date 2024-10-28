using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppUsersMoviesDBSetAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMovie_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMovie_Movies_MovieId",
                table: "ApplicationUserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserMovie",
                table: "ApplicationUserMovie");

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

            migrationBuilder.RenameTable(
                name: "ApplicationUserMovie",
                newName: "ApplicationUsersMovies");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserMovie_MovieId",
                table: "ApplicationUsersMovies",
                newName: "IX_ApplicationUsersMovies_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                defaultValue: "~/images/NoImage.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true,
                oldDefaultValue: "~/images/No_Image_Available.jpg");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsersMovies",
                table: "ApplicationUsersMovies",
                columns: new[] { "ApplicationUserId", "MovieId" });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "CinemaId", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("0c0ce6c0-c5d6-4b81-bb85-db5a779c1d9e"), "Varna", "Cinemax" },
                    { new Guid("a9dcf1ec-ea61-4dea-9dd4-590d7598e226"), "Sofia", "Cinema city" },
                    { new Guid("e4f2d709-dbed-439f-b0af-8eded65c7d01"), "Plovdiv", "Cinema city" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("d6681be0-8af8-491b-85f6-ada7a079c478"), "Something about friends and death evading stuff", "Someone2", 90, "Horror", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1988), "FinalDestination" },
                    { new Guid("fa52752e-5894-4e9d-b71c-619387bd15b3"), "Thats a very stupid movie indeed!!!", "SomeDirector1", 120, "Horror", new DateTime(2024, 10, 14, 11, 49, 43, 372, DateTimeKind.Local).AddTicks(3357), "Joker" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersMovies_AspNetUsers_ApplicationUserId",
                table: "ApplicationUsersMovies",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersMovies_Movies_MovieId",
                table: "ApplicationUsersMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersMovies_AspNetUsers_ApplicationUserId",
                table: "ApplicationUsersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersMovies_Movies_MovieId",
                table: "ApplicationUsersMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsersMovies",
                table: "ApplicationUsersMovies");

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("0c0ce6c0-c5d6-4b81-bb85-db5a779c1d9e"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("a9dcf1ec-ea61-4dea-9dd4-590d7598e226"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "CinemaId",
                keyValue: new Guid("e4f2d709-dbed-439f-b0af-8eded65c7d01"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d6681be0-8af8-491b-85f6-ada7a079c478"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fa52752e-5894-4e9d-b71c-619387bd15b3"));

            migrationBuilder.RenameTable(
                name: "ApplicationUsersMovies",
                newName: "ApplicationUserMovie");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsersMovies_MovieId",
                table: "ApplicationUserMovie",
                newName: "IX_ApplicationUserMovie_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                defaultValue: "~/images/No_Image_Available.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true,
                oldDefaultValue: "~/images/NoImage.jpg");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserMovie",
                table: "ApplicationUserMovie",
                columns: new[] { "ApplicationUserId", "MovieId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMovie_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserMovie",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMovie_Movies_MovieId",
                table: "ApplicationUserMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
