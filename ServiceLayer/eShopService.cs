using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public class eShopService
    {
        private eShopContext _context;

        public eShopService(eShopContext context)
        {
            _context = context;
        }

        public void OpretKategori(string navn)
        {
            Kategori kategori = new Kategori { KategoriNavn = navn };
            _context.Kategorier.Add(kategori);
            _context.SaveChanges();
        }
    }
}
