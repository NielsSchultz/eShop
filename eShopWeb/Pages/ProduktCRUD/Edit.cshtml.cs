using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;
using ServiceLayer;
using System.Globalization;

namespace eShopWeb.Pages.ProduktCRUD
{
    public class EditModel : PageModel
    {
        private readonly IeShopService _eShopService;
        [BindProperty]
        public Produkt Produkt { get; set; }
        public IEnumerable<SelectListItem> Kategorier { get; set; }
        public IEnumerable<SelectListItem> Producenter { get; set; }
        public EditModel(IeShopService eShopService)
        {
            _eShopService = eShopService;
        }

        
        public IActionResult OnGet(int? produktid)
        {
            Kategorier = _eShopService.GetKategorier().Select(
                kategorinavn => new SelectListItem
                {
                    Value = kategorinavn.KategoriId.ToString(),
                    Text = kategorinavn.KategoriNavn
                }).ToList();

            Producenter = _eShopService.GetProducenter().Select(
                producentnavn => new SelectListItem
                {
                    Value = producentnavn.ProducentId.ToString(),
                    Text = producentnavn.ProducentNavn
                }).ToList();


            if (produktid != null)
            {
                Produkt = _eShopService.GetProduktById(produktid.Value);
            }
            

            if (Produkt == null)
            {
                return NotFound();
            }
           
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            Kategorier = _eShopService.GetKategorier().Select(
                kategorinavn => new SelectListItem
                {
                    Value = kategorinavn.KategoriId.ToString(),
                    Text = kategorinavn.KategoriNavn
                }).ToList();

            Producenter = _eShopService.GetProducenter().Select(
                producentnavn => new SelectListItem
                {
                    Value = producentnavn.ProducentId.ToString(),
                    Text = producentnavn.ProducentNavn
                }).ToList();


            if (!ModelState.IsValid)
            {
                return Page();
            }

            _eShopService.Update(Produkt);
            _eShopService.Commit();

            

            return RedirectToPage("./Index");
        }

    }
}
