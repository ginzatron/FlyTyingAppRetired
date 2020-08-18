﻿// <auto-generated />
using System;
using FlyCreator.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlyCreator.Migrations
{
    [DbContext(typeof(FlyDbContext))]
    partial class FlyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlyCreator.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("FlyCreator.Models.Component", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FlyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MaterialOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SectionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FlyId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("MaterialOptionId");

                    b.HasIndex("SectionId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("FlyCreator.Models.Fly", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("ClassificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ClassificationId");

                    b.ToTable("Flys");
                });

            modelBuilder.Entity("FlyCreator.Models.FlyClassification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Classification")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FlyClassifications");
                });

            modelBuilder.Entity("FlyCreator.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlyClassificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MaterialCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FlyClassificationId");

                    b.HasIndex("MaterialCategoryId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("FlyCreator.Models.MaterialCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaterialCategories");
                });

            modelBuilder.Entity("FlyCreator.Models.MaterialOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentMaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentMaterialId");

                    b.ToTable("MaterialOptions");
                });

            modelBuilder.Entity("FlyCreator.Models.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("FlyCreator.Models.UserNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("UserNotes");
                });

            modelBuilder.Entity("FlyCreator.Models.Component", b =>
                {
                    b.HasOne("FlyCreator.Models.Fly", "Fly")
                        .WithMany("Components")
                        .HasForeignKey("FlyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlyCreator.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("FlyCreator.Models.MaterialOption", "MaterialOption")
                        .WithMany()
                        .HasForeignKey("MaterialOptionId");

                    b.HasOne("FlyCreator.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("FlyCreator.Models.Fly", b =>
                {
                    b.HasOne("FlyCreator.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("FlyCreator.Models.FlyClassification", "Classification")
                        .WithMany()
                        .HasForeignKey("ClassificationId");
                });

            modelBuilder.Entity("FlyCreator.Models.Material", b =>
                {
                    b.HasOne("FlyCreator.Models.FlyClassification", "FlyClassification")
                        .WithMany()
                        .HasForeignKey("FlyClassificationId");

                    b.HasOne("FlyCreator.Models.MaterialCategory", "MaterialCategory")
                        .WithMany()
                        .HasForeignKey("MaterialCategoryId");
                });

            modelBuilder.Entity("FlyCreator.Models.MaterialOption", b =>
                {
                    b.HasOne("FlyCreator.Models.Material", "ParentMaterial")
                        .WithMany("MaterialOptions")
                        .HasForeignKey("ParentMaterialId");
                });

            modelBuilder.Entity("FlyCreator.Models.UserNote", b =>
                {
                    b.HasOne("FlyCreator.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
