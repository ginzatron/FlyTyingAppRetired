using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class _2019_12_12_ModelSimplification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_MaterialBases_MaterialId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_MaterialBases_MaterialId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_MaterialId",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialBases",
                table: "MaterialBases");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "MaterialBases");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MaterialBases");

            migrationBuilder.RenameTable(
                name: "MaterialBases",
                newName: "Materials");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Components",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Materials_MaterialId",
                table: "Components",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Materials_MaterialId",
                table: "Components");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Components");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "MaterialBases");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Sections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "MaterialBases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MaterialBases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialBases",
                table: "MaterialBases",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_MaterialId",
                table: "Sections",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_MaterialBases_MaterialId",
                table: "Components",
                column: "MaterialId",
                principalTable: "MaterialBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_MaterialBases_MaterialId",
                table: "Sections",
                column: "MaterialId",
                principalTable: "MaterialBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
