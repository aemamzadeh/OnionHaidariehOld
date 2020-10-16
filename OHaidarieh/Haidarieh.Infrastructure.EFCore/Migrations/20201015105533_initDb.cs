using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Haidarieh.Infrastructure.EFCore.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Ceremony",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    CeremonyDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Ceremony", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Guest",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ImageAlt = table.Column<string>(nullable: true),
                    ImageTitle = table.Column<string>(nullable: true),
                    GuestType = table.Column<string>(nullable: true),
                    Coordinator = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Guest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Member",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    Mobile = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Sponsor",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Tel = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ImageAlt = table.Column<string>(nullable: true),
                    ImageTitle = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    Bio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Sponsor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CeremonyGuest",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<long>(nullable: false),
                    CeremonyId = table.Column<long>(nullable: false),
                    CeremonyDate = table.Column<DateTime>(nullable: false),
                    Satisfication = table.Column<float>(nullable: false),
                    IsLive = table.Column<bool>(nullable: false),
                    BannerFile = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ImageAlt = table.Column<string>(nullable: true),
                    ImageTitle = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CeremonyGuest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_CeremonyGuest_Tbl_Ceremony_CeremonyId",
                        column: x => x.CeremonyId,
                        principalTable: "Tbl_Ceremony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_CeremonyGuest_Tbl_Guest_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Tbl_Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Multimedia",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    FileAddress = table.Column<string>(nullable: false),
                    FileTitle = table.Column<string>(nullable: true),
                    FileAlt = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CeremonyGuestId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Multimedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Multimedia_Tbl_CeremonyGuest_CeremonyGuestId",
                        column: x => x.CeremonyGuestId,
                        principalTable: "Tbl_CeremonyGuest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CeremonyGuest_CeremonyId",
                table: "Tbl_CeremonyGuest",
                column: "CeremonyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CeremonyGuest_GuestId",
                table: "Tbl_CeremonyGuest",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Multimedia_CeremonyGuestId",
                table: "Tbl_Multimedia",
                column: "CeremonyGuestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Member");

            migrationBuilder.DropTable(
                name: "Tbl_Multimedia");

            migrationBuilder.DropTable(
                name: "Tbl_Sponsor");

            migrationBuilder.DropTable(
                name: "Tbl_CeremonyGuest");

            migrationBuilder.DropTable(
                name: "Tbl_Ceremony");

            migrationBuilder.DropTable(
                name: "Tbl_Guest");
        }
    }
}
