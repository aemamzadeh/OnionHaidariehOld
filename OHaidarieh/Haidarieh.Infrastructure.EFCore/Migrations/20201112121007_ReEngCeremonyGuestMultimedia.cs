using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Haidarieh.Infrastructure.EFCore.Migrations
{
    public partial class ReEngCeremonyGuestMultimedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Multimedia_Tbl_CeremonyGuest_CeremonyGuestId",
                table: "Tbl_Multimedia");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Multimedia_CeremonyGuestId",
                table: "Tbl_Multimedia");

            migrationBuilder.DropColumn(
                name: "CeremonyGuestId",
                table: "Tbl_Multimedia");

            migrationBuilder.DropColumn(
                name: "CeremonyDate",
                table: "Tbl_CeremonyGuest");

            migrationBuilder.AddColumn<long>(
                name: "CeremonyId",
                table: "Tbl_Multimedia",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Multimedia_CeremonyId",
                table: "Tbl_Multimedia",
                column: "CeremonyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Multimedia_Tbl_Ceremony_CeremonyId",
                table: "Tbl_Multimedia",
                column: "CeremonyId",
                principalTable: "Tbl_Ceremony",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Multimedia_Tbl_Ceremony_CeremonyId",
                table: "Tbl_Multimedia");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Multimedia_CeremonyId",
                table: "Tbl_Multimedia");

            migrationBuilder.DropColumn(
                name: "CeremonyId",
                table: "Tbl_Multimedia");

            migrationBuilder.AddColumn<long>(
                name: "CeremonyGuestId",
                table: "Tbl_Multimedia",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CeremonyDate",
                table: "Tbl_CeremonyGuest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Multimedia_CeremonyGuestId",
                table: "Tbl_Multimedia",
                column: "CeremonyGuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Multimedia_Tbl_CeremonyGuest_CeremonyGuestId",
                table: "Tbl_Multimedia",
                column: "CeremonyGuestId",
                principalTable: "Tbl_CeremonyGuest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
