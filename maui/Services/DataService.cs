using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using System.Diagnostics;
using maui.Models;

namespace maui.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;
        private readonly String _baseAddress;
        private readonly String _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public DataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = "http://10.0.2.2:8000";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Property>> GetAllPropAsync()
        {
            List<Property> properties = new();

            

            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return properties;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/prop");

                if(response.IsSuccessStatusCode)
                {
                    String content = await response.Content.ReadAsStringAsync();

                    properties = JsonSerializer.Deserialize<List<Property>>(content, _jsonSerializerOptions);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return properties;
        }

        public async Task AddPropAsync(Property properties)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return;
            }

            try
            {
                String jsonProp = JsonSerializer.Serialize<Property>(properties, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonProp, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/prop", content);

                if(response.IsSuccessStatusCode)
                {

                }
                else
                {
                    
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return;
        }

        public async Task UpdatePropAsync(Property prop)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return;
            }

            try
            {
                String jsonProp = JsonSerializer.Serialize<Property>(prop, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonProp, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/prop/{prop.Id}", content);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return;
        }

        public async Task DeletePropAsync(int id)
        {
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/prop/{id}");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return;
        }
    }
}