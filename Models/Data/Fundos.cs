using System;
using System.Collections.Generic;

namespace webapiazurejulio.Models.Data
{
    public class Fundos
    {

        public decimal capitalInvestido { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime dataResgate { get; set; }
        public DateTime dataCompra { get; set; }
        public decimal iof { get; set; }
        public string nome { get; set; }
        public decimal totalTaxas { get; set; }
        public int quantity { get; set; }

    }
    public class FundosList
    {
        public List<Fundos> fundos { get; set; }
    }
}
