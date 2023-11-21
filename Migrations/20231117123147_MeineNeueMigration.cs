using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiServiceDatenbank.Migrations
{
    /// <inheritdoc />
    public partial class MeineNeueMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dienstleistung",
                table: "SkiServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SkiServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kundenname",
                table: "SkiServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priorität",
                table: "SkiServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "SkiServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dienstleistung",
                table: "SkiServices");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "SkiServices");

            migrationBuilder.DropColumn(
                name: "Kundenname",
                table: "SkiServices");

            migrationBuilder.DropColumn(
                name: "Priorität",
                table: "SkiServices");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "SkiServices");
        }
    }
}
