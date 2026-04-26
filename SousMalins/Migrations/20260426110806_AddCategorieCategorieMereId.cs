using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SousMalins.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorieCategorieMereId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieMereId",
                table: "Categories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategorieMereId",
                table: "Categories",
                column: "CategorieMereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategorieMereId",
                table: "Categories",
                column: "CategorieMereId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategorieMereId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategorieMereId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategorieMereId",
                table: "Categories");
        }
    }
}
