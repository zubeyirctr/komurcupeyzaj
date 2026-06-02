using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KomürcüPeyzaj.Migrations
{
    /// <inheritdoc />
    public partial class AddReferansKurumsal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirmaAdi",
                table: "Referanslar",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirmaLogoUrl",
                table: "Referanslar",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "KurumsalMi",
                table: "Referanslar",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirmaAdi",
                table: "Referanslar");

            migrationBuilder.DropColumn(
                name: "FirmaLogoUrl",
                table: "Referanslar");

            migrationBuilder.DropColumn(
                name: "KurumsalMi",
                table: "Referanslar");
        }
    }
}
