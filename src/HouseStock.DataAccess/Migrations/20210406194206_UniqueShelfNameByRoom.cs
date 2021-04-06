using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseStock.DataAccess.Migrations
{
    public partial class UniqueShelfNameByRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shelves_Name",
                table: "Shelves");

            //migrationBuilder.DropIndex(
            //    name: "IX_Shelves_RoomId",
            //    table: "Shelves");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_RoomId_Name",
                table: "Shelves",
                columns: new[] { "RoomId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shelves_RoomId_Name",
                table: "Shelves");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_Name",
                table: "Shelves",
                column: "Name",
                unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Shelves_RoomId",
            //    table: "Shelves",
            //    column: "RoomId");
        }
    }
}
