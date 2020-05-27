using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class _2020_4_4_classficationPropertyOnMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "classificationId",
                table: "Materials",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_classificationId",
                table: "Materials",
                column: "classificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Classifications_classificationId",
                table: "Materials",
                column: "classificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Classifications_classificationId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_classificationId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "classificationId",
                table: "Materials");
        }
    }
}
