using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ProduktService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class eShopService : IeShopService
    {
        private eShopContext _context;

        public eShopService(eShopContext context)
        {
            //context.Database.EnsureCreated();
            _context = context;
        }

        public IQueryable<Produkt> GetProdukter()
        {
            return _context.Produkter;
        }
        public async Task<ProduktDto> GetProduktDtoById(int id)
        {
            var produktdto = await _context.Produkter.Select(b =>
            new ProduktDto()
            {
                 ProduktNavn = b.ProduktNavn,
                 Pris = b.Pris,
                 ProduktId = b.ProduktId,
                 ProduktFoto = b.ProduktFoto.Select(u => u.FotoUrl).SingleOrDefault()
            }).SingleOrDefaultAsync(b => b.ProduktId == id);

            return produktdto;
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
                .Where(r => string.IsNullOrEmpty(name) || r.ProduktNavn.Contains(name) || r.Producent.ProducentNavn.Contains(name) || r.Kategori.KategoriNavn.Contains(name))
                .OrderBy(r => r.ProduktNavn);
        }

        public async Task<Produkt> GetProduktById(int produktId)
        {
            return await _context.Produkter
                .Include(p => p.Producent)
                .Include(f => f.ProduktFoto)
                .Include(k => k.Kategori)
                .SingleOrDefaultAsync(x => x.ProduktId == produktId);
        }

        public Produkt Update(Produkt updatedProdukt)
        {
            
            _context.Produkter.Update(updatedProdukt);
            Commit();
            return updatedProdukt;
        }

        public async Task<Produkt> Add(Produkt newProdukt)
        {
            await _context.Produkter.AddAsync(newProdukt);
            return newProdukt;
        }

        public int Commit()
        {
            _context.SaveChanges();
            return 0;
        }

        public async Task<Produkt> Delete(int id)
        {
            var produkt = await GetProduktById(id);
            if (produkt != null)
            {
                _context.Produkter.Remove(produkt);
            }
            Commit();
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
