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
using ServiceLayer.ProduktService.Dto;

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
                Kategorier =  _eShopService.GetKategorier().ToList();
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

            Log.Information("Loading index OnPostProducent");

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

            Log.Information("Loading index OnPostKategori");

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
        public async void OnPostAddToCart(int produktId)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Loading index OnPostAddToCart");

            if (ModelState.IsValid)
            {
                ProduktDto ProduktDto = await _eShopService.GetProduktDtoById(produktId);
                List<ProduktDto> kurv = HttpContext.Session.Get<List<ProduktDto>>("kurv");
                if (kurv == null)
                {
                    kurv = new List<ProduktDto>();
                }
                //kurv.Add(Produkt);
                kurv.Add(new ProduktDto
                {
                    ProduktId = ProduktDto.ProduktId,
                    ProduktNavn = ProduktDto.ProduktNavn,
                    Pris = ProduktDto.Pris,
                    Styk = ProduktDto.Styk += 1
                });
                HttpContext.Session.Set("kurv", kurv);

            }
            try
            {
                Produkter = await _eShopService.GetProdukterByName().ToListAsync();
                Kategorier = await _eShopService.GetKategorier().ToListAsync();
                Producenter = await _eShopService.GetProducenter().ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Det virker squ ik(OnPostAddToCart)");
            }

            Log.CloseAndFlush();
        }
    }
}
