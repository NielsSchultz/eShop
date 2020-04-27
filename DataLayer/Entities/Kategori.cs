using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriNavn { get; set; }
        public ICollection<Produkt> Produkter { get; set; }
    }
}
