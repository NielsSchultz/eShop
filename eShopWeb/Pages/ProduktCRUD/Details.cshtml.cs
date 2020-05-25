using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;
using ServiceLayer;

namespace eShopWeb.Pages.ProduktCRUD
{
    public class DetailsModel : PageModel
    {
        public Produkt Produkt { get; set; }
        private readonly IeShopService _eShopService;

        public DetailsModel(IeShopService eShopService)
        {
            _eShopService = eShopService;
        }


        public async Task<IActionResult> OnGetAsync(int ProduktId)
        {
            
            Produkt = await _eShopService.GetProduktById(ProduktId);

            if (Produkt == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
