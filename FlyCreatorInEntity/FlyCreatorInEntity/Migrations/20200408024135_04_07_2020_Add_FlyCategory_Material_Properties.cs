using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class _04_07_2020_Add_FlyCategory_Material_Properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Classifications_classificationId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "classificationId",
                table: "Materials",
                newName: "ClassificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_classificationId",
                table: "Materials",
                newName: "IX_Materials_ClassificationId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Materials",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaterialCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CategoryId",
                table: "Materials",
                column: "CategoryId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialCategory_CategoryId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Classifications_ClassificationId",
                table: "Materials");

            migrationBuilder.DropTable(
                name: "MaterialCategory");

            migrationBuilder.DropIndex(
                name: "IX_Materials_CategoryId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "ClassificationId",
                table: "Materials",
                newName: "classificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_ClassificationId",
                table: "Materials",
                newName: "IX_Materials_classificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Classifications_classificationId",
                table: "Materials",
                column: "classificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
