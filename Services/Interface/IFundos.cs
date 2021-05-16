using webapiazurejulio.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace webapiazurejulio.Services
{
    public interface IFundos
    {
        Task<List<Fundos>> GetFundos(int ClientId);

        //Get FUNDOS 
    }
}
