using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kunder",
                columns: new[] { "Kundnummer", "Namn", "Telefonnummer" },
                values: new object[] { 1, "Kund Kundsson", "0123456789" });

            migrationBuilder.InsertData(
                table: "Tjanster",
                columns: new[] { "TjanstId", "Namn", "PrisPerTimme" },
                values: new object[] { 1, "Tjänst", 1000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "Kundnummer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tjanster",
                keyColumn: "TjanstId",
                keyValue: 1);
        }
    }
}
