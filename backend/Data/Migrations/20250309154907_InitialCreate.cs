using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    Kundnummer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunder", x => x.Kundnummer);
                });

            migrationBuilder.CreateTable(
                name: "Tjanster",
                columns: table => new
                {
                    TjanstId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrisPerTimme = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tjanster", x => x.TjanstId);
                });

            migrationBuilder.CreateTable(
                name: "Projekt",
                columns: table => new
                {
                    Projektnummer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slutdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Projektansvarig = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kundnummer = table.Column<int>(type: "int", nullable: false),
                    TjanstId = table.Column<int>(type: "int", nullable: false),
                    Totalpris = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekt", x => x.Projektnummer);
                    table.ForeignKey(
                        name: "FK_Projekt_Kunder_Kundnummer",
                        column: x => x.Kundnummer,
                        principalTable: "Kunder",
                        principalColumn: "Kundnummer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projekt_Tjanster_TjanstId",
                        column: x => x.TjanstId,
                        principalTable: "Tjanster",
                        principalColumn: "TjanstId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projekt_Kundnummer",
                table: "Projekt",
                column: "Kundnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Projekt_TjanstId",
                table: "Projekt",
                column: "TjanstId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projekt");

            migrationBuilder.DropTable(
                name: "Kunder");

            migrationBuilder.DropTable(
                name: "Tjanster");
        }
    }
}
