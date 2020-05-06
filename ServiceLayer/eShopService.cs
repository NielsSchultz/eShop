using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer
{
    public class eShopService : IeShopService
    {
        private eShopContext _context;

        public eShopService(eShopContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }

        public IQueryable<Produkt> GetProdukter()
        {
            return _context.Produkter;
        }

        public IQueryable<Produkt> GetProdukterByName(string name = null)
        {
            return _context.Produkter
                .Where(r => string.IsNullOrEmpty(name) || r.ProduktNavn.StartsWith(name))
                .OrderBy(r => r.ProduktNavn);
        }

        public Produkt GetProduktById(int produktId)
        {
            return _context.Produkter.Find(produktId);
        }

        public Produkt Update(Produkt updatedProdukt)
        {
            _context.Produkter.Update(updatedProdukt);
            

            return updatedProdukt;
        }

        public Produkt Add(Produkt newProdukt)
        {
            _context.Produkter.Add(newProdukt);
            return newProdukt;
        }

        public int Commit()
        {
            _context.SaveChanges();
            return 0;
        }

        public Produkt Delete(int id)
        {
            var produkt = GetProduktById(id);
            if (produkt != null)
            {
                _context.Produkter.Remove(produkt);
            }
            return produkt;
        }

    }
}
