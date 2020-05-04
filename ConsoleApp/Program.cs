using System;
using System.Linq;
using DataLayer.Entities;
using ServiceLayer;
using ServiceLayer.ProduktService;
using ServiceLayer.ProduktService.Concrete;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new eShopContext())
            {

                #region pagingtest
                var produktService = new ListProduktService(context);
                var produkter = produktService.SortFilterPage(new SortFilterPageOptions
                {
                    OrderByOptions = OrderByOptions.Navn,
                    FilterBy = ProduktFilterBy.Navn,
                    FilterValue = "A",

                    PageNum = 2,
                    PageSize = 3
                }).ToList();

                foreach (ProduktListDto produkt in produkter)
                {
                    Console.WriteLine("\nproduktnavn: {0} \nproduktpris: {1}",
                        produkt.ProduktNavn,
                        produkt.Pris
                        );
                }
                #endregion
            }
        }
    }
}
