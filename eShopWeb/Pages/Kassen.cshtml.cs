using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using eShopWeb.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace eShopWeb.Pages
{
    public class KassenModel : PageModel
    {
        private readonly IeShopService _eShopService;
        public Kunde Kunden { get; set; }
        public List<Produkt> vareKurv = new List<Produkt>();
        public KassenModel(IeShopService eShopService)
        {
            _eShopService = eShopService;
        }
        public IActionResult OnGet()
        {
            vareKurv = HttpContext.Session.Get<List<Produkt>>("kurv");
            Kunden = _eShopService.LoginCheck("niel862b@elevcampus.dk", "Qwerty123");
            return Page();
        }
    }
}
