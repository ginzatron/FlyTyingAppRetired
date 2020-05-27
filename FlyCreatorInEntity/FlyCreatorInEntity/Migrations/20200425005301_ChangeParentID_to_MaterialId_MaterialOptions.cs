using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class ChangeParentID_to_MaterialId_MaterialOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialOptions_Materials_MaterialId",
                table: "MaterialOptions");

            migrationBuilder.DropColumn(
                name: "ParentMaterialId",
                table: "MaterialOptions");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "MaterialOptions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialOptions_Materials_MaterialId",
                table: "MaterialOptions",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialOptions_Materials_MaterialId",
                table: "MaterialOptions");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "MaterialOptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ParentMaterialId",
                table: "MaterialOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialOptions_Materials_MaterialId",
                table: "MaterialOptions",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
