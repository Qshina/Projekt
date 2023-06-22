using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    id_artist = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    artist_name = table.Column<string>(type: "TEXT", nullable: false),
                    creation_year = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.id_artist);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    id_client = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    last_name = table.Column<string>(type: "TEXT", nullable: false),
                    regular_customer = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    id_genre = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    genre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.id_genre);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    id_album = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    album_name = table.Column<string>(type: "TEXT", nullable: false),
                    id_artist = table.Column<int>(type: "INTEGER", nullable: false),
                    Artistsid_artist = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.id_album);
                    table.ForeignKey(
                        name: "FK_Album_Artist_Artistsid_artist",
                        column: x => x.Artistsid_artist,
                        principalTable: "Artist",
                        principalColumn: "id_artist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    id_purchases = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_cd = table.Column<int>(type: "INTEGER", nullable: true),
                    id_client = table.Column<int>(type: "INTEGER", nullable: true),
                    date_of_purchase = table.Column<DateTime>(type: "TEXT", nullable: true),
                    price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Albumsid_album = table.Column<int>(type: "INTEGER", nullable: false),
                    Clientsid_client = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.id_purchases);
                    table.ForeignKey(
                        name: "FK_Purchase_Album_Albumsid_album",
                        column: x => x.Albumsid_album,
                        principalTable: "Album",
                        principalColumn: "id_album",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Client_Clientsid_client",
                        column: x => x.Clientsid_client,
                        principalTable: "Client",
                        principalColumn: "id_client",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    id_track = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    id_album = table.Column<int>(type: "INTEGER", nullable: true),
                    Albumsid_album = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.id_track);
                    table.ForeignKey(
                        name: "FK_Track_Album_Albumsid_album",
                        column: x => x.Albumsid_album,
                        principalTable: "Album",
                        principalColumn: "id_album",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenresTracks",
                columns: table => new
                {
                    Genresid_genre = table.Column<int>(type: "INTEGER", nullable: false),
                    Tracksid_track = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresTracks", x => new { x.Genresid_genre, x.Tracksid_track });
                    table.ForeignKey(
                        name: "FK_GenresTracks_Genre_Genresid_genre",
                        column: x => x.Genresid_genre,
                        principalTable: "Genre",
                        principalColumn: "id_genre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenresTracks_Track_Tracksid_track",
                        column: x => x.Tracksid_track,
                        principalTable: "Track",
                        principalColumn: "id_track",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_Artistsid_artist",
                table: "Album",
                column: "Artistsid_artist");

            migrationBuilder.CreateIndex(
                name: "IX_GenresTracks_Tracksid_track",
                table: "GenresTracks",
                column: "Tracksid_track");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Albumsid_album",
                table: "Purchase",
                column: "Albumsid_album");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Clientsid_client",
                table: "Purchase",
                column: "Clientsid_client");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Albumsid_album",
                table: "Track",
                column: "Albumsid_album");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenresTracks");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
