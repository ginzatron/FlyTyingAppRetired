using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class update_DB_Naming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flys_Classifications_ClassificationId",
                table: "Flys");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Classifications_FlyClassificationId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialCategory_MaterialCategoryId",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialCategory",
                table: "MaterialCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classifications",
                table: "Classifications");

            migrationBuilder.RenameTable(
                name: "MaterialCategory",
                newName: "MaterialCategories");

            migrationBuilder.RenameTable(
                name: "Classifications",
                newName: "FlyClassifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialCategories",
                table: "MaterialCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlyClassifications",
                table: "FlyClassifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flys_FlyClassifications_ClassificationId",
                table: "Flys",
                column: "ClassificationId",
                principalTable: "FlyClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_FlyClassifications_FlyClassificationId",
                table: "Materials",
                column: "FlyClassificationId",
                principalTable: "FlyClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialCategories_MaterialCategoryId",
                table: "Materials",
                column: "MaterialCategoryId",
                principalTable: "MaterialCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flys_FlyClassifications_ClassificationId",
                table: "Flys");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_FlyClassifications_FlyClassificationId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialCategories_MaterialCategoryId",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialCategories",
                table: "MaterialCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlyClassifications",
                table: "FlyClassifications");

            migrationBuilder.RenameTable(
                name: "MaterialCategories",
                newName: "MaterialCategory");

            migrationBuilder.RenameTable(
                name: "FlyClassifications",
                newName: "Classifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialCategory",
                table: "MaterialCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classifications",
                table: "Classifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flys_Classifications_ClassificationId",
                table: "Flys",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
