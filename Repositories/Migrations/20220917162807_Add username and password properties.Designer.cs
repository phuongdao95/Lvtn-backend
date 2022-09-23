﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models.Repositories.DataContext;

#nullable disable

namespace Models.Migrations
{
    [DbContext(typeof(EmsContext))]
    [Migration("20220917162807_Add username and password properties")]
    partial class Addusernameandpasswordproperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConstantFormula", b =>
                {
                    b.Property<int>("ConstantsId")
                        .HasColumnType("int");

                    b.Property<int>("FormulasId")
                        .HasColumnType("int");

                    b.HasKey("ConstantsId", "FormulasId");

                    b.HasIndex("FormulasId");

                    b.ToTable("ConstantFormula");
                });

            modelBuilder.Entity("DeductionAllowanceBonusUser", b =>
                {
                    b.Property<int>("DeductionAllowanceBonusesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("DeductionAllowanceBonusesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("DeductionAllowanceBonusUser");
                });

            modelBuilder.Entity("FormulaInput", b =>
                {
                    b.Property<int>("FormulasId")
                        .HasColumnType("int");

                    b.Property<int>("InputsId")
                        .HasColumnType("int");

                    b.HasKey("FormulasId", "InputsId");

                    b.HasIndex("InputsId");

                    b.ToTable("FormulaInput");
                });

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

            modelBuilder.Entity("Models.Models.Constant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Constant");
                });

            modelBuilder.Entity("Models.Models.DeductionAllowanceBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("DeductionAllowanceBonus");
                });

            modelBuilder.Entity("Models.Models.DeductionAllowanceBonusTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApplyType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FormulaId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormulaId");

                    b.ToTable("DeductionAllowanceBonusTemplate");
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

            modelBuilder.Entity("Models.Models.Formula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Define")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Formula");
                });

            modelBuilder.Entity("Models.Models.Input", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Input");
                });

            modelBuilder.Entity("Models.Models.Payslip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("BaseSalary")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Payslip");
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

                    b.Property<string>("Password")
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

                    b.Property<string>("Username")
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

            modelBuilder.Entity("ConstantFormula", b =>
                {
                    b.HasOne("Models.Models.Constant", null)
                        .WithMany()
                        .HasForeignKey("ConstantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Models.Formula", null)
                        .WithMany()
                        .HasForeignKey("FormulasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeductionAllowanceBonusUser", b =>
                {
                    b.HasOne("Models.Models.DeductionAllowanceBonus", null)
                        .WithMany()
                        .HasForeignKey("DeductionAllowanceBonusesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FormulaInput", b =>
                {
                    b.HasOne("Models.Models.Formula", null)
                        .WithMany()
                        .HasForeignKey("FormulasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Models.Input", null)
                        .WithMany()
                        .HasForeignKey("InputsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Models.DeductionAllowanceBonus", b =>
                {
                    b.HasOne("Models.Models.DeductionAllowanceBonusTemplate", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("Models.Models.DeductionAllowanceBonusTemplate", b =>
                {
                    b.HasOne("Models.Models.Formula", "Formula")
                        .WithMany("Templates")
                        .HasForeignKey("FormulaId");

                    b.Navigation("Formula");
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

            modelBuilder.Entity("Models.Models.Payslip", b =>
                {
                    b.HasOne("Models.Models.User", "Employee")
                        .WithMany("Payslips")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
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

            modelBuilder.Entity("Models.Models.Formula", b =>
                {
                    b.Navigation("Templates");
                });

            modelBuilder.Entity("Models.Models.Team", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Models.Models.User", b =>
                {
                    b.Navigation("DepartmentManage");

                    b.Navigation("Payslips");

                    b.Navigation("TeamManage");

                    b.Navigation("Workdays");
                });
#pragma warning restore 612, 618
        }
    }
}
