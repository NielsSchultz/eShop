using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServiceLayer.ProduktService.Dto
{
    public class ProduktDto
    {
        public string ProduktNavn { get; set; }
        public int ProduktId { get; set; }
        public int Styk { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Pris { get; set; }
        public string ProduktFoto { get; set; }
    }
}
