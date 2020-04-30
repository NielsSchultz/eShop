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
                // Tuples for DropDownControl i webclient
                //var blogFilterDropdownService = new BlogFilterDropdownService(context);
                //var dropdownItems = blogFilterDropdownService.GetFilterDropDownValues(BlogsFilterBy.ByOwner).ToList();

                //foreach (var item in dropdownItems)
                //{
                //    Console.WriteLine("{0} - {1}", item.Value, item.Text);
                //}




                var produktService = new ListProduktService(context);
                var produkter = produktService.SortFilterPage(new SortFilterPageOptions
                {
                    OrderByOptions = OrderByOptions.Navn,
                    //FilterBy = BlogsFilterBy.ByOwner,
                    //FilterValue = "Person 3"

                    PageNum = 1,
                    PageSize = 5
                }).ToList();

                foreach (ProduktListDto produkt in produkter)
                {
                    Console.WriteLine("\nproduktnavn: {0} \nproduktpris: {1}",
                        produkt.ProduktNavn,
                        produkt.Pris
                        );
                }
            }
        }
    }
}
