using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace eShopWeb.Pages.ProduktCRUD
{
    public class IndexModel : PageModel
    {
        private readonly DataLayer.Entities.eShopContext _context;

        public IndexModel(DataLayer.Entities.eShopContext context)
        {
            _context = context;
        }

        public IList<Produkt> Produkt { get;set; }

        public async Task OnGetAsync()
        {
            Produkt = await _context.Produkter
                .Include(p => p.Kategori)
                .Include(p => p.ProduktFoto)
                .Include(p => p.Producent).ToListAsync();
        }
    }
}
