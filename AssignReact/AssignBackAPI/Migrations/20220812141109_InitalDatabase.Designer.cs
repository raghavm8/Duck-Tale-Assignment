﻿// <auto-generated />
using Assignment.DBHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AssignBackAPI.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20220812141109_InitalDatabase")]
    partial class InitalDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("Assignment.Models.EmployeeModel", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("EmpId"));

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EmpSalary")
                        .HasColumnType("integer");

                    b.Property<int>("ManagerId")
                        .HasColumnType("integer");

                    b.HasKey("EmpId");

                    b.ToTable("employees");
                });
#pragma warning restore 612, 618
        }
    }
}
