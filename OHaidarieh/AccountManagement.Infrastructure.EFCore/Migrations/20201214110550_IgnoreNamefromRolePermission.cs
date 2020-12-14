using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class IgnoreNamefromRolePermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Tbl_RolePermission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Tbl_RolePermission",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
