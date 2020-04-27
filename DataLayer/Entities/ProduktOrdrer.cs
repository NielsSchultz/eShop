using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class ProduktOrdrer
    {
        public int ProduktId { get; set; }
        public int OrdreId { get; set; }
        public Ordre Ordrer { get; set; }
        public Produkt Produkter { get; set; }
    }
}
