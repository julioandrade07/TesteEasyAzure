using webapiazurejulio.Models.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace webapiazurejulio.Services
{
    public interface IRendaFixa
    {
        Task<List<RendaFixa>> GetRendaFixa(int ClientId);

    }
}
