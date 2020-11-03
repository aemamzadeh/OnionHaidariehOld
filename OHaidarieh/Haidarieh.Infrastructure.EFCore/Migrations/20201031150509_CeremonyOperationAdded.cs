using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Haidarieh.Infrastructure.EFCore.Migrations
{
    public partial class CeremonyOperationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_CeremonyOperation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operation = table.Column<int>(nullable: false),
                    OperatorId = table.Column<long>(nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CeremonyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CeremonyOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_CeremonyOperation_Tbl_Ceremony_CeremonyId",
                        column: x => x.CeremonyId,
                        principalTable: "Tbl_Ceremony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CeremonyOperation_CeremonyId",
                table: "Tbl_CeremonyOperation",
                column: "CeremonyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_CeremonyOperation");
        }
    }
}
