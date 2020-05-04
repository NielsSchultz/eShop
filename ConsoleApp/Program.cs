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

                #region Query for Filtering
                //var blogService = new ListBlogService(context);
                //var blogs = blogService.SortFilterPage(new SortFilterPageOptions
                //{
                //    OrderByOptions = OrderByOptions.SimpleOrder,
                //    FilterBy = BlogsFilterBy.ByRatings,
                //    FilterValue = "2"
                //}).ToList();

                //foreach (BlogListDto blog in blogs)
                //{
                //    Console.WriteLine("\nBlogId: {0} \nUrl: {1} \nRating: {2} \nOwner {3} \nNumber of Posts: {4}",
                //        blog.BlogId,
                //        blog.Url,
                //        blog.Rating,
                //        blog.Owner,
                //        blog.NumberOfPosts
                //        );
                //} 
                #endregion


                #region pagingtest
                var produktService = new ListProduktService(context);
                var produkter = produktService.SortFilterPage(new SortFilterPageOptions
                {
                    OrderByOptions = OrderByOptions.Navn,
                    //FilterBy = ProduktFilterBy.Navn,
                    //FilterValue = "ASUS",

                    PageNum = 1,
                    PageSize = 2
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
