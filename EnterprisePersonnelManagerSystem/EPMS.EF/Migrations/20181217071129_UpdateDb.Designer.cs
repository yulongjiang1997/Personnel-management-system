﻿// <auto-generated />
using System;
using EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EPMS.EF.Migrations
{
    [DbContext(typeof(EPMSContext))]
    [Migration("20181217071129_UpdateDb")]
    partial class UpdateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Email");

                    b.Property<DateTime?>("LastUpTime");

                    b.Property<string>("Name");

                    b.Property<string>("PassWord");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EPMS.Model.Model.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AttendanceTime");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime?>("LastUpTime");

                    b.Property<DateTime?>("OffworkTime");

                    b.Property<int?>("StaffInfoId");

                    b.Property<DateTime>("WorkingTime");

                    b.HasKey("Id");

                    b.HasIndex("StaffInfoId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EPMS.Model.Model.AttendanceTimeSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime?>("LastUpTime");

                    b.Property<DateTime>("OffworkTime");

                    b.Property<DateTime>("WorkingTime");

                    b.HasKey("Id");

                    b.ToTable("AttendanceTimeSets");
                });

            modelBuilder.Entity("EPMS.Model.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime?>("LastUpTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EPMS.Model.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime");

                    b.Property<int?>("DepartmentId");

                    b.Property<DateTime?>("LastUpTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("EPMS.Model.Model.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AttendanceRewardAndPunishment");

                    b.Property<double>("BasicSalary");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime?>("LastUpTime");

                    b.Property<double>("MealSubsidy");

                    b.Property<double>("OtherSubsidies");

                    b.Property<int?>("StaffIdId");

                    b.Property<double>("TransportationSubsidy");

                    b.HasKey("Id");

                    b.HasIndex("StaffIdId");

                    b.ToTable("Salarys");
                });

            modelBuilder.Entity("EPMS.Model.Model.StaffInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Email");

                    b.Property<DateTime>("EntryTime");

                    b.Property<DateTime?>("LastUpTime");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int?>("PositionId");

                    b.Property<DateTime?>("ResignationTime");

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

            modelBuilder.Entity("EPMS.Model.Model.Position", b =>
                {
                    b.HasOne("EPMS.Model.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("EPMS.Model.Model.Salary", b =>
                {
                    b.HasOne("EPMS.Model.Model.StaffInfo", "StaffId")
                        .WithMany("Salarys")
                        .HasForeignKey("StaffIdId");
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
