using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RenoI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Deviss",
                columns: table => new
                {
                    DevisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumDevis = table.Column<long>(type: "bigint", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    DateCreatDevis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deviss", x => x.DevisId);
                    table.ForeignKey(
                        name: "FK_Deviss_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    FactureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumFacture = table.Column<long>(type: "bigint", nullable: false),
                    DevisId = table.Column<int>(type: "int", nullable: true),
                    DateFact = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.FactureId);
                    table.ForeignKey(
                        name: "FK_Factures_Deviss_DevisId",
                        column: x => x.DevisId,
                        principalTable: "Deviss",
                        principalColumn: "DevisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LignesDeviss",
                columns: table => new
                {
                    LigneDevisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PrixUnit = table.Column<double>(type: "float", nullable: false),
                    DevisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesDeviss", x => x.LigneDevisId);
                    table.ForeignKey(
                        name: "FK_LignesDeviss_Deviss_DevisId",
                        column: x => x.DevisId,
                        principalTable: "Deviss",
                        principalColumn: "DevisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acomptes",
                columns: table => new
                {
                    AcompteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateVersement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false),
                    ModePaiement = table.Column<int>(type: "int", nullable: false),
                    FactureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acomptes", x => x.AcompteId);
                    table.ForeignKey(
                        name: "FK_Acomptes_Factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "Factures",
                        principalColumn: "FactureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LignesFactures",
                columns: table => new
                {
                    LigneFactureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PrixUnit = table.Column<double>(type: "float", nullable: false),
                    FactureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesFactures", x => x.LigneFactureId);
                    table.ForeignKey(
                        name: "FK_LignesFactures_Factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "Factures",
                        principalColumn: "FactureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acomptes_FactureId",
                table: "Acomptes",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_Deviss_ClientId",
                table: "Deviss",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_DevisId",
                table: "Factures",
                column: "DevisId");

            migrationBuilder.CreateIndex(
                name: "IX_LignesDeviss_DevisId",
                table: "LignesDeviss",
                column: "DevisId");

            migrationBuilder.CreateIndex(
                name: "IX_LignesFactures_FactureId",
                table: "LignesFactures",
                column: "FactureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acomptes");

            migrationBuilder.DropTable(
                name: "LignesDeviss");

            migrationBuilder.DropTable(
                name: "LignesFactures");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Deviss");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
