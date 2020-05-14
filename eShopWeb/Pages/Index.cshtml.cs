using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
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

        public IEnumerable<Produkt> Produkter { get; set; }

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
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Det virker squ ik");
            }

            Log.CloseAndFlush();
        }
    }
}
