using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPMS.EF.Migrations
{
    public partial class addNewTable6532 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurplusStock",
                table: "Stocks",
                newName: "Number");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Stocks",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "StaffInfos",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Salarys",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Products",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Positions",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "PersonalSchedules",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Logs",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "LoginInfos",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "InAndOutStockDetaileds",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurplusStock",
                table: "InAndOutStockDetaileds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Departments",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "CompanySchedules",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "AttendanceTimeSets",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Attendances",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StockOperationRecordss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    LastUpTime = table.Column<DateTime>(maxLength: 30, nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    InOrOut = table.Column<int>(nullable: false),
                    SurplusStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockOperationRecordss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockOperationRecordss_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockOperationRecordss_StockId",
                table: "StockOperationRecordss",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockOperationRecordss");

            migrationBuilder.DropColumn(
                name: "SurplusStock",
                table: "InAndOutStockDetaileds");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Stocks",
                newName: "SurplusStock");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Stocks",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "StaffInfos",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Salarys",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Products",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Positions",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "PersonalSchedules",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Logs",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "LoginInfos",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "InAndOutStockDetaileds",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Departments",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "CompanySchedules",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "AttendanceTimeSets",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpTime",
                table: "Attendances",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 30);
        }
    }
}
