using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace eShopWeb.Pages
{
    public class DetailProduktModel : PageModel
    {
        public Produkt Produkt { get; set; }
        private readonly IeShopService _eShopService;

        public DetailProduktModel(IeShopService eShopService)
        {
            _eShopService = eShopService;
        }


        public IActionResult OnGet(int ProduktId)
        {

            Produkt = _eShopService.GetProduktById(ProduktId);

            if (Produkt == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}