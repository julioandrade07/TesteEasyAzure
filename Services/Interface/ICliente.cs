using webapiazurejulio.Models.Data;

namespace webapiazurejulio.Services
{
    public interface ICliente
    {
        ClientePosicao GetCliente(int ClientId);
    }
}
