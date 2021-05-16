using webapiazurejulio.Models.Data;
using System.Collections.Generic;

namespace webapiazurejulio.Models.Response
{
    public class ClienteResponse
    {

        public ClienteResponse(ClientePosicao clientePosicao)
        {

            this.Investimentos = clientePosicao.Investimentos;
            this.ValorTotal = clientePosicao.ValorTotal;
        }

        public decimal ValorTotal { get; set; }

        public List<Investimento> Investimentos { get; set; }



    }
}
