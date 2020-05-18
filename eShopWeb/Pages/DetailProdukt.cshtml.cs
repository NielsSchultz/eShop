using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Entities;
using eShopWeb.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace eShopWeb.Pages
{
    public class DetailProduktModel : PageModel
    {
        public Produkt Produkt { get; set; }
        private readonly IeShopService _eShopService;
        //public List<Produkt> kurv = new List<Produkt>();

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
        public IActionResult OnPost(int ProduktId)
        {
            if (ModelState.IsValid)
            {
                Produkt = _eShopService.GetProduktById(ProduktId);
                if (Produkt == null)
                {
                    return NotFound();
                }
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

                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}