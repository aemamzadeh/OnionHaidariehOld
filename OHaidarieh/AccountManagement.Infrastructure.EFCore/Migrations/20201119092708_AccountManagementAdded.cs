using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManagement.Infrastructure.EFCore.Migrations
{
    public partial class AccountManagementAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Accounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Accounts");
        }
    }
}
