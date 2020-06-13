using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb_Angeles.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(maxLength: 60, nullable: false),
                    QuoteDate = table.Column<DateTime>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    Drawers = table.Column<int>(nullable: false),
                    Material = table.Column<string>(nullable: false),
                    Rush = table.Column<int>(nullable: false),
                    MaterialCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SurfaceAreaCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DrawerCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RushCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    QuoteTotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");
        }
    }
}
