using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFApplication.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attractions_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "General" },
                    { 2, "Fantasy" },
                    { 3, "Horror" },
                    { 4, "Sci/Fi" },
                    { 5, "Western" }
                });

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "ID", "LocationID", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Twirly Ride" },
                    { 2, 5, "Mine car Coaster" },
                    { 3, 3, "Haunted House" },
                    { 4, 2, "Dragon Ride" },
                    { 5, 1, "Gift Shop" },
                    { 6, 4, "Space Ride" },
                    { 7, 5, "Shootout at OK Corral/Lazer Tag" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_LocationID",
                table: "Attractions",
                column: "LocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
