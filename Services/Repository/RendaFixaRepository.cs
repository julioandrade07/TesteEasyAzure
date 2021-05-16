using webapiazurejulio.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace webapiazurejulio.Services
{
    public class RendaFixaRepository : IRendaFixa
    {


        public async Task<List<RendaFixa>> GetRendaFixa(int ClientId)
        {

            var url = @"http://www.mocky.io/v2/5e3429a33000008c00d96336";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;

                    ListRendaFixa businessunits = JsonConvert.DeserializeObject<ListRendaFixa>(result);

                    return businessunits.lcis;
                }
                else
                {

                }
            }

            return null;
        }
    }
}
