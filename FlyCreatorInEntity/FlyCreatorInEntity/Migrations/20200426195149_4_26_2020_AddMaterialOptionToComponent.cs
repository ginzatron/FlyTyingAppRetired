using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class _4_26_2020_AddMaterialOptionToComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialOptionId",
                table: "Components",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Components_MaterialOptionId",
                table: "Components",
                column: "MaterialOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_MaterialOptions_MaterialOptionId",
                table: "Components",
                column: "MaterialOptionId",
                principalTable: "MaterialOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_MaterialOptions_MaterialOptionId",
                table: "Components");

            migrationBuilder.DropIndex(
                name: "IX_Components_MaterialOptionId",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "MaterialOptionId",
                table: "Components");
        }
    }
}
