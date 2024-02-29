using Entity.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace GeTechnologiesMxApp.Service
{
    public class DirectorioService
    {
        private readonly HttpClient _httpClient;
        public DirectorioService() {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44377/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpContent guardaPersona(PersonaModel persona)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(persona), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync("api/Directorio/storePersona", stringContent).Result;
            if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
            {
                return response.Content;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public List<PersonaModel> buscaPersona()
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/Directorio/findPersonas").Result;
            if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
            {
                var personas = response.Content.ReadFromJsonAsync<List<PersonaModel>>().Result;
                return personas ?? new List<PersonaModel>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public PersonaModel? buscaPersonaByIdentificacion(string Identificacion)
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/Directorio/findPersonaByIdentificacion?Identificacion="+Identificacion).Result;
            if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
            {
                var res = response.Content.ReadFromJsonAsync<List<PersonaModel>>().Result;
                return res?.FirstOrDefault();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public bool eliminaPersona(string Identificacion)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync("api/Directorio/deletePersonaByIdentificacion?Identificacion=" + Identificacion).Result;
            if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
            {
                return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
