﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.DBOperations;

#nullable disable

namespace PP_BC_C_H_3_1.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20250507120014_Book")]
    partial class Book
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            PageCount = 10,
                            PublishDate = new DateTime(2025, 2, 7, 15, 0, 14, 639, DateTimeKind.Local).AddTicks(457),
                            Title = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 2,
                            PageCount = 20,
                            PublishDate = new DateTime(2022, 5, 7, 15, 0, 14, 639, DateTimeKind.Local).AddTicks(470),
                            Title = "Non-Fiction"
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 3,
                            PageCount = 30,
                            PublishDate = new DateTime(2025, 4, 16, 15, 0, 14, 639, DateTimeKind.Local).AddTicks(472),
                            Title = "Science Fiction"
                        });
                });

            modelBuilder.Entity("WebApi.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Science Fiction"
                        });
                });

            modelBuilder.Entity("WebApi.Models.Book", b =>
                {
                    b.HasOne("WebApi.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
