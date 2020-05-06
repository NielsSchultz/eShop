using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceLayer;

namespace eShopWeb.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        public IEnumerable<Produkt> Produkter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        private readonly IeShopService _eShopService;

        public IndexModel(IeShopService eShopService)
        {
            _eShopService = eShopService;
        }

        public void OnGet()
        {
            Produkter = _eShopService.GetProdukterByName(SearchTerm).ToList();
        }
    }
}
