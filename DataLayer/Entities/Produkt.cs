﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Produkt
    {
        public string ProduktNavn { get; set; }
        public int ProduktId { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Pris { get; set; }
        public Kategori Kategori { get; set; }
        public int KategoriId { get; set; }
        public ICollection<ProduktFoto> ProduktFoto { get; set; }
        public ICollection<ProduktOrdrer> Ordrer { get; set; }
    }
}
