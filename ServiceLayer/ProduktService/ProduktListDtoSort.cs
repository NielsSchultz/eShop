﻿using ServiceLayer.ProduktService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ServiceLayer
{
    public enum OrderByOptions
    {
        [Display(Name = "Sorter efter navn ↓...")]
        Navn,
        [Display(Name = "Sorter efter pris ↑")]
        Pris
    }
    public static class ProduktListDtoSort
    {
        public static IQueryable<ProduktListDto> OrderProduktBy(this IQueryable<ProduktListDto> blogs, OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.Navn:
                    return blogs.OrderBy(x => x.ProduktNavn);

                case OrderByOptions.Pris:
                    return blogs.OrderBy(x => x.Pris);


                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }
    }
}