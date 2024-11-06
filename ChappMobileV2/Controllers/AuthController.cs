﻿using ChappMobileV2.ModelsAPI;
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
        private string _token;
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
                    string message = messageObj.ContainsKey("message") ? messageObj["message"] : "Registro Exitoso";
                    return new List<string> { "Registro", message };
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

        public async Task<List<string>> Login(DTO_User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("login/", content);

                var responseContent = await response.Content.ReadAsStringAsync();
                

                if (response.IsSuccessStatusCode)
                {
                    // En caso de éxito, intenta obtener un mensaje si está disponible
                    var messageObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                    string message = messageObj.ContainsKey("message") ? messageObj["message"] : "Inicio de sesion exitoso";
                    _token = messageObj["token"];

                    //Guarda el token en el almacenamiento seguro
                    await SecureStorage.SetAsync("auth_token", _token);
                    return new List<string> {"LogIn",message};
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
                return new List<string> { "Excepción", e.Message };
            }
        }

    }
}
