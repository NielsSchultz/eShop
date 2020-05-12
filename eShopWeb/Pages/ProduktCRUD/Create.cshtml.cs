using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.Entities;
using ServiceLayer;

namespace eShopWeb.Pages.ProduktCRUD
{
    public class CreateModel : PageModel
    {
        private readonly IeShopService _eShopService;
        [BindProperty]
        public Produkt Produkt { get; set; }
        public IEnumerable<SelectListItem> Kategorier { get; set; }
        public IEnumerable<SelectListItem> Producenter { get; set; }
        public CreateModel(IeShopService eShopService)
        {
            _eShopService = eShopService;
        }

        public IActionResult OnGet()
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
            return Page();
        }

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

            _eShopService.Add(Produkt);
            _eShopService.Commit();

            return RedirectToPage("./Index");
        }
    }
}
