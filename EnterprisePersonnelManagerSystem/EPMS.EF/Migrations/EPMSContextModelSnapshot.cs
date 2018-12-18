﻿// <auto-generated />
using System;
using EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EPMS.EF.Migrations
{
    [DbContext(typeof(EPMSContext))]
    partial class EPMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EPMS.Model.Model.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<DateTime>("AttendanceTime")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("OffworkTime")
                        .HasMaxLength(30);

                    b.Property<int?>("StaffInfoId");

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

            modelBuilder.Entity("EPMS.Model.Model.LoginInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdminId");

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

            modelBuilder.Entity("EPMS.Model.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<int?>("DepartmentId");

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("EPMS.Model.Model.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AttendanceRewardAndPunishment")
                        .HasMaxLength(20);

                    b.Property<double>("BasicSalary")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastUpTime")
                        .HasMaxLength(30);

                    b.Property<double>("MealSubsidy")
                        .HasMaxLength(20);

                    b.Property<double>("OtherSubsidies")
                        .HasMaxLength(20);

                    b.Property<int?>("StaffInfoId");

                    b.Property<double>("TransportationSubsidy")
                        .HasMaxLength(20);

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
                        .HasMaxLength(14);

                    b.Property<int?>("PositionId");

                    b.Property<DateTime?>("ResignationTime")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("StaffInfos");
                });

            modelBuilder.Entity("EPMS.Model.Model.Attendance", b =>
                {
                    b.HasOne("EPMS.Model.Model.StaffInfo", "StaffInfo")
                        .WithMany("Attendances")
                        .HasForeignKey("StaffInfoId");
                });

            modelBuilder.Entity("EPMS.Model.Model.LoginInfo", b =>
                {
                    b.HasOne("EPMS.Model.Model.Admin", "Admin")
                        .WithMany("LoginInfos")
                        .HasForeignKey("AdminId");
                });

            modelBuilder.Entity("EPMS.Model.Model.Position", b =>
                {
                    b.HasOne("EPMS.Model.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("EPMS.Model.Model.Salary", b =>
                {
                    b.HasOne("EPMS.Model.Model.StaffInfo", "StaffInfo")
                        .WithMany("Salarys")
                        .HasForeignKey("StaffInfoId");
                });

            modelBuilder.Entity("EPMS.Model.Model.StaffInfo", b =>
                {
                    b.HasOne("EPMS.Model.Model.Position", "Position")
                        .WithMany("StaffInfos")
                        .HasForeignKey("PositionId");
                });
#pragma warning restore 612, 618
        }
    }
}
