using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Producent
    {
        public int ProducentId { get; set; }
        public ICollection<Produkt> Produkter { get; set; }
        public string ProducentNavn { get; set; }
    }
}
