using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataLayer.Entities
{
    public class eShopContext : DbContext
    {
        public eShopContext(DbContextOptions<eShopContext> options)
            : base(options)
        { }
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Producent> Producenter { get; set; }
        public DbSet<Produkt> Produkter { get; set; }
        public DbSet<Kategori> Kategorier { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=eShop;Trusted_Connection=True;ConnectRetryCount=0")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new ServiceCollection()
            .AddLogging(builder => builder.AddConsole()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider().GetService<ILoggerFactory>());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProduktOrdrer>() //Composite foreignkey ved hjælp af anonymous type
            .HasKey(t => new { t.ProduktId, t.OrdreId });

            modelBuilder.Entity<Producent>().HasData(
                new Producent { ProducentNavn = "ASUS", ProducentId = 1 },
                new Producent { ProducentNavn = "Acer", ProducentId = 2 },
                new Producent { ProducentNavn = "Apple", ProducentId = 3 },
                new Producent { ProducentNavn = "Lenovo", ProducentId = 4 },
                new Producent { ProducentNavn = "DELL", ProducentId = 5 },
                new Producent { ProducentNavn = "HP", ProducentId = 6 },
                new Producent { ProducentNavn = "MSI", ProducentId = 7 },
                new Producent { ProducentNavn = "Samsung", ProducentId = 8 },
                new Producent { ProducentNavn = "LG", ProducentId = 9 },
                new Producent { ProducentNavn = "Razer", ProducentId = 10 },
                new Producent { ProducentNavn = "Steelseries", ProducentId = 11 }

                );

            modelBuilder.Entity<Kategori>().HasData(
                new Kategori { KategoriNavn = "Grafikkort", KategoriId = 1},
                new Kategori { KategoriNavn = "Bærbar", KategoriId = 2 },
                new Kategori { KategoriNavn = "Mobil", KategoriId = 3 },
                new Kategori { KategoriNavn = "TV", KategoriId = 4 },
                new Kategori { KategoriNavn = "Tastatur", KategoriId = 5 },
                new Kategori { KategoriNavn = "Mus", KategoriId = 6 }
                );

            modelBuilder.Entity<Produkt>().HasData(
                new Produkt { ProduktNavn= "ASUS GeForce RTX 2080 SUPER ROG Strix Advanced", KategoriId = 1, ProducentId = 1, Pris = 7319, ProduktId=1 },
                new Produkt { ProduktNavn= "MSI GeForce RTX 2080 SUPER SEA HAWK EK X", KategoriId = 1, ProducentId = 7, Pris = 6999, ProduktId = 2 },
                new Produkt { ProduktNavn= "ASUS Radeon RX 5500 XT ROG Strix OC 8GB", KategoriId = 1, ProducentId = 1, Pris = 1999, ProduktId = 3 },
                new Produkt { ProduktNavn= "ASUS GeForce GTX 1660 SUPER ROG Strix OC", KategoriId = 1, ProducentId = 1, Pris = 2229, ProduktId = 4 },
                new Produkt { ProduktNavn= "MSI GE75 Raider 17,3 FHD 240 Hz", KategoriId = 2, ProducentId = 7, Pris = 19990, ProduktId = 5 },
                new Produkt { ProduktNavn= "Acer Nitro 5 15,6 FHD 120 Hz", KategoriId = 2, ProducentId = 2, Pris = 5290, ProduktId = 6 },
                new Produkt { ProduktNavn= "MSI Prestige 15 15,6 Full HD", KategoriId = 2, ProducentId = 7, Pris = 11995, ProduktId = 7 },
                new Produkt { ProduktNavn= "ASUS ZenBook Pro Duo 15,6 UHD / 4K OLED Touch", KategoriId = 2, ProducentId = 1, Pris = 21490, ProduktId = 8 },
                new Produkt { ProduktNavn= "Acer Chromebook R13 CB5-312T 13.3 FHD", KategoriId = 2, ProducentId = 2, Pris = 2495, ProduktId = 9 },
                new Produkt { ProduktNavn= "Apple MacBook Pro laptop 16 1TB MVV med touch bar", KategoriId = 2, ProducentId = 3, Pris = 21999, ProduktId = 10 },
                new Produkt { ProduktNavn= "Lenovo ThinkPad P53 15,6 Workstation Pro Full HD", KategoriId = 2, ProducentId = 4, Pris = 27990, ProduktId = 11 },
                new Produkt { ProduktNavn= "Dell Vostro 3590 15,6 Full HD", KategoriId = 2, ProducentId = 5, Pris = 5290, ProduktId = 12 },
                new Produkt { ProduktNavn= "Dell XPS 13 7390 13,3 UHD / 4K Touch", KategoriId = 2, ProducentId = 5, Pris = 13690, ProduktId = 13 },
                new Produkt { ProduktNavn= "HP Spectre x360 15-df1012no 15,6 UHD OLED touch", KategoriId = 2, ProducentId = 6, Pris = 17495, ProduktId = 14 },
                new Produkt { ProduktNavn= "Razer Blade Pro 17,3 UHD / 4K touch 120 Hz", KategoriId = 2, ProducentId = 10, Pris = 33495, ProduktId = 15 },
                new Produkt { ProduktNavn= "Samsung Galaxy S20 Ultra 5G 128GB Grå", KategoriId = 3, ProducentId = 8, Pris = 10499, ProduktId = 16 },
                new Produkt { ProduktNavn= "Samsung Galaxy A51 128GB Sort", KategoriId = 3, ProducentId = 8, Pris = 2789, ProduktId = 17 },
                new Produkt { ProduktNavn= "iPhone 11 Pro Max 64 GB Grå", KategoriId = 3, ProducentId = 3, Pris = 9649, ProduktId = 18 },
                new Produkt { ProduktNavn= "Apple iPhone SE 64GB Sort", KategoriId = 3, ProducentId = 3, Pris = 3699, ProduktId = 19 },
                new Produkt { ProduktNavn= "Samsung 75 QLED Smart TV QE75Q60R", KategoriId = 4, ProducentId = 8, Pris = 16990, ProduktId = 20 },
                new Produkt { ProduktNavn= "Samsung 75 QLED Smart TV QE75Q90R", KategoriId = 4, ProducentId = 8, Pris = 39990, ProduktId = 21 },
                new Produkt { ProduktNavn= "LG 55 UHD OLED Smart TV OLED55C9", KategoriId = 4, ProducentId = 9, Pris = 9990, ProduktId = 22 },
                new Produkt { ProduktNavn= "LG 48 OLED TV OLED48CX6", KategoriId = 4, ProducentId = 9, Pris = 11999, ProduktId = 23 },
                new Produkt { ProduktNavn= "Razer BlackWidow Elite Gaming Tastatur", KategoriId = 5, ProducentId = 10, Pris = 1399, ProduktId = 24 },
                new Produkt { ProduktNavn= "ASUS ROG Strix Scope Gaming Tastatur", KategoriId = 5, ProducentId = 1, Pris = 1099, ProduktId = 25 },
                new Produkt { ProduktNavn= "SteelSeries Apex Pro Gaming Tastatur", KategoriId = 5, ProducentId = 11, Pris = 1599, ProduktId = 26 },
                new Produkt { ProduktNavn= "Razer Basilisk Ultimate Trådløs Gaming Mus", KategoriId = 6, ProducentId = 10, Pris = 1349, ProduktId = 27 },
                new Produkt { ProduktNavn= "ASUS ROG Chakram Trådløs Gaming Mus", KategoriId = 6, ProducentId = 1, Pris = 1079, ProduktId = 28 },
                new Produkt { ProduktNavn= "Steelseries Rival 710 Gaming Mus", KategoriId = 6, ProducentId = 11, Pris = 799, ProduktId = 29 }
                );

            modelBuilder.Entity<Kunde>().HasData(
                new Kunde { Fornavn="Niels", Efternavn="Schultz", Adresse="HAHA", Email="niel862b@elevcampus.dk", Kodeord="Qwerty123", KundeId=1, Telefon=81616659 },
                new Kunde { Fornavn="FakeNiels", Efternavn="FakeSchultz", Adresse="FakeHAHA", Email="Fakeniel862b@elevcampus.dk", Kodeord="Qwerty123", KundeId=2, Telefon=95661618 }
                );

            modelBuilder.Entity<ProduktFoto>().HasData(
                new ProduktFoto { ProduktId= 23, ProduktFotoId=1, FotoUrl= "https://www.elgiganten.dk/image/dv_web_D180001002410624/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$fullsize$" },
                new ProduktFoto { ProduktId= 23, ProduktFotoId=2, FotoUrl= "https://www.elgiganten.dk/image/dv_web_D180001002410670/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$fullsize$" },
                new ProduktFoto { ProduktId= 23, ProduktFotoId=3, FotoUrl= "https://www.elgiganten.dk/image/dv_web_D180001002410669/153758/lg-48-cx-4k-oled-tv-oled48cx.jpg?$prod_all4one$" }
                );
        }



    }
}
