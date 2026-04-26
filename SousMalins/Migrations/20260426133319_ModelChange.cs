using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SousMalins.Migrations
{
    /// <inheritdoc />
    public partial class ModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategorieMereId",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategorieMereId",
                table: "Categories",
                column: "CategorieMereId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategorieMereId",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategorieMereId",
                table: "Categories",
                column: "CategorieMereId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
