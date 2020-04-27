using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Ordre
    {
        public int OrdreId { get; set; }
        public int KundeId { get; set; } //FK
        public Kunde Kunde { get; set; }
        public DateTime BestillingsDato { get; set; }
        public ICollection<ProduktOrdrer> Produkter { get; set; }
    }
}
