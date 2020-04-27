using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Kunde
    {
        public int KundeId { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Adresse { get; set; }
        public int Telefon { get; set; }
        public ICollection<Ordre> Ordrer{get; set;}
    }
}
