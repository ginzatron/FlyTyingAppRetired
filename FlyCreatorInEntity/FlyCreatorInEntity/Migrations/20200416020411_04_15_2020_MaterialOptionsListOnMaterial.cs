using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class _04_15_2020_MaterialOptionsListOnMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Flys");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FlyClassifications");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Flys",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "FlyClassifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Flys");

            migrationBuilder.DropColumn(
                name: "Classification",
                table: "FlyClassifications");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Flys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FlyClassifications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
