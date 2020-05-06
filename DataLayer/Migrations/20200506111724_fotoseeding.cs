using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class fotoseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProduktFoto",
                columns: new[] { "ProduktFotoId", "FotoUrl", "ProduktId" },
                values: new object[,]
                {
                    { 4, "https://www.komplett.dk/img/p/1200/1135677.jpg", 1 },
                    { 30, "https://www.komplett.dk/img/p/1200/1146944.jpg", 27 },
                    { 29, "https://www.komplett.dk/img/p/1200/1127733.jpg", 26 },
                    { 28, "https://www.komplett.dk/img/p/1200/1144808.jpg", 25 },
                    { 27, "https://www.elgiganten.dk/image/dv_web_D18000100296972/12851/razer-blackwidow-elite-gaming-tastatur.jpg?$fullsize$", 24 },
                    { 26, "https://www.elgiganten.dk/image/dv_web_D180001002410624/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$fullsize$", 23 },
                    { 25, "https://www.komplett.dk/img/p/1200/1130516.jpg", 22 },
                    { 24, "https://www.komplett.dk/img/p/1080/1124646.jpg", 21 },
                    { 23, "https://www.komplett.dk/img/p/1080/1124639.jpg", 20 },
                    { 22, "https://www.komplett.dk/img/p/1200/1157749.jpg", 19 },
                    { 21, "https://www.komplett.dk/img/p/1200/1138869.jpg", 18 },
                    { 20, "https://www.komplett.dk/img/p/1200/1149587.jpg", 17 },
                    { 19, "https://www.komplett.dk/img/p/1200/1151019.jpg", 16 },
                    { 31, "https://www.komplett.dk/img/p/1200/1150475.jpg", 28 },
                    { 18, "https://www.komplett.dk/img/p/1200/1153777.jpg", 15 },
                    { 16, "https://www.komplett.dk/img/p/1200/1146637.jpg", 13 },
                    { 15, "https://www.komplett.dk/img/p/1200/1150472.jpg", 12 },
                    { 14, "https://www.komplett.dk/img/p/1000/1137677.jpg", 11 },
                    { 13, "https://sg-next.imgix.net/medias/sys_master/root/hbd/h3a/13735092912158/MacBook-Pro-16-in-Pure-Front-Space-Gray-SCREEN-result.jpg?w=350&h=350&auto=format&fm=jpg", 10 },
                    { 12, "https://www.komplett.dk/img/p/1200/898464.jpg", 9 },
                    { 11, "https://www.komplett.dk/img/p/1200/1132405.jpg", 8 },
                    { 10, "https://www.komplett.dk/img/p/1200/1135667.jpg", 7 },
                    { 9, "https://www.komplett.dk/img/p/1200/1156443.jpg", 6 },
                    { 8, "https://www.komplett.dk/img/p/1200/1153467.jpg", 5 },
                    { 7, "https://www.komplett.dk/img/p/1200/1148757.jpg", 4 },
                    { 6, "https://www.komplett.dk/img/p/1200/1149212.jpg", 3 },
                    { 5, "https://www.komplett.dk/img/p/1200/1139034.jpg", 2 },
                    { 17, "https://www.komplett.dk/img/p/1200/1132707.jpg", 14 },
                    { 32, "https://www.komplett.dk/img/p/1200/1041072.jpg", 29 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProduktFoto",
                keyColumn: "ProduktFotoId",
                keyValue: 32);
        }
    }
}
