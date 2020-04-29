using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class winkwink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorier",
                columns: table => new
                {
                    KategoriId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriNavn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorier", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    KundeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fornavn = table.Column<string>(nullable: true),
                    Efternavn = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefon = table.Column<int>(nullable: false),
                    Kodeord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunder", x => x.KundeId);
                });

            migrationBuilder.CreateTable(
                name: "Producenter",
                columns: table => new
                {
                    ProducentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducentNavn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producenter", x => x.ProducentId);
                });

            migrationBuilder.CreateTable(
                name: "Ordre",
                columns: table => new
                {
                    OrdreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KundeId = table.Column<int>(nullable: false),
                    BestillingsDato = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordre", x => x.OrdreId);
                    table.ForeignKey(
                        name: "FK_Ordre_Kunder_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunder",
                        principalColumn: "KundeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produkter",
                columns: table => new
                {
                    ProduktId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktNavn = table.Column<string>(nullable: true),
                    Pris = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    ProducentId = table.Column<int>(nullable: false),
                    KategoriId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkter", x => x.ProduktId);
                    table.ForeignKey(
                        name: "FK_Produkter_Kategorier_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorier",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkter_Producenter_ProducentId",
                        column: x => x.ProducentId,
                        principalTable: "Producenter",
                        principalColumn: "ProducentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduktFoto",
                columns: table => new
                {
                    ProduktFotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktId = table.Column<int>(nullable: true),
                    FotoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktFoto", x => x.ProduktFotoId);
                    table.ForeignKey(
                        name: "FK_ProduktFoto_Produkter_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkter",
                        principalColumn: "ProduktId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProduktOrdrer",
                columns: table => new
                {
                    ProduktId = table.Column<int>(nullable: false),
                    OrdreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktOrdrer", x => new { x.ProduktId, x.OrdreId });
                    table.ForeignKey(
                        name: "FK_ProduktOrdrer_Ordre_OrdreId",
                        column: x => x.OrdreId,
                        principalTable: "Ordre",
                        principalColumn: "OrdreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduktOrdrer_Produkter_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkter",
                        principalColumn: "ProduktId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordre_KundeId",
                table: "Ordre",
                column: "KundeId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_KategoriId",
                table: "Produkter",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_ProducentId",
                table: "Produkter",
                column: "ProducentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktFoto_ProduktId",
                table: "ProduktFoto",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktOrdrer_OrdreId",
                table: "ProduktOrdrer",
                column: "OrdreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduktFoto");

            migrationBuilder.DropTable(
                name: "ProduktOrdrer");

            migrationBuilder.DropTable(
                name: "Ordre");

            migrationBuilder.DropTable(
                name: "Produkter");

            migrationBuilder.DropTable(
                name: "Kunder");

            migrationBuilder.DropTable(
                name: "Kategorier");

            migrationBuilder.DropTable(
                name: "Producenter");
        }
    }
}
