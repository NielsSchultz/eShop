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
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Produkt Produkt { get; set; }
        private readonly IeShopService _eShopService;
        public DeleteModel(IeShopService eShopService)
        {
            _eShopService = eShopService;
        }

        public async Task<IActionResult> OnGet(int? produktid)
        {
            if (produktid == null)
            {
                return NotFound();
            }

            Produkt = await _eShopService.GetProduktById(produktid.Value);

            if (Produkt == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int? produktid)
        {

            Produkt = await _eShopService.GetProduktById(produktid.Value);

            if (Produkt != null)
            {
                await _eShopService.Delete(Produkt.ProduktId);
                _eShopService.Commit();
            }

            return RedirectToPage("./Index");
        }
    }
}
