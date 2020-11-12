using Microsoft.EntityFrameworkCore.Migrations;

namespace Haidarieh.Infrastructure.EFCore.Migrations
{
    public partial class CorrectionModelsCeremonyandCeremonyGuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerFile",
                table: "Tbl_CeremonyGuest");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tbl_CeremonyGuest");

            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Tbl_CeremonyGuest");

            migrationBuilder.DropColumn(
                name: "ImageTitle",
                table: "Tbl_CeremonyGuest");

            migrationBuilder.DropColumn(
                name: "IsLive",
                table: "Tbl_CeremonyGuest");

            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "Tbl_CeremonyGuest");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Tbl_CeremonyGuest");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Tbl_CeremonyGuest");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tbl_CeremonyGuest");

            migrationBuilder.AddColumn<string>(
                name: "BannerFile",
                table: "Tbl_Ceremony",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Tbl_Ceremony",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Tbl_Ceremony",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                table: "Tbl_Ceremony",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLive",
                table: "Tbl_Ceremony",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "Tbl_Ceremony",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Tbl_Ceremony",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Tbl_Ceremony",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerFile",
                table: "Tbl_Ceremony");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tbl_Ceremony");

            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Tbl_Ceremony");

            migrationBuilder.DropColumn(
                name: "ImageTitle",
                table: "Tbl_Ceremony");

            migrationBuilder.DropColumn(
                name: "IsLive",
                table: "Tbl_Ceremony");

            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "Tbl_Ceremony");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Tbl_Ceremony");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Tbl_Ceremony");

            migrationBuilder.AddColumn<string>(
                name: "BannerFile",
                table: "Tbl_CeremonyGuest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Tbl_CeremonyGuest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Tbl_CeremonyGuest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                table: "Tbl_CeremonyGuest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLive",
                table: "Tbl_CeremonyGuest",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "Tbl_CeremonyGuest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Tbl_CeremonyGuest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Tbl_CeremonyGuest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Tbl_CeremonyGuest",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
