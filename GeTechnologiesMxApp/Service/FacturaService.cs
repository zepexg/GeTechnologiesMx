using System.Net.Http.Headers;
using System.Net.Http;
using System;
using Entity.Model;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace GeTechnologiesMxApp.Service
{
    public class FacturaService
    {
        private readonly HttpClient _httpClient;
        public FacturaService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44377/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpContent guardaFactura(FacturaModel factura)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync("api/Factura/storeFactura", stringContent).Result;
            if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
            {
                return response.Content;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public List<FacturaModel> buscaFacturasByPersona(Guid Id)
        {
            HttpResponseMessage response = _httpClient.GetAsync("api/Factura/findFacturasByPersona?Persona=" + Id).Result;
            if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
            {
                var res = response.Content.ReadFromJsonAsync<List<FacturaModel>>().Result;
                return res ?? new List<FacturaModel>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
