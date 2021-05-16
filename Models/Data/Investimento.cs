using System;

namespace webapiazurejulio.Models.Data
{
    public class Investimento
    {

        #region Construtores

        public Investimento(RendaFixa investimento)
        {

            Nome = investimento.nome;

            ValorInvestido = investimento.capitalInvestido;

            ValorTotal = investimento.capitalAtual;

            Vencimento = investimento.vencimento;

            Ir = calcularIR(investimento.capitalAtual, investimento.capitalInvestido, TipoInvestimento.RendaFixa);

            ValorResgate = CalcularResgate(investimento.dataOperacao, investimento.vencimento, investimento.capitalAtual);
        }

        public Investimento(TesouroDireto investimento)
        {
            Nome = investimento.nome;

            ValorInvestido = investimento.valorInvestido;

            ValorTotal = investimento.valorTotal;

            Vencimento = investimento.vencimento;

            Ir = calcularIR(investimento.valorTotal, investimento.valorInvestido, TipoInvestimento.TesouroDireto);

            ValorResgate = CalcularResgate(investimento.dataDeCompra, investimento.vencimento, investimento.valorTotal);


        }

        public Investimento(Fundos investimento)
        {
            Nome = investimento.nome;

            ValorInvestido = investimento.capitalInvestido;

            ValorTotal = investimento.ValorAtual;

            Vencimento = investimento.dataResgate;

            Ir = calcularIR(investimento.ValorAtual, investimento.capitalInvestido, TipoInvestimento.Fundos);

            ValorResgate = CalcularResgate(investimento.dataCompra, investimento.dataResgate, investimento.ValorAtual);

        }

        #endregion

        #region Atributos
        public string Nome { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Ir { get; set; }
        public decimal ValorResgate { get; set; }

        #endregion

        #region Method

        private decimal calcularIR(decimal valorTotal, decimal valorInvestido, TipoInvestimento tipo)
        {
            decimal Rentabilidade = valorTotal - valorInvestido;

            decimal ImpostoRenda = 0;

            switch (tipo)
            {
                case TipoInvestimento.Fundos:
                    if (Rentabilidade > 0)
                        ImpostoRenda = Rentabilidade * 0.15M;
                    break;
                case TipoInvestimento.RendaFixa:
                    if (Rentabilidade > 0)
                        ImpostoRenda = Rentabilidade * 0.05M;
                    break;
                case TipoInvestimento.TesouroDireto:
                    if (Rentabilidade > 0)
                        ImpostoRenda = Rentabilidade * 0.10M;
                    break;
            }

            return ImpostoRenda;
        }

        private decimal CalcularResgate(DateTime dataOperacao, DateTime dataVencimento, decimal valorTotal)
        {

            double diasContrados = (dataVencimento - dataOperacao).TotalDays;

            double diasAtual = (DateTime.Now - dataOperacao).TotalDays;

            double proxmes = (DateTime.Now - DateTime.Now.AddMonths(-3)).TotalDays;

            decimal valorResgate;


            if (diasContrados > proxmes)
            {
                valorResgate = valorTotal - (valorTotal * 0.06M);
            }
            else if (diasAtual > (diasContrados / 2))
            {
                valorResgate = valorTotal - (valorTotal * 0.15M);
            }
            else
            {
                valorResgate = valorTotal - (valorTotal * 0.30M);
            }

            return valorResgate;
        }

        #endregion


    }
}
