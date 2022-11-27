using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using PersonApp.Helper;
using PersonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PersonApp.Services
{
    public class PersonService
    {
        private readonly HttpClient _httpClient = HelperFunctions.SetAPIControls();
        private readonly string path = "Person";

        public async Task<List<Person>> GetPersonList()
        {
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}{path}/list");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<List<Person>>();
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            var entityJson = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}{path}", entityJson);
            var json = await response.Content.ReadFromJsonAsync<Person>();
            return json;
        }

        public async Task DeletePerson(int personId)
        {
            Dictionary<string, string> queries = new Dictionary<string, string>();
            queries.Add(nameof(personId), personId.ToString());
            var response = await _httpClient.DeleteAsync(QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}{path}/delete", queries));
        }

        public async Task<Person> GetPerson(int personId)
        {
            Dictionary<string, string> queries = new Dictionary<string, string>();
            queries.Add(nameof(personId), personId.ToString());
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}{path}/person", queries));
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<Person>();
        }
    }
}