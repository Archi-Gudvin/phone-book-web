using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using WpfApp.Models;

namespace WpfApp
{
    public class ClientDataApi
    {
        private HttpClient httpClient { get; set; }

        public ClientDataApi()
        {
            httpClient = new HttpClient();
            
            httpClient.BaseAddress = new Uri("https://localhost:44341/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        public IEnumerable<Client> GetClients()
        {
            var json = httpClient.GetStringAsync("clients").Result;
            return JsonConvert.DeserializeObject<IEnumerable<Client>>(json);  
        }

        public Client GetClient(int clientId)
        {
            var json = httpClient.GetStringAsync("clients/" + clientId).Result;
            return JsonConvert.DeserializeObject<Client>(json);
        }

        public async void AddClient(Client client)
        {
            await httpClient.PostAsJsonAsync("clients/", client);
        }

        public async void UpdateClient(Client client)
        {
            await httpClient.PutAsJsonAsync("clients/" + client.Id, client);
        }

        public async void DeleteClient(int clientId)
        {
            await httpClient.DeleteAsync("clients/" + clientId);
        }
    }
}
