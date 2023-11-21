﻿// <auto-generated />
using CQRSWithMediatR.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CQRSWithMediatR.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231120221803_Seeding_Data_To_Department_Entity")]
    partial class Seeding_Data_To_Department_Entity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CQRSWithMediatR.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "FIN",
                            Name = "Finance"
                        },
                        new
                        {
                            Id = 2,
                            Code = "HR",
                            Name = "Human Resources"
                        },
                        new
                        {
                            Id = 3,
                            Code = "MKT",
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 4,
                            Code = "IT",
                            Name = "Information Technology"
                        },
                        new
                        {
                            Id = 5,
                            Code = "OPS",
                            Name = "Operations"
                        },
                        new
                        {
                            Id = 6,
                            Code = "SAL",
                            Name = "Sales"
                        },
                        new
                        {
                            Id = 7,
                            Code = "CS",
                            Name = "Customer Service"
                        },
                        new
                        {
                            Id = 8,
                            Code = "RD",
                            Name = "Research and Development"
                        },
                        new
                        {
                            Id = 9,
                            Code = "LEG",
                            Name = "Legal"
                        },
                        new
                        {
                            Id = 10,
                            Code = "SC",
                            Name = "Supply Chain"
                        },
                        new
                        {
                            Id = 11,
                            Code = "PR",
                            Name = "Public Relations"
                        },
                        new
                        {
                            Id = 12,
                            Code = "QA",
                            Name = "Quality Assurance"
                        },
                        new
                        {
                            Id = 13,
                            Code = "FM",
                            Name = "Facilities Management"
                        },
                        new
                        {
                            Id = 14,
                            Code = "HS",
                            Name = "Health and Safety"
                        },
                        new
                        {
                            Id = 15,
                            Code = "PM",
                            Name = "Product Management"
                        });
                });

            modelBuilder.Entity("CQRSWithMediatR.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CQRSWithMediatR.Models.EmployeeProject", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId", "EmployeeId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("CQRSWithMediatR.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("CQRSWithMediatR.Models.Employee", b =>
                {
                    b.HasOne("CQRSWithMediatR.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Department_Employees");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CQRSWithMediatR.Models.EmployeeProject", b =>
                {
                    b.HasOne("CQRSWithMediatR.Models.Employee", "Employee")
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CQRSWithMediatR.Models.Project", "Project")
                        .WithMany("Employees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("CQRSWithMediatR.Models.Project", b =>
                {
                    b.HasOne("CQRSWithMediatR.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Deparment_Projects");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CQRSWithMediatR.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("CQRSWithMediatR.Models.Employee", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("CQRSWithMediatR.Models.Project", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}