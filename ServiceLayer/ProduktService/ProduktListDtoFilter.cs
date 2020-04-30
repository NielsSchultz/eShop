using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProduktService
{
    public enum ProduktFilterBy
    {
        [Display(Name = "All")]
        NoFilter = 0,
        [Display(Name = "Efter Navn...")]
        ByOwner,
        [Display(Name = "Efter Pris...")]
        ByRatings
    }
    public static class ProduktListDtoFilter
    {
        public static IQueryable<ProduktListDto> FilterProduktBy(this IQueryable<ProduktListDto> blogs, ProduktFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
                return blogs;

            switch (filterBy)
            {
                case ProduktFilterBy.NoFilter:
                    return blogs;

                case ProduktFilterBy.ByOwner:
                    return blogs.Where(x => x.ProduktNavn == filterValue);

                case ProduktFilterBy.ByRatings:
                    return blogs.Where(x => x.Pris >= int.Parse(filterValue));

                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
