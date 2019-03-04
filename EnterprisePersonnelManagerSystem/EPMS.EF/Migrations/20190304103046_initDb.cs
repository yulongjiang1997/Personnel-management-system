using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPMS.EF.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    Account = table.Column<string>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    PassWord = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceTimeSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    WorkingTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    OffworkTime = table.Column<DateTime>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceTimeSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanySchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    EventDetails = table.Column<string>(nullable: true),
                    ScheduleTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Price = table.Column<double>(maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    AdminId = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    OutTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginInfos_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    AdminId = table.Column<string>(nullable: true),
                    OperationEvent = table.Column<string>(nullable: true),
                    OperationData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    PrductId = table.Column<int>(nullable: false),
                    SurplusStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_PrductId",
                        column: x => x.PrductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 11, nullable: true),
                    EntryTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    ResignationTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    PositionId = table.Column<int>(nullable: false),
                    WorkingStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffInfos_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InAndOutStockDetaileds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    StockId = table.Column<int>(nullable: false),
                    InAndOutStockType = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InAndOutStockDetaileds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InAndOutStockDetaileds_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    WorkingTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    IsLate = table.Column<bool>(nullable: false),
                    IsLeaveEarly = table.Column<bool>(nullable: false),
                    OffworkTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    StaffInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_StaffInfos_StaffInfoId",
                        column: x => x.StaffInfoId,
                        principalTable: "StaffInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    StaffId = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(nullable: true),
                    EventDetails = table.Column<string>(nullable: true),
                    ScheduleTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalSchedules_StaffInfos_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salarys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: true),
                    BasicSalary = table.Column<double>(maxLength: 7, nullable: false),
                    TransportationSubsidy = table.Column<double>(maxLength: 7, nullable: false),
                    MealSubsidy = table.Column<double>(maxLength: 7, nullable: false),
                    OtherSubsidies = table.Column<double>(maxLength: 7, nullable: false),
                    Reward = table.Column<double>(maxLength: 7, nullable: false),
                    Deduction = table.Column<double>(maxLength: 7, nullable: false),
                    StaffInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salarys_StaffInfos_StaffInfoId",
                        column: x => x.StaffInfoId,
                        principalTable: "StaffInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StaffInfoId",
                table: "Attendances",
                column: "StaffInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_InAndOutStockDetaileds_StockId",
                table: "InAndOutStockDetaileds",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginInfos_AdminId",
                table: "LoginInfos",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_AdminId",
                table: "Logs",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalSchedules_StaffId",
                table: "PersonalSchedules",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_StaffInfoId",
                table: "Salarys",
                column: "StaffInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffInfos_PositionId",
                table: "StaffInfos",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_PrductId",
                table: "Stocks",
                column: "PrductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "AttendanceTimeSets");

            migrationBuilder.DropTable(
                name: "CompanySchedules");

            migrationBuilder.DropTable(
                name: "InAndOutStockDetaileds");

            migrationBuilder.DropTable(
                name: "LoginInfos");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "PersonalSchedules");

            migrationBuilder.DropTable(
                name: "Salarys");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "StaffInfos");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
