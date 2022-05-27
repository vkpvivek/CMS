using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    locId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.locId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    cusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cusAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cusGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cusAge = table.Column<int>(type: "int", nullable: false),
                    cusImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LocationlocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.cusId);
                    table.ForeignKey(
                        name: "FK_Customers_Locations_LocationlocId",
                        column: x => x.LocationlocId,
                        principalTable: "Locations",
                        principalColumn: "locId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocationlocId",
                table: "Customers",
                column: "LocationlocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
