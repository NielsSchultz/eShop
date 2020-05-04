using Microsoft.EntityFrameworkCore;
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
        Navn,
        [Display(Name = "Efter Pris...")]
        Pris
    }
    public static class ProduktListDtoFilter
    {
        public static IQueryable<ProduktListDto> FilterProduktBy(this IQueryable<ProduktListDto> produkter, ProduktFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
                return produkter;

            switch (filterBy)
            {
                case ProduktFilterBy.NoFilter:
                    return produkter;

                case ProduktFilterBy.Navn:
                    return produkter.Where(x => EF.Functions.Like(x.ProduktNavn , $"%{filterValue}%"));

                case ProduktFilterBy.Pris:
                    return produkter.Where(x => x.Pris <= int.Parse(filterValue));

                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
