using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreator.Migrations
{
    public partial class MaterialOnMaterialOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialOptions_Materials_MaterialId1",
                table: "MaterialOptions");

            migrationBuilder.DropIndex(
                name: "IX_MaterialOptions_MaterialId1",
                table: "MaterialOptions");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "MaterialOptions");

            migrationBuilder.DropColumn(
                name: "MaterialId1",
                table: "MaterialOptions");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentMaterialId",
                table: "MaterialOptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOptions_ParentMaterialId",
                table: "MaterialOptions",
                column: "ParentMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialOptions_Materials_ParentMaterialId",
                table: "MaterialOptions",
                column: "ParentMaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialOptions_Materials_ParentMaterialId",
                table: "MaterialOptions");

            migrationBuilder.DropIndex(
                name: "IX_MaterialOptions_ParentMaterialId",
                table: "MaterialOptions");

            migrationBuilder.DropColumn(
                name: "ParentMaterialId",
                table: "MaterialOptions");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "MaterialOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId1",
                table: "MaterialOptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOptions_MaterialId1",
                table: "MaterialOptions",
                column: "MaterialId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialOptions_Materials_MaterialId1",
                table: "MaterialOptions",
                column: "MaterialId1",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
