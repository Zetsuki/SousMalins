using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SousMalins.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comptes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", nullable: false),
                    Plafond = table.Column<int>(type: "INTEGER", nullable: false),
                    SoldeInitial = table.Column<int>(type: "INTEGER", nullable: false),
                    SoldeInitialDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transferts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Montant = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Libelle = table.Column<string>(type: "TEXT", nullable: true),
                    CompteSourceId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompteDestinationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferts_Comptes_CompteDestinationId",
                        column: x => x.CompteDestinationId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transferts_Comptes_CompteSourceId",
                        column: x => x.CompteSourceId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Montant = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeTransaction = table.Column<string>(type: "TEXT", nullable: false),
                    Libelle = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategorieId = table.Column<int>(type: "INTEGER", nullable: true),
                    CompteId = table.Column<int>(type: "INTEGER", nullable: false),
                    TransfertId = table.Column<int>(type: "INTEGER", nullable: true),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Transactions_Comptes_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Transferts_TransfertId",
                        column: x => x.TransfertId,
                        principalTable: "Transferts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Libelle",
                table: "Categories",
                column: "Libelle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_Libelle",
                table: "Comptes",
                column: "Libelle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategorieId",
                table: "Transactions",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CompteId",
                table: "Transactions",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransfertId",
                table: "Transactions",
                column: "TransfertId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferts_CompteDestinationId",
                table: "Transferts",
                column: "CompteDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferts_CompteSourceId",
                table: "Transferts",
                column: "CompteSourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Transferts");

            migrationBuilder.DropTable(
                name: "Comptes");
        }
    }
}
