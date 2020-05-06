﻿// <auto-generated />
using System;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(eShopContext))]
    partial class eShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entities.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KategoriNavn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategorier");

                    b.HasData(
                        new
                        {
                            KategoriId = 1,
                            KategoriNavn = "Grafikkort"
                        },
                        new
                        {
                            KategoriId = 2,
                            KategoriNavn = "Bærbar"
                        },
                        new
                        {
                            KategoriId = 3,
                            KategoriNavn = "Mobil"
                        },
                        new
                        {
                            KategoriId = 4,
                            KategoriNavn = "TV"
                        },
                        new
                        {
                            KategoriId = 5,
                            KategoriNavn = "Tastatur"
                        },
                        new
                        {
                            KategoriId = 6,
                            KategoriNavn = "Mus"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Kunde", b =>
                {
                    b.Property<int>("KundeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Efternavn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fornavn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kodeord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefon")
                        .HasColumnType("int");

                    b.HasKey("KundeId");

                    b.ToTable("Kunder");

                    b.HasData(
                        new
                        {
                            KundeId = 1,
                            Adresse = "HAHA",
                            Efternavn = "Schultz",
                            Email = "niel862b@elevcampus.dk",
                            Fornavn = "Niels",
                            Kodeord = "Qwerty123",
                            Telefon = 81616659
                        },
                        new
                        {
                            KundeId = 2,
                            Adresse = "FakeHAHA",
                            Efternavn = "FakeSchultz",
                            Email = "Fakeniel862b@elevcampus.dk",
                            Fornavn = "FakeNiels",
                            Kodeord = "Qwerty123",
                            Telefon = 95661618
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Ordre", b =>
                {
                    b.Property<int>("OrdreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BestillingsDato")
                        .HasColumnType("datetime2");

                    b.Property<int>("KundeId")
                        .HasColumnType("int");

                    b.HasKey("OrdreId");

                    b.HasIndex("KundeId");

                    b.ToTable("Ordre");
                });

            modelBuilder.Entity("DataLayer.Entities.Producent", b =>
                {
                    b.Property<int>("ProducentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProducentNavn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProducentId");

                    b.ToTable("Producenter");

                    b.HasData(
                        new
                        {
                            ProducentId = 1,
                            ProducentNavn = "ASUS"
                        },
                        new
                        {
                            ProducentId = 2,
                            ProducentNavn = "Acer"
                        },
                        new
                        {
                            ProducentId = 3,
                            ProducentNavn = "Apple"
                        },
                        new
                        {
                            ProducentId = 4,
                            ProducentNavn = "Lenovo"
                        },
                        new
                        {
                            ProducentId = 5,
                            ProducentNavn = "DELL"
                        },
                        new
                        {
                            ProducentId = 6,
                            ProducentNavn = "HP"
                        },
                        new
                        {
                            ProducentId = 7,
                            ProducentNavn = "MSI"
                        },
                        new
                        {
                            ProducentId = 8,
                            ProducentNavn = "Samsung"
                        },
                        new
                        {
                            ProducentId = 9,
                            ProducentNavn = "LG"
                        },
                        new
                        {
                            ProducentId = 10,
                            ProducentNavn = "Razer"
                        },
                        new
                        {
                            ProducentId = 11,
                            ProducentNavn = "Steelseries"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Produkt", b =>
                {
                    b.Property<int>("ProduktId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<decimal>("Pris")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<int>("ProducentId")
                        .HasColumnType("int");

                    b.Property<string>("ProduktNavn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProduktId");

                    b.HasIndex("KategoriId");

                    b.HasIndex("ProducentId");

                    b.ToTable("Produkter");

                    b.HasData(
                        new
                        {
                            ProduktId = 1,
                            KategoriId = 1,
                            Pris = 7319m,
                            ProducentId = 1,
                            ProduktNavn = "ASUS GeForce RTX 2080 SUPER ROG Strix Advanced"
                        },
                        new
                        {
                            ProduktId = 2,
                            KategoriId = 1,
                            Pris = 6999m,
                            ProducentId = 7,
                            ProduktNavn = "MSI GeForce RTX 2080 SUPER SEA HAWK EK X"
                        },
                        new
                        {
                            ProduktId = 3,
                            KategoriId = 1,
                            Pris = 1999m,
                            ProducentId = 1,
                            ProduktNavn = "ASUS Radeon RX 5500 XT ROG Strix OC 8GB"
                        },
                        new
                        {
                            ProduktId = 4,
                            KategoriId = 1,
                            Pris = 2229m,
                            ProducentId = 1,
                            ProduktNavn = "ASUS GeForce GTX 1660 SUPER ROG Strix OC"
                        },
                        new
                        {
                            ProduktId = 5,
                            KategoriId = 2,
                            Pris = 19990m,
                            ProducentId = 7,
                            ProduktNavn = "MSI GE75 Raider 17,3 FHD 240 Hz"
                        },
                        new
                        {
                            ProduktId = 6,
                            KategoriId = 2,
                            Pris = 5290m,
                            ProducentId = 2,
                            ProduktNavn = "Acer Nitro 5 15,6 FHD 120 Hz"
                        },
                        new
                        {
                            ProduktId = 7,
                            KategoriId = 2,
                            Pris = 11995m,
                            ProducentId = 7,
                            ProduktNavn = "MSI Prestige 15 15,6 Full HD"
                        },
                        new
                        {
                            ProduktId = 8,
                            KategoriId = 2,
                            Pris = 21490m,
                            ProducentId = 1,
                            ProduktNavn = "ASUS ZenBook Pro Duo 15,6 UHD / 4K OLED Touch"
                        },
                        new
                        {
                            ProduktId = 9,
                            KategoriId = 2,
                            Pris = 2495m,
                            ProducentId = 2,
                            ProduktNavn = "Acer Chromebook R13 CB5-312T 13.3 FHD"
                        },
                        new
                        {
                            ProduktId = 10,
                            KategoriId = 2,
                            Pris = 21999m,
                            ProducentId = 3,
                            ProduktNavn = "Apple MacBook Pro laptop 16 1TB MVV med touch bar"
                        },
                        new
                        {
                            ProduktId = 11,
                            KategoriId = 2,
                            Pris = 27990m,
                            ProducentId = 4,
                            ProduktNavn = "Lenovo ThinkPad P53 15,6 Workstation Pro Full HD"
                        },
                        new
                        {
                            ProduktId = 12,
                            KategoriId = 2,
                            Pris = 5290m,
                            ProducentId = 5,
                            ProduktNavn = "Dell Vostro 3590 15,6 Full HD"
                        },
                        new
                        {
                            ProduktId = 13,
                            KategoriId = 2,
                            Pris = 13690m,
                            ProducentId = 5,
                            ProduktNavn = "Dell XPS 13 7390 13,3 UHD / 4K Touch"
                        },
                        new
                        {
                            ProduktId = 14,
                            KategoriId = 2,
                            Pris = 17495m,
                            ProducentId = 6,
                            ProduktNavn = "HP Spectre x360 15-df1012no 15,6 UHD OLED touch"
                        },
                        new
                        {
                            ProduktId = 15,
                            KategoriId = 2,
                            Pris = 33495m,
                            ProducentId = 10,
                            ProduktNavn = "Razer Blade Pro 17,3 UHD / 4K touch 120 Hz"
                        },
                        new
                        {
                            ProduktId = 16,
                            KategoriId = 3,
                            Pris = 10499m,
                            ProducentId = 8,
                            ProduktNavn = "Samsung Galaxy S20 Ultra 5G 128GB Grå"
                        },
                        new
                        {
                            ProduktId = 17,
                            KategoriId = 3,
                            Pris = 2789m,
                            ProducentId = 8,
                            ProduktNavn = "Samsung Galaxy A51 128GB Sort"
                        },
                        new
                        {
                            ProduktId = 18,
                            KategoriId = 3,
                            Pris = 9649m,
                            ProducentId = 3,
                            ProduktNavn = "iPhone 11 Pro Max 64 GB Grå"
                        },
                        new
                        {
                            ProduktId = 19,
                            KategoriId = 3,
                            Pris = 3699m,
                            ProducentId = 3,
                            ProduktNavn = "Apple iPhone SE 64GB Sort"
                        },
                        new
                        {
                            ProduktId = 20,
                            KategoriId = 4,
                            Pris = 16990m,
                            ProducentId = 8,
                            ProduktNavn = "Samsung 75 QLED Smart TV QE75Q60R"
                        },
                        new
                        {
                            ProduktId = 21,
                            KategoriId = 4,
                            Pris = 39990m,
                            ProducentId = 8,
                            ProduktNavn = "Samsung 75 QLED Smart TV QE75Q90R"
                        },
                        new
                        {
                            ProduktId = 22,
                            KategoriId = 4,
                            Pris = 9990m,
                            ProducentId = 9,
                            ProduktNavn = "LG 55 UHD OLED Smart TV OLED55C9"
                        },
                        new
                        {
                            ProduktId = 23,
                            KategoriId = 4,
                            Pris = 11999m,
                            ProducentId = 9,
                            ProduktNavn = "LG 48 OLED TV OLED48CX6"
                        },
                        new
                        {
                            ProduktId = 24,
                            KategoriId = 5,
                            Pris = 1399m,
                            ProducentId = 10,
                            ProduktNavn = "Razer BlackWidow Elite Gaming Tastatur"
                        },
                        new
                        {
                            ProduktId = 25,
                            KategoriId = 5,
                            Pris = 1099m,
                            ProducentId = 1,
                            ProduktNavn = "ASUS ROG Strix Scope Gaming Tastatur"
                        },
                        new
                        {
                            ProduktId = 26,
                            KategoriId = 5,
                            Pris = 1599m,
                            ProducentId = 11,
                            ProduktNavn = "SteelSeries Apex Pro Gaming Tastatur"
                        },
                        new
                        {
                            ProduktId = 27,
                            KategoriId = 6,
                            Pris = 1349m,
                            ProducentId = 10,
                            ProduktNavn = "Razer Basilisk Ultimate Trådløs Gaming Mus"
                        },
                        new
                        {
                            ProduktId = 28,
                            KategoriId = 6,
                            Pris = 1079m,
                            ProducentId = 1,
                            ProduktNavn = "ASUS ROG Chakram Trådløs Gaming Mus"
                        },
                        new
                        {
                            ProduktId = 29,
                            KategoriId = 6,
                            Pris = 799m,
                            ProducentId = 11,
                            ProduktNavn = "Steelseries Rival 710 Gaming Mus"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.ProduktFoto", b =>
                {
                    b.Property<int>("ProduktFotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProduktId")
                        .HasColumnType("int");

                    b.HasKey("ProduktFotoId");

                    b.HasIndex("ProduktId");

                    b.ToTable("ProduktFoto");

                    b.HasData(
                        new
                        {
                            ProduktFotoId = 1,
                            FotoUrl = "https://www.elgiganten.dk/image/dv_web_D180001002410624/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$fullsize$",
                            ProduktId = 23
                        },
                        new
                        {
                            ProduktFotoId = 2,
                            FotoUrl = "https://www.elgiganten.dk/image/dv_web_D180001002410670/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$fullsize$",
                            ProduktId = 23
                        },
                        new
                        {
                            ProduktFotoId = 3,
                            FotoUrl = "https://www.elgiganten.dk/image/dv_web_D180001002410669/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$prod_all4one$",
                            ProduktId = 23
                        },
                        new
                        {
                            ProduktFotoId = 4,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1135677.jpg",
                            ProduktId = 1
                        },
                        new
                        {
                            ProduktFotoId = 5,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1139034.jpg",
                            ProduktId = 2
                        },
                        new
                        {
                            ProduktFotoId = 6,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1149212.jpg",
                            ProduktId = 3
                        },
                        new
                        {
                            ProduktFotoId = 7,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1148757.jpg",
                            ProduktId = 4
                        },
                        new
                        {
                            ProduktFotoId = 8,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1153467.jpg",
                            ProduktId = 5
                        },
                        new
                        {
                            ProduktFotoId = 9,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1156443.jpg",
                            ProduktId = 6
                        },
                        new
                        {
                            ProduktFotoId = 10,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1135667.jpg",
                            ProduktId = 7
                        },
                        new
                        {
                            ProduktFotoId = 11,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1132405.jpg",
                            ProduktId = 8
                        },
                        new
                        {
                            ProduktFotoId = 12,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/898464.jpg",
                            ProduktId = 9
                        },
                        new
                        {
                            ProduktFotoId = 13,
                            FotoUrl = "https://sg-next.imgix.net/medias/sys_master/root/hbd/h3a/13735092912158/MacBook-Pro-16-in-Pure-Front-Space-Gray-SCREEN-result.jpg?w=350&h=350&auto=format&fm=jpg",
                            ProduktId = 10
                        },
                        new
                        {
                            ProduktFotoId = 14,
                            FotoUrl = "https://www.komplett.dk/img/p/1000/1137677.jpg",
                            ProduktId = 11
                        },
                        new
                        {
                            ProduktFotoId = 15,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1150472.jpg",
                            ProduktId = 12
                        },
                        new
                        {
                            ProduktFotoId = 16,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1146637.jpg",
                            ProduktId = 13
                        },
                        new
                        {
                            ProduktFotoId = 17,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1132707.jpg",
                            ProduktId = 14
                        },
                        new
                        {
                            ProduktFotoId = 18,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1153777.jpg",
                            ProduktId = 15
                        },
                        new
                        {
                            ProduktFotoId = 19,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1151019.jpg",
                            ProduktId = 16
                        },
                        new
                        {
                            ProduktFotoId = 20,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1149587.jpg",
                            ProduktId = 17
                        },
                        new
                        {
                            ProduktFotoId = 21,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1138869.jpg",
                            ProduktId = 18
                        },
                        new
                        {
                            ProduktFotoId = 22,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1157749.jpg",
                            ProduktId = 19
                        },
                        new
                        {
                            ProduktFotoId = 23,
                            FotoUrl = "https://www.komplett.dk/img/p/1080/1124639.jpg",
                            ProduktId = 20
                        },
                        new
                        {
                            ProduktFotoId = 24,
                            FotoUrl = "https://www.komplett.dk/img/p/1080/1124646.jpg",
                            ProduktId = 21
                        },
                        new
                        {
                            ProduktFotoId = 25,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1130516.jpg",
                            ProduktId = 22
                        },
                        new
                        {
                            ProduktFotoId = 26,
                            FotoUrl = "https://www.elgiganten.dk/image/dv_web_D180001002410624/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$fullsize$",
                            ProduktId = 23
                        },
                        new
                        {
                            ProduktFotoId = 27,
                            FotoUrl = "https://www.elgiganten.dk/image/dv_web_D18000100296972/12851/razer-blackwidow-elite-gaming-tastatur.jpg?$fullsize$",
                            ProduktId = 24
                        },
                        new
                        {
                            ProduktFotoId = 28,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1144808.jpg",
                            ProduktId = 25
                        },
                        new
                        {
                            ProduktFotoId = 29,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1127733.jpg",
                            ProduktId = 26
                        },
                        new
                        {
                            ProduktFotoId = 30,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1146944.jpg",
                            ProduktId = 27
                        },
                        new
                        {
                            ProduktFotoId = 31,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1150475.jpg",
                            ProduktId = 28
                        },
                        new
                        {
                            ProduktFotoId = 32,
                            FotoUrl = "https://www.komplett.dk/img/p/1200/1041072.jpg",
                            ProduktId = 29
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.ProduktOrdrer", b =>
                {
                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.Property<int>("OrdreId")
                        .HasColumnType("int");

                    b.HasKey("ProduktId", "OrdreId");

                    b.HasIndex("OrdreId");

                    b.ToTable("ProduktOrdrer");
                });

            modelBuilder.Entity("DataLayer.Entities.Ordre", b =>
                {
                    b.HasOne("DataLayer.Entities.Kunde", "Kunde")
                        .WithMany("Ordrer")
                        .HasForeignKey("KundeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.Produkt", b =>
                {
                    b.HasOne("DataLayer.Entities.Kategori", "Kategori")
                        .WithMany("Produkter")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Producent", "Producent")
                        .WithMany("Produkter")
                        .HasForeignKey("ProducentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.ProduktFoto", b =>
                {
                    b.HasOne("DataLayer.Entities.Produkt", "Produkt")
                        .WithMany("ProduktFoto")
                        .HasForeignKey("ProduktId");
                });

            modelBuilder.Entity("DataLayer.Entities.ProduktOrdrer", b =>
                {
                    b.HasOne("DataLayer.Entities.Ordre", "Ordrer")
                        .WithMany("Produkter")
                        .HasForeignKey("OrdreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Produkt", "Produkter")
                        .WithMany("Ordrer")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
