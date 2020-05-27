using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class _2019_12_11_updatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Materials_MaterialId",
                table: "Components");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Flys");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "MaterialBases");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "Flys",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "MaterialBases",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MaterialBases",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialBases",
                table: "MaterialBases",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_MaterialId",
                table: "Sections",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Flys_ClassificationId",
                table: "Flys",
                column: "ClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_MaterialBases_MaterialId",
                table: "Components",
                column: "MaterialId",
                principalTable: "MaterialBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flys_Classifications_ClassificationId",
                table: "Flys",
                column: "ClassificationId",
                principalTable: "Classifications",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_MaterialBases_MaterialId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Flys_Classifications_ClassificationId",
                table: "Flys");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_MaterialBases_MaterialId",
                table: "Sections");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropIndex(
                name: "IX_Sections_MaterialId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Flys_ClassificationId",
                table: "Flys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialBases",
                table: "MaterialBases");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "Flys");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "MaterialBases");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MaterialBases");

            migrationBuilder.RenameTable(
                name: "MaterialBases",
                newName: "Materials");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Flys",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
