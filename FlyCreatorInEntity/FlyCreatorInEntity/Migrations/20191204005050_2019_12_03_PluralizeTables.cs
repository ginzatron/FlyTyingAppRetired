using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class _2019_12_03_PluralizeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Component_Fly_FlyId",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Material_MaterialId",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Section_SectionId",
                table: "Component");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Section",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fly",
                table: "Fly");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Component",
                table: "Component");

            migrationBuilder.RenameTable(
                name: "Section",
                newName: "Sections");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "Materials");

            migrationBuilder.RenameTable(
                name: "Fly",
                newName: "Flys");

            migrationBuilder.RenameTable(
                name: "Component",
                newName: "Components");

            migrationBuilder.RenameIndex(
                name: "IX_Component_SectionId",
                table: "Components",
                newName: "IX_Components_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Component_MaterialId",
                table: "Components",
                newName: "IX_Components_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Component_FlyId",
                table: "Components",
                newName: "IX_Components_FlyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flys",
                table: "Flys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Components",
                table: "Components",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Flys_FlyId",
                table: "Components",
                column: "FlyId",
                principalTable: "Flys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Materials_MaterialId",
                table: "Components",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Sections_SectionId",
                table: "Components",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Flys_FlyId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_Materials_MaterialId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_Sections_SectionId",
                table: "Components");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flys",
                table: "Flys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Components",
                table: "Components");

            migrationBuilder.RenameTable(
                name: "Sections",
                newName: "Section");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Material");

            migrationBuilder.RenameTable(
                name: "Flys",
                newName: "Fly");

            migrationBuilder.RenameTable(
                name: "Components",
                newName: "Component");

            migrationBuilder.RenameIndex(
                name: "IX_Components_SectionId",
                table: "Component",
                newName: "IX_Component_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Components_MaterialId",
                table: "Component",
                newName: "IX_Component_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Components_FlyId",
                table: "Component",
                newName: "IX_Component_FlyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section",
                table: "Section",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fly",
                table: "Fly",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Component",
                table: "Component",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Fly_FlyId",
                table: "Component",
                column: "FlyId",
                principalTable: "Fly",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Material_MaterialId",
                table: "Component",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Section_SectionId",
                table: "Component",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
