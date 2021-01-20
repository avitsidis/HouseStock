using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseStock.DataAccess.Migrations
{
    public partial class AddPharmacyProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4L, "Pharmacy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
