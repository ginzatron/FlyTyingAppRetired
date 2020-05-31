using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreator.Migrations
{
    public partial class SubjectIdAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "AspNetUsers");
        }
    }
}
