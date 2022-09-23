﻿// <auto-generated />
using System;
using Models.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Models.Migrations
{
    [DbContext(typeof(EmsContext))]
    [Migration("20220813144138_UpdateNullableProperties")]
    partial class UpdateNullableProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("lvtn_backend.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentDepartmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique()
                        .HasFilter("[ManagerId] IS NOT NULL");

                    b.HasIndex("ParentDepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("lvtn_backend.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("LeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("LeaderId")
                        .IsUnique()
                        .HasFilter("[LeaderId] IS NOT NULL");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("lvtn_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("lvtn_backend.Models.Department", b =>
                {
                    b.HasOne("lvtn_backend.Models.User", "Manager")
                        .WithOne("Department")
                        .HasForeignKey("lvtn_backend.Models.Department", "ManagerId");

                    b.HasOne("lvtn_backend.Models.Department", "ParentDepartment")
                        .WithMany("Departments")
                        .HasForeignKey("ParentDepartmentId");

                    b.Navigation("Manager");

                    b.Navigation("ParentDepartment");
                });

            modelBuilder.Entity("lvtn_backend.Models.Team", b =>
                {
                    b.HasOne("lvtn_backend.Models.Department", "Department")
                        .WithMany("Teams")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("lvtn_backend.Models.User", "Leader")
                        .WithOne("Team")
                        .HasForeignKey("lvtn_backend.Models.Team", "LeaderId");

                    b.Navigation("Department");

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("lvtn_backend.Models.User", b =>
                {
                    b.HasOne("lvtn_backend.Models.Team", null)
                        .WithMany("Members")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("lvtn_backend.Models.Department", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("lvtn_backend.Models.Team", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("lvtn_backend.Models.User", b =>
                {
                    b.Navigation("Department");

                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
