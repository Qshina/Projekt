using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    artist_name = table.Column<string>(type: "TEXT", nullable: false),
                    First_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Last_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.artist_name);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    genre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.genre);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    album_name = table.Column<string>(type: "TEXT", nullable: false),
                    release_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    artist_NAME = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.album_name);
                    table.ForeignKey(
                        name: "FK_Album_Artist_artist_NAME",
                        column: x => x.artist_NAME,
                        principalTable: "Artist",
                        principalColumn: "artist_name");
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    id_track = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    creation_year = table.Column<DateTime>(type: "TEXT", nullable: false),
                    album_NAME = table.Column<string>(type: "TEXT", nullable: true),
                    genre_NAME = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.id_track);
                    table.ForeignKey(
                        name: "FK_Track_Album_album_NAME",
                        column: x => x.album_NAME,
                        principalTable: "Album",
                        principalColumn: "album_name");
                    table.ForeignKey(
                        name: "FK_Track_Genre_genre_NAME",
                        column: x => x.genre_NAME,
                        principalTable: "Genre",
                        principalColumn: "genre");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_artist_NAME",
                table: "Album",
                column: "artist_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_Track_album_NAME",
                table: "Track",
                column: "album_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_Track_genre_NAME",
                table: "Track",
                column: "genre_NAME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
