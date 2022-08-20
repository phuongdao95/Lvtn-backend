﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lvtn_backend.Repositories.DataContext;

#nullable disable

namespace lvtn_backend.Migrations
{
    [DbContext(typeof(EmsContext))]
    [Migration("20220819192606_Add_BankInfo_And_Workday_Tables")]
    partial class Add_BankInfo_And_Workday_Tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Models.BankInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankInfo");
                });

            modelBuilder.Entity("Models.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Models.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Models.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BankInfoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CitizenId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<string>("SocialInsuranceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TokenSlack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TokenTrello")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankInfoId")
                        .IsUnique()
                        .HasFilter("[BankInfoId] IS NOT NULL");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Models.Workday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CheckAt")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Workday");
                });

            modelBuilder.Entity("Models.Models.Department", b =>
                {
                    b.HasOne("Models.Models.User", "Manager")
                        .WithOne("DepartmentManage")
                        .HasForeignKey("Models.Models.Department", "ManagerId");

                    b.HasOne("Models.Models.Department", "ParentDepartment")
                        .WithMany("Departments")
                        .HasForeignKey("ParentDepartmentId");

                    b.Navigation("Manager");

                    b.Navigation("ParentDepartment");
                });

            modelBuilder.Entity("Models.Models.Team", b =>
                {
                    b.HasOne("Models.Models.Department", "Department")
                        .WithMany("Teams")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Models.Models.User", "Leader")
                        .WithOne("TeamManage")
                        .HasForeignKey("Models.Models.Team", "LeaderId");

                    b.Navigation("Department");

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("Models.Models.User", b =>
                {
                    b.HasOne("Models.Models.BankInfo", "BankInfo")
                        .WithOne()
                        .HasForeignKey("Models.Models.User", "BankInfoId");

                    b.HasOne("Models.Models.Team", "TeamBelong")
                        .WithMany("Members")
                        .HasForeignKey("TeamId");

                    b.Navigation("BankInfo");

                    b.Navigation("TeamBelong");
                });

            modelBuilder.Entity("Models.Models.Workday", b =>
                {
                    b.HasOne("Models.Models.User", null)
                        .WithMany("Workdays")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Models.Models.Department", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Models.Models.Team", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Models.Models.User", b =>
                {
                    b.Navigation("DepartmentManage");

                    b.Navigation("TeamManage");

                    b.Navigation("Workdays");
                });
#pragma warning restore 612, 618
        }
    }
}
