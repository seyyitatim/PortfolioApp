using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApp.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rate",
                table: "Transactions",
                newName: "Rate");

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "Amount", "Code", "Name" },
                values: new object[] { 1, 100000m, "TRY", "Türk Lirası" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Transactions",
                newName: "rate");
        }
    }
}
