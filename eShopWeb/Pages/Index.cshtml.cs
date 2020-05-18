using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using eShopWeb.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using ServiceLayer;

namespace eShopWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]
        public IEnumerable<Produkt> Produkter { get; set; }
        [BindProperty(SupportsGet = true)]
        public IEnumerable<Kategori> Kategorier { get; set; }
        [BindProperty(SupportsGet = true)]
        public IEnumerable<Producent> Producenter { get; set; }
        public Produkt Produkt { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 9;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        private readonly IeShopService _eShopService;

        public IndexModel(IeShopService eShopService, ILogger<IndexModel> logger)
        {
            _eShopService = eShopService;
            _logger = logger;
        }

        public void OnGet()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();



            Log.Information("Loading index");

            try
            {
                Produkter = _eShopService.GetProdukterByName(SearchTerm).ToList();
                Kategorier = _eShopService.GetKategorier().ToList();
                Producenter = _eShopService.GetProducenter().ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Det virker squ ik(OnGet)");
            }

            Log.CloseAndFlush();
        }
        public void OnPostProducent(string producentNavn)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Loading index");

            try
            {
                Produkter = _eShopService.GetProdukterByName(producentNavn).ToList();
                Kategorier = _eShopService.GetKategorier().ToList();
                Producenter = _eShopService.GetProducenter().ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Det virker squ ik(OnPostProducent)");
            }

            Log.CloseAndFlush();
        }
        public void OnPostKategori(string kategoriNavn)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Loading index");

            try
            {
                Produkter = _eShopService.GetProdukterByName(kategoriNavn).ToList();
                Kategorier = _eShopService.GetKategorier().ToList();
                Producenter = _eShopService.GetProducenter().ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Det virker squ ik(OnPostKategori)");
            }

            Log.CloseAndFlush();
        }
        public void OnPostAddToCart(int produktId)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Loading index");

            if (ModelState.IsValid)
            {
                Produkt = _eShopService.GetProduktById(produktId);
                List<Produkt> kurv = HttpContext.Session.Get<List<Produkt>>("kurv");
                if (kurv == null)
                {
                    kurv = new List<Produkt>();
                }
                //kurv.Add(Produkt);
                kurv.Add(new Produkt
                {
                    ProduktId = Produkt.ProduktId,
                    ProduktNavn = Produkt.ProduktNavn,
                    Pris = Produkt.Pris
                });
                HttpContext.Session.Set("kurv", kurv);

            }
            try
            {
                Produkter = _eShopService.GetProdukterByName().ToList();
                Kategorier = _eShopService.GetKategorier().ToList();
                Producenter = _eShopService.GetProducenter().ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Det virker squ ik(OnPostKategori)");
            }

            Log.CloseAndFlush();
        }
    }
}
