using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
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
        public IQueryable<Kategori> GetKategorier()
        {
            return _context.Kategorier;
        }
        public IQueryable<Producent> GetProducenter()
        {
            return _context.Producenter;
        }
        public IQueryable<Produkt> GetProdukterByName(string name = null)
        {
            return _context.Produkter
                .Include(f => f.ProduktFoto)
                .Include(k => k.Kategori)
                .Include(p => p.Producent)
                .Where(r => string.IsNullOrEmpty(name) || r.ProduktNavn.StartsWith(name))
                .OrderBy(r => r.ProduktNavn);
        }

        public Produkt GetProduktById(int produktId)
        {
            return _context.Produkter
                .Include(p => p.Producent)
                .Include(f => f.ProduktFoto)
                .Include(k => k.Kategori)
                .SingleOrDefault(x => x.ProduktId == produktId);
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

        public IQueryable<Kunde> GetKunder()
        {
            return _context.Kunder;
        }
        public Kunde LoginCheck(string email, string kodeord)
        {
            var kunder = GetKunder();
            foreach (Kunde kunde in kunder)
            {
                if (kunde.Email == email && kunde.Kodeord == kodeord)
                {
                    return kunde;
                }
            }
            return null;
        }
    }
}
