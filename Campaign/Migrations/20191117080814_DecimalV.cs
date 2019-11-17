using Microsoft.EntityFrameworkCore.Migrations;

namespace Campaign.Migrations
{
    public partial class DecimalV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    Fund = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Bid = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Town = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Radius = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Rzeszów" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Kraków" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Warszawa" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Katowice" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Gdańsk" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Lublin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
