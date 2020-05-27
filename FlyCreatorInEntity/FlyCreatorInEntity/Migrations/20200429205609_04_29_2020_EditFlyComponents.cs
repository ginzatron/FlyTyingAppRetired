using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class _04_29_2020_EditFlyComponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Materials_MaterialId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_MaterialOptions_MaterialOptionId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_Sections_SectionId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Flys_FlyClassifications_ClassificationId",
                table: "Flys");

            migrationBuilder.AlterColumn<int>(
                name: "ClassificationId",
                table: "Flys",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEdited",
                table: "Flys",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Components",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialOptionId",
                table: "Components",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "Components",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEdited",
                table: "Components",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Materials_MaterialId",
                table: "Components",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_MaterialOptions_MaterialOptionId",
                table: "Components",
                column: "MaterialOptionId",
                principalTable: "MaterialOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Sections_SectionId",
                table: "Components",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flys_FlyClassifications_ClassificationId",
                table: "Flys",
                column: "ClassificationId",
                principalTable: "FlyClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Materials_MaterialId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_MaterialOptions_MaterialOptionId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_Sections_SectionId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Flys_FlyClassifications_ClassificationId",
                table: "Flys");

            migrationBuilder.DropColumn(
                name: "LastEdited",
                table: "Flys");

            migrationBuilder.DropColumn(
                name: "LastEdited",
                table: "Components");

            migrationBuilder.AlterColumn<int>(
                name: "ClassificationId",
                table: "Flys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Components",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MaterialOptionId",
                table: "Components",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "Components",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Materials_MaterialId",
                table: "Components",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_MaterialOptions_MaterialOptionId",
                table: "Components",
                column: "MaterialOptionId",
                principalTable: "MaterialOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Sections_SectionId",
                table: "Components",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flys_FlyClassifications_ClassificationId",
                table: "Flys",
                column: "ClassificationId",
                principalTable: "FlyClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
