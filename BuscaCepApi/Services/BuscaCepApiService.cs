using BuscaCepApi.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCepApi.Services
{
   public class BuscaCepApiService
    {
        public async Task<BuscaCepApic> GetBuscaCepApicRandom(string Cep)
        {
            var url = BucaCepApicPath.GetRandom(Cep);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var contentBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<BuscaCepApic>(contentBody);
                }
            }
            return null;
        }
    }
    public static class BucaCepApicPath
    {
        public static string GetRandom(string Cep)
        {
            var endereco = $"https://viacep.com.br/ws/{Cep}/json/";
            return endereco;
        }
    }
}
