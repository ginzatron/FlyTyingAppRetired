using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class _04_07_2020_DB_Table_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialCategory_CategoryId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Classifications_ClassificationId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_CategoryId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_ClassificationId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "FlyClassificationId",
                table: "Materials",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialCategoryId",
                table: "Materials",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_FlyClassificationId",
                table: "Materials",
                column: "FlyClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialCategoryId",
                table: "Materials",
                column: "MaterialCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Classifications_FlyClassificationId",
                table: "Materials",
                column: "FlyClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialCategory_MaterialCategoryId",
                table: "Materials",
                column: "MaterialCategoryId",
                principalTable: "MaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Classifications_FlyClassificationId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialCategory_MaterialCategoryId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_FlyClassificationId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_MaterialCategoryId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "FlyClassificationId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MaterialCategoryId",
                table: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CategoryId",
                table: "Materials",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ClassificationId",
                table: "Materials",
                column: "ClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialCategory_CategoryId",
                table: "Materials",
                column: "CategoryId",
                principalTable: "MaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Classifications_ClassificationId",
                table: "Materials",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
