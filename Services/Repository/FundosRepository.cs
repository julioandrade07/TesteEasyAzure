using webapiazurejulio.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace webapiazurejulio.Services
{
    public class FundosRepository : IFundos
    {


        public async Task<List<Fundos>> GetFundos(int ClientId)
        {

            var url = @"http://www.mocky.io/v2/5e342ab33000008c00d96342";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;

                    FundosList businessunits = JsonConvert.DeserializeObject<FundosList>(result);

                    return businessunits.fundos;
                }

            }

            return null;
        }
    }
}
