﻿// <auto-generated />
using System;
using EPMSEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EPMS.EF.Migrations
{
    [DbContext(typeof(EPMSContext))]
    [Migration("20190304103046_initDb")]
    partial class initDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EPMS.Model.Model.Admin", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<string>("Email")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("PassWord")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EPMS.Model.Model.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<bool>("IsLate");

                    b.Property<bool>("IsLeaveEarly");

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("OffworkTime")
                        .HasMaxLength(30);

                    b.Property<int>("StaffInfoId");

                    b.Property<DateTime>("WorkingTime")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("StaffInfoId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EPMS.Model.Model.AttendanceTimeSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<DateTime>("OffworkTime")
                        .HasMaxLength(30);

                    b.Property<DateTime>("WorkingTime")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("AttendanceTimeSets");
                });

            modelBuilder.Entity("EPMS.Model.Model.CompanySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<string>("EventDetails");

                    b.Property<string>("EventName");

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<DateTime>("ScheduleTime");

                    b.HasKey("Id");

                    b.ToTable("CompanySchedules");
                });

            modelBuilder.Entity("EPMS.Model.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EPMS.Model.Model.InAndOutStockDetailed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<int>("InAndOutStockType");

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<int>("Number");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("InAndOutStockDetaileds");
                });

            modelBuilder.Entity("EPMS.Model.Model.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminId");

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<string>("OperationData");

                    b.Property<string>("OperationEvent");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("EPMS.Model.Model.LoginInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminId");

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<DateTime>("OutTime");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("LoginInfos");
                });

            modelBuilder.Entity("EPMS.Model.Model.PersonalSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<string>("EventDetails");

                    b.Property<string>("EventName");

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<DateTime>("ScheduleTime");

                    b.Property<int>("StaffId");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("PersonalSchedules");
                });

            modelBuilder.Entity("EPMS.Model.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<int>("DepartmentId");

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("EPMS.Model.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<string>("Number");

                    b.Property<double>("Price")
                        .HasMaxLength(7);

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EPMS.Model.Model.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BasicSalary")
                        .HasMaxLength(7);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<double>("Deduction")
                        .HasMaxLength(7);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<double>("MealSubsidy")
                        .HasMaxLength(7);

                    b.Property<double>("OtherSubsidies")
                        .HasMaxLength(7);

                    b.Property<double>("Reward")
                        .HasMaxLength(7);

                    b.Property<int>("StaffInfoId");

                    b.Property<double>("TransportationSubsidy")
                        .HasMaxLength(7);

                    b.HasKey("Id");

                    b.HasIndex("StaffInfoId");

                    b.ToTable("Salarys");
                });

            modelBuilder.Entity("EPMS.Model.Model.StaffInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<DateTime>("EntryTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(11);

                    b.Property<int>("PositionId");

                    b.Property<DateTime?>("ResignationTime")
                        .HasMaxLength(30);

                    b.Property<int>("WorkingStatus");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("StaffInfos");
                });

            modelBuilder.Entity("EPMS.Model.Model.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<int>("PrductId");

                    b.Property<int>("SurplusStock");

                    b.HasKey("Id");

                    b.HasIndex("PrductId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("EPMS.Model.Model.Attendance", b =>
                {
                    b.HasOne("EPMS.Model.Model.StaffInfo", "StaffInfo")
                        .WithMany()
                        .HasForeignKey("StaffInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EPMS.Model.Model.InAndOutStockDetailed", b =>
                {
                    b.HasOne("EPMS.Model.Model.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EPMS.Model.Model.Log", b =>
                {
                    b.HasOne("EPMS.Model.Model.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");
                });

            modelBuilder.Entity("EPMS.Model.Model.LoginInfo", b =>
                {
                    b.HasOne("EPMS.Model.Model.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");
                });

            modelBuilder.Entity("EPMS.Model.Model.PersonalSchedule", b =>
                {
                    b.HasOne("EPMS.Model.Model.StaffInfo", "StaffInfo")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EPMS.Model.Model.Position", b =>
                {
                    b.HasOne("EPMS.Model.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EPMS.Model.Model.Salary", b =>
                {
                    b.HasOne("EPMS.Model.Model.StaffInfo", "StaffInfo")
                        .WithMany()
                        .HasForeignKey("StaffInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EPMS.Model.Model.StaffInfo", b =>
                {
                    b.HasOne("EPMS.Model.Model.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EPMS.Model.Model.Stock", b =>
                {
                    b.HasOne("EPMS.Model.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("PrductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
