using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jasleen.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    Release_Date = table.Column<string>(type: "TEXT", nullable: true),
                    Singer = table.Column<string>(type: "TEXT", nullable: true),
                    Production_Company = table.Column<double>(type: "REAL", nullable: false),
                    Lyrics = table.Column<int>(type: "INTEGER", nullable: false),
                    Director = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");
        }
    }
}
