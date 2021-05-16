using System;
using System.Collections.Generic;

namespace webapiazurejulio.Models.Data
{
    public class TesouroDireto
    {
        public decimal valorInvestido { get; set; }

        public decimal valorTotal { get; set; }

        public DateTime vencimento { get; set; }

        public DateTime dataDeCompra { get; set; }

        public decimal iof { get; set; }

        public string indice { get; set; }

        public string tipo { get; set; }

        public string nome { get; set; }
    }

    public class ListaTesouroDireto
    {
        public List<TesouroDireto> tds { get; set; }
    }
}
