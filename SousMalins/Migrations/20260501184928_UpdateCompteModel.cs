using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SousMalins.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Banque",
                table: "Comptes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titulaire",
                table: "Comptes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Comptes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banque",
                table: "Comptes");

            migrationBuilder.DropColumn(
                name: "Titulaire",
                table: "Comptes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Comptes");
        }
    }
}
