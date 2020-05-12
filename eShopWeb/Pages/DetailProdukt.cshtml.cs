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
        public List<Produkt> kurv = new List<Produkt>();

        public DetailProduktModel(IeShopService eShopService)
        {
            _eShopService = eShopService;
        }


        public IActionResult OnGet(int ProduktId)
        {
            ProduktKurv vareKurvKlasse = new ProduktKurv();
            
            Produkt = _eShopService.GetProduktById(ProduktId);
            kurv.Add(new Produkt 
            { 
                ProduktId = Produkt.ProduktId,
                ProduktNavn = Produkt.ProduktNavn,
                Pris = Produkt.Pris
            });
            vareKurvKlasse.vareKurv = kurv;
            //vareKurvKlasse.vareKurv.Add(Produkt);
            HttpContext.Session.Set("kurv", kurv);
            if (Produkt == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
    public class ProduktKurv
    {
        public List<Produkt> vareKurv { get; set; }
    }
}