using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        [Display(Name = "Kategori: ")]
        public string KategoriNavn { get; set; }
        public ICollection<Produkt> Produkter { get; set; }
    }
}
