using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProduktService
{
    public static class ProduktListDtoSelect
    {
        public static IQueryable<ProduktListDto> MapProduktToDto(this IQueryable<Produkt> produkter)
        {
            return produkter.Select(b => new ProduktListDto
            {
                ProduktNavn = b.ProduktNavn,
                ProduktId = b.ProduktId,
                Pris = b.Pris  
            });
        }
    }
}
