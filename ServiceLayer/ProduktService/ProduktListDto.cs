using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServiceLayer.ProduktService
{
    public class ProduktListDto
    {
        public string ProduktNavn { get; set; }
        public int ProduktId { get; set; }
        [Column(TypeName = "Money")]
        public decimal Pris { get; set; }
    }
}
