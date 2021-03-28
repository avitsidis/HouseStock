using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HouseStock.DataAccess.Migrations
{
    public partial class ConsumedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ConsumedAt",
                table: "ProductInstances",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumedAt",
                table: "ProductInstances");
        }
    }
}
