using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initialseeding : Migration
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

            migrationBuilder.InsertData(
                table: "Kategorier",
                columns: new[] { "KategoriId", "KategoriNavn" },
                values: new object[,]
                {
                    { 1, "Grafikkort" },
                    { 2, "Bærbar" },
                    { 3, "Mobil" },
                    { 4, "TV" },
                    { 5, "Tastatur" },
                    { 6, "Mus" }
                });

            migrationBuilder.InsertData(
                table: "Kunder",
                columns: new[] { "KundeId", "Adresse", "Efternavn", "Email", "Fornavn", "Kodeord", "Telefon" },
                values: new object[,]
                {
                    { 1, "HAHA", "Schultz", "niel862b@elevcampus.dk", "Niels", "Qwerty123", 81616659 },
                    { 2, "FakeHAHA", "FakeSchultz", "Fakeniel862b@elevcampus.dk", "FakeNiels", "Qwerty123", 95661618 }
                });

            migrationBuilder.InsertData(
                table: "Producenter",
                columns: new[] { "ProducentId", "ProducentNavn" },
                values: new object[,]
                {
                    { 9, "LG" },
                    { 8, "Samsung" },
                    { 7, "MSI" },
                    { 6, "HP" },
                    { 2, "Acer" },
                    { 4, "Lenovo" },
                    { 3, "Apple" },
                    { 10, "Razer" },
                    { 1, "ASUS" },
                    { 5, "DELL" },
                    { 11, "Steelseries" }
                });

            migrationBuilder.InsertData(
                table: "Produkter",
                columns: new[] { "ProduktId", "KategoriId", "Pris", "ProducentId", "ProduktNavn" },
                values: new object[,]
                {
                    { 1, 1, 7319m, 1, "ASUS GeForce RTX 2080 SUPER ROG Strix Advanced" },
                    { 27, 6, 1349m, 10, "Razer Basilisk Ultimate Trådløs Gaming Mus" },
                    { 24, 5, 1399m, 10, "Razer BlackWidow Elite Gaming Tastatur" },
                    { 15, 2, 33495m, 10, "Razer Blade Pro 17,3 UHD / 4K touch 120 Hz" },
                    { 23, 4, 11999m, 9, "LG 48 OLED TV OLED48CX6" },
                    { 22, 4, 9990m, 9, "LG 55 UHD OLED Smart TV OLED55C9" },
                    { 21, 4, 39990m, 8, "Samsung 75 QLED Smart TV QE75Q90R" },
                    { 20, 4, 16990m, 8, "Samsung 75 QLED Smart TV QE75Q60R" },
                    { 17, 3, 2789m, 8, "Samsung Galaxy A51 128GB Sort" },
                    { 16, 3, 10499m, 8, "Samsung Galaxy S20 Ultra 5G 128GB Grå" },
                    { 7, 2, 11995m, 7, "MSI Prestige 15 15,6 Full HD" },
                    { 5, 2, 19990m, 7, "MSI GE75 Raider 17,3 FHD 240 Hz" },
                    { 2, 1, 6999m, 7, "MSI GeForce RTX 2080 SUPER SEA HAWK EK X" },
                    { 26, 5, 1599m, 11, "SteelSeries Apex Pro Gaming Tastatur" },
                    { 14, 2, 17495m, 6, "HP Spectre x360 15-df1012no 15,6 UHD OLED touch" },
                    { 12, 2, 5290m, 5, "Dell Vostro 3590 15,6 Full HD" },
                    { 11, 2, 27990m, 4, "Lenovo ThinkPad P53 15,6 Workstation Pro Full HD" },
                    { 19, 3, 3699m, 3, "Apple iPhone SE 64GB Sort" },
                    { 18, 3, 9649m, 3, "iPhone 11 Pro Max 64 GB Grå" },
                    { 10, 2, 21999m, 3, "Apple MacBook Pro laptop 16 1TB MVV med touch bar" },
                    { 9, 2, 2495m, 2, "Acer Chromebook R13 CB5-312T 13.3 FHD" },
                    { 6, 2, 5290m, 2, "Acer Nitro 5 15,6 FHD 120 Hz" },
                    { 28, 6, 1079m, 1, "ASUS ROG Chakram Trådløs Gaming Mus" },
                    { 25, 5, 1099m, 1, "ASUS ROG Strix Scope Gaming Tastatur" },
                    { 8, 2, 21490m, 1, "ASUS ZenBook Pro Duo 15,6 UHD / 4K OLED Touch" },
                    { 4, 1, 2229m, 1, "ASUS GeForce GTX 1660 SUPER ROG Strix OC" },
                    { 3, 1, 1999m, 1, "ASUS Radeon RX 5500 XT ROG Strix OC 8GB" },
                    { 13, 2, 13690m, 5, "Dell XPS 13 7390 13,3 UHD / 4K Touch" },
                    { 29, 6, 799m, 11, "Steelseries Rival 710 Gaming Mus" }
                });

            migrationBuilder.InsertData(
                table: "ProduktFoto",
                columns: new[] { "ProduktFotoId", "FotoUrl", "ProduktId" },
                values: new object[] { 1, "https://www.elgiganten.dk/image/dv_web_D180001002410624/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$fullsize$", 23 });

            migrationBuilder.InsertData(
                table: "ProduktFoto",
                columns: new[] { "ProduktFotoId", "FotoUrl", "ProduktId" },
                values: new object[] { 2, "https://www.elgiganten.dk/image/dv_web_D180001002410670/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$fullsize$", 23 });

            migrationBuilder.InsertData(
                table: "ProduktFoto",
                columns: new[] { "ProduktFotoId", "FotoUrl", "ProduktId" },
                values: new object[] { 3, "https://www.elgiganten.dk/image/dv_web_D180001002410669/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$prod_all4one$", 23 });

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
