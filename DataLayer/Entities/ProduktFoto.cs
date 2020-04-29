using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class ProduktFoto
    {
        public int ProduktFotoId { get; set; }
        public int? ProduktId { get; set; }//FK
        [DataType(DataType.ImageUrl)]
        public string FotoUrl { get; set; }
        public Produkt Produkt { get; set; }

    }
}
