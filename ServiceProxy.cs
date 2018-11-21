using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SwapiApiChallenge.Common;
using SwapiApiChallenge.Interfaces;

namespace SwapiApiChallenge
{
    public class ServiceProxy : ISwapiServiceProxy
    {
        private readonly IAppConfigReader _configReader;
       
        public ServiceProxy(IAppConfigReader configReader)
        {
            _configReader = configReader ?? throw  new ArgumentNullException(nameof(configReader));
           
        }
        public async Task<ShipModel> Get(int id)
        {
            var apiUrl = _configReader.GetApiUrl();

            using (var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) })
            {
                var requestUrl = $"starships/{id}";
                var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                var response = await httpClient.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<ShipModel>(responseBody);
                   
                }
            }
            throw new Exception("Swapi not reachable");
        }

        public async Task<IEnumerable<ShipModel>> GetAll()
        {
            var apiUrl = _configReader.GetApiUrl();
            using (var httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) })
            {
                var requestUrl = $"starships/";
                var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                var response = await httpClient.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var allShipsModel = JsonConvert.DeserializeObject<AllShipsModel>(responseBody);
                    return allShipsModel.results;
                }
            }
            throw new Exception("Swapi not reachable");
            
        }
    }


 

}
