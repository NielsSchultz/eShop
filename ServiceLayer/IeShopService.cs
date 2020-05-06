using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer
{
    public interface IeShopService
    {
        IQueryable<Produkt> GetProdukter();
        IQueryable<Produkt> GetProdukterByName(string name = null);
        Produkt GetProduktById(int produktId);
        Produkt Update(Produkt updatedProdukt);
        Produkt Add(Produkt newProdukt);
        Produkt Delete(int id);
        IQueryable<Kunde> GetKunder();
        Kunde LoginCheck(string email, string kodeord);
        int Commit();
    }
}
