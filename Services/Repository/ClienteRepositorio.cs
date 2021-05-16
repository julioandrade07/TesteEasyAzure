using webapiazurejulio.Models.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapiazurejulio.Services
{
    public class ClienteRepositorio : ICliente
    {

        private FundosRepository _repositorioFundo { get; set; }
        private TesouroDiretoRepository _repositorioTesouroDireto { get; set; }
        private RendaFixaRepository _repositorioRendaFixa { get; set; }


        public ClienteRepositorio()
        {
            _repositorioFundo = new FundosRepository();

            _repositorioTesouroDireto = new TesouroDiretoRepository();

            _repositorioRendaFixa = new RendaFixaRepository();
        }


        public ClientePosicao GetCliente(int ClientId)
        {

            List<Task> tasksManager = new List<Task>();

            Task<List<Fundos>> taskFundo = _repositorioFundo.GetFundos(ClientId);

            Task<List<TesouroDireto>> taskTeosuro = _repositorioTesouroDireto.GetTesouro(ClientId);

            Task<List<RendaFixa>> TaskRendaFixa = _repositorioRendaFixa.GetRendaFixa(ClientId);

            tasksManager.AddRange(new List<Task>() { taskFundo, taskTeosuro, TaskRendaFixa });

            Task.WhenAll(tasksManager);

            return GerarPosicaoCliente(taskFundo.Result, taskTeosuro.Result, TaskRendaFixa.Result);

        }



        public ClientePosicao GerarPosicaoCliente(List<Fundos> fundos, List<TesouroDireto> tesouroDireto, List<RendaFixa> rendaFixa)
        {

            var ret = new ClientePosicao();

            ret.Investimentos.AddRange(fundos.Select(x => new Investimento(x)));

            ret.Investimentos.AddRange(tesouroDireto.Select(x => new Investimento(x)));

            ret.Investimentos.AddRange(rendaFixa.Select(x => new Investimento(x)));

            return ret;

        }
    }
}
