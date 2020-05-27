using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class updateMaterialOptins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialOptions_Materials_ParentMaterialId",
                table: "MaterialOptions");

            migrationBuilder.DropIndex(
                name: "IX_MaterialOptions_ParentMaterialId",
                table: "MaterialOptions");

            migrationBuilder.AlterColumn<int>(
                name: "ParentMaterialId",
                table: "MaterialOptions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "MaterialOptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOptions_MaterialId",
                table: "MaterialOptions",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialOptions_Materials_MaterialId",
                table: "MaterialOptions",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialOptions_Materials_MaterialId",
                table: "MaterialOptions");

            migrationBuilder.DropIndex(
                name: "IX_MaterialOptions_MaterialId",
                table: "MaterialOptions");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "MaterialOptions");

            migrationBuilder.AlterColumn<int>(
                name: "ParentMaterialId",
                table: "MaterialOptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
