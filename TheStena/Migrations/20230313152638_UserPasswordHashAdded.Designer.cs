﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheStena.Models;

#nullable disable

namespace TheStena.Migrations
{
    [DbContext(typeof(StenaDBContext))]
    [Migration("20230313152638_UserPasswordHashAdded")]
    partial class UserPasswordHashAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TheStena.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Downvotes")
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Upvotes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TheStena.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Downvotes")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Upvotes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CreatedDate = new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(7054),
                            Downvotes = 2,
                            Title = "Dog's post 1",
                            Upvotes = 4
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            CreatedDate = new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(7056),
                            Downvotes = 7,
                            Title = "Dog's post 2",
                            Upvotes = 60
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            CreatedDate = new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(7057),
                            Downvotes = 30,
                            Title = "Cat's post 1",
                            Upvotes = 15
                        });
                });

            modelBuilder.Entity("TheStena.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(6939),
                            Name = "Dog",
                            PasswordHash = new byte[] { 124, 106, 24, 11, 54, 137, 106, 10, 140, 2, 120, 126, 234, 251, 14, 76 }
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 3, 13, 21, 26, 38, 20, DateTimeKind.Local).AddTicks(6955),
                            Name = "Cat",
                            PasswordHash = new byte[] { 108, 183, 95, 101, 42, 155, 82, 121, 142, 182, 207, 34, 1, 5, 124, 115 }
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pastor",
                            PasswordHash = new byte[] { 129, 155, 6, 67, 214, 184, 157, 201, 181, 121, 253, 252, 144, 148, 242, 142 }
                        });
                });

            modelBuilder.Entity("TheStena.Models.Comment", b =>
                {
                    b.HasOne("TheStena.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheStena.Models.Comment", null)
                        .WithMany("Comments")
                        .HasForeignKey("CommentId");

                    b.HasOne("TheStena.Models.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("TheStena.Models.Post", b =>
                {
                    b.HasOne("TheStena.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("TheStena.Models.Comment", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("TheStena.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
