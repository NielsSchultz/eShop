using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class ProduktFoto
    {
        public int ProduktFotoId { get; set; }
        public int? ProduktId { get; set; }//FK
        public byte[] Foto { get; set; }
        public Produkt Produkt { get; set; }
    }
}
