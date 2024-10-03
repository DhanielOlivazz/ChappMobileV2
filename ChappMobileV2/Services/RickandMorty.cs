using ChappMobileV2.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChappMobileV2.Services
{
    class RickandMorty
    {
        private string _urlApi = "https://rickandmortyapi.com/api/character";
        public async Task<List<Characters>> GetPersonajeList()
        {
            
            var client = new HttpClient();
            var response = await client.GetAsync(_urlApi);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode resultNode = JsonNode.Parse(responseBody);
            JsonNode results = resultNode["results"];

            var personaje = JsonSerializer.Deserialize<List<Characters>>(results.ToString());

            return personaje;
        }

    }
}
