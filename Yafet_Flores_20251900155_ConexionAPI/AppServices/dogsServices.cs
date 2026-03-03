using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Yafet_Flores_20251900155_ConexionAPI.Modelo;

namespace Yafet_Flores_20251900155_ConexionAPI.AppServices
{
    public class dogsServices
    {
        private readonly HttpClient _httpClient;

        public dogsServices()
        {
            // La URL debe ser la del servidor de la API, no la de la documentación
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://dogapi.dog/api/v1/");
        }

        public async Task<List<string>> GetDogFacts(int number = 1)
        {
            try
            {
                // El endpoint correcto es "facts" y acepta el parámetro "number"
                HttpResponseMessage httpResponse = await _httpClient.GetAsync($"facts?number={number}");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    return new List<string>();
                }

                var apiResponse = await httpResponse.Content.ReadFromJsonAsync<dogs>();

                // Retornamos la lista de hechos (facts)
                return apiResponse?.facts ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de conexión: {ex.Message}");
                return new List<string>();
            }
        }
    }
}
