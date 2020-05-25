using DataLayer.Entities;
using ServiceLayer.ProduktService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IeShopService
    {
        IQueryable<Produkt> GetProdukter();
        IQueryable<Kategori> GetKategorier();
        IQueryable<Producent> GetProducenter();
        IQueryable<Produkt> GetProdukterByName(string name = null);
        Task<Produkt> GetProduktById(int produktId);
        Task<ProduktDto> GetProduktDtoById(int produktId);
        Produkt Update(Produkt updatedProdukt);
        Task<Produkt> Add(Produkt newProdukt);
        Task<Produkt> Delete(int id);
        IQueryable<Kunde> GetKunder();
        Kunde LoginCheck(string email, string kodeord);
        int Commit();
    }
}
