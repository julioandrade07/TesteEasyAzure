using webapiazurejulio.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace webapiazurejulio.Services
{
    public class TesouroDiretoRepository : ITesouroDireto
    {
        public async Task<List<TesouroDireto>> GetTesouro(int ClientId)
        {
            var url = @"http://www.mocky.io/v2/5e3428203000006b00d9632a";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;

                    ListaTesouroDireto businessunits = JsonConvert.DeserializeObject<ListaTesouroDireto>(result);

                    return businessunits.tds;
                }
                else
                {

                }
            }

            return null;
        }
    }
}
