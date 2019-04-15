using Microsoft.EntityFrameworkCore.Migrations;

namespace EPMS.EF.Migrations
{
    public partial class UpdateAdminTable123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSuperAdmin",
                table: "Admins",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSuperAdmin",
                table: "Admins");
        }
    }
}
