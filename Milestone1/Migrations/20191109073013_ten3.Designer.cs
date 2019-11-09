﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Milestone1.Data;

namespace Milestone1.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20191109073013_ten3")]
    partial class ten3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("Milestone1.Models.Address", b =>
                {
                    b.Property<int>("EmployeeID");

                    b.Property<string>("AddressLine1")
                        .IsRequired();

                    b.Property<string>("AddressLine2")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Pincode")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.HasKey("EmployeeID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Milestone1.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Milestone1.Models.AuthorToBook", b =>
                {
                    b.Property<int>("AuthorToBookID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorID");

                    b.Property<int>("BookID");

                    b.HasKey("AuthorToBookID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("BookID");

                    b.ToTable("AuthorsToBooks");
                });

            modelBuilder.Entity("Milestone1.Models.Blog", b =>
                {
                    b.Property<int>("blogID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(250);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(150);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(100);

                    b.Property<int>("userID");

                    b.HasKey("blogID");

                    b.HasIndex("userID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Milestone1.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Milestone1.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MobileNo")
                        .IsRequired();

                    b.Property<int>("salary");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Milestone1.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EmpCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(50);

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Milestone1.Models.Address", b =>
                {
                    b.HasOne("Milestone1.Models.Employee", "Employee")
                        .WithOne("Address")
                        .HasForeignKey("Milestone1.Models.Address", "EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Milestone1.Models.AuthorToBook", b =>
                {
                    b.HasOne("Milestone1.Models.Author", "Author")
                        .WithMany("AuthorToBooks")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Milestone1.Models.Book", "Book")
                        .WithMany("AuthorToBooks")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Milestone1.Models.Blog", b =>
                {
                    b.HasOne("Milestone1.Models.User", "User")
                        .WithMany("Blogs")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}