using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreatorInEntity.Migrations
{
    public partial class _2019_12_12_flyid_on_component : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Flys_FlyId",
                table: "Components");

            migrationBuilder.AlterColumn<int>(
                name: "FlyId",
                table: "Components",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Flys_FlyId",
                table: "Components",
                column: "FlyId",
                principalTable: "Flys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Flys_FlyId",
                table: "Components");

            migrationBuilder.AlterColumn<int>(
                name: "FlyId",
                table: "Components",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Flys_FlyId",
                table: "Components",
                column: "FlyId",
                principalTable: "Flys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
