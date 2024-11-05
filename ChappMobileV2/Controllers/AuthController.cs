using ChappMobileV2.ModelsAPI;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System;
using ChappMobileV2.ModelsAPI.DTOs;
using System.Globalization;



namespace ChappMobileV2.Controllers
{
    public class AuthController
    {
        private HttpClient _client;
        public AuthController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://chapp.domcloud.dev/api/");
        }

        public async Task<List<string>> Register(DTO_User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("register/", content);

                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // En caso de éxito, intenta obtener un mensaje si está disponible
                    var messageObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                    string successMessage = messageObj.ContainsKey("message") ? messageObj["message"] : "Registro Exitoso";
                    return new List<string> { "Registro Exitoso", successMessage };
                }
                else
                {
                    // En caso de error, intenta deserializar errores de validación en formato Dictionary<string, List<string>>
                    var errors = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(responseContent);
                    var errorMessages = new List<string> { "Error de validación" };

                    // Construye una lista de mensajes de error específicos
                    foreach (var error in errors)
                    {
                        errorMessages.Add($"{error.Key.ToUpper()}: {string.Join(", ", error.Value)}");
                    }

                    return errorMessages;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<string> { "Excepción", e.Message };
            }
        }

    }
}
