using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantMenuSystem.Migrations
{
    public partial class aftercorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "adminMenuModels");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "adminMenuModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "adminMenuModels");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "adminMenuModels",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
