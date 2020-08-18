using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlyCreator.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    SubjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlyClassifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Classification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlyClassifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotes_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
                    ClassificationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flys_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flys_FlyClassifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "FlyClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MaterialCategoryId = table.Column<Guid>(nullable: true),
                    FlyClassificationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_FlyClassifications_FlyClassificationId",
                        column: x => x.FlyClassificationId,
                        principalTable: "FlyClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialCategories_MaterialCategoryId",
                        column: x => x.MaterialCategoryId,
                        principalTable: "MaterialCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    MaterialId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialOptions_Materials_MaterialId1",
                        column: x => x.MaterialId1,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    FlyId = table.Column<Guid>(nullable: false),
                    MaterialId = table.Column<Guid>(nullable: true),
                    MaterialOptionId = table.Column<Guid>(nullable: true),
                    SectionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_Flys_FlyId",
                        column: x => x.FlyId,
                        principalTable: "Flys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Components_MaterialOptions_MaterialOptionId",
                        column: x => x.MaterialOptionId,
                        principalTable: "MaterialOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Components_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_FlyId",
                table: "Components",
                column: "FlyId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_MaterialId",
                table: "Components",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_MaterialOptionId",
                table: "Components",
                column: "MaterialOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_SectionId",
                table: "Components",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Flys_AppUserId",
                table: "Flys",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flys_ClassificationId",
                table: "Flys",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOptions_MaterialId1",
                table: "MaterialOptions",
                column: "MaterialId1");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_FlyClassificationId",
                table: "Materials",
                column: "FlyClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialCategoryId",
                table: "Materials",
                column: "MaterialCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotes_AppUserId",
                table: "UserNotes",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "UserNotes");

            migrationBuilder.DropTable(
                name: "Flys");

            migrationBuilder.DropTable(
                name: "MaterialOptions");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "FlyClassifications");

            migrationBuilder.DropTable(
                name: "MaterialCategories");
        }
    }
}
