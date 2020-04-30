using DataLayer.Entities;
using DataLayer.Queryobjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProduktService.Concrete
{
    public class ListProduktService
    {
        private readonly eShopContext _context;

        public ListProduktService(eShopContext context)
        {
            _context = context;
        }

        public IQueryable<ProduktListDto> SortFilterPage(SortFilterPageOptions options)
        {
            var produkterQuery = _context.Produkter
                .AsNoTracking()
                .MapProduktToDto()
                .OrderProduktBy(options.OrderByOptions)
                .FilterProduktBy(options.FilterBy, options.FilterValue);

            options.SetupRestOfDto(produkterQuery);                             // Added
            return produkterQuery.Page(options.PageNum - 1, options.PageSize);  // Added
        }
    }
}
