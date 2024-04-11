using BankingRemoteApi.Models;
using BankingRemoteCore.Models;
using BankingRemoteMaui.Config;
using BankingRemoteMaui.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoREST.Services;

namespace BankingRemoteMaui.Services
{
    public class BankingService : IBankingService
    {
        private HttpClient _client;
        private IHttpsClientHandlerService _httpsClientHandlerService;
        private ISettings _settings;

        public BankingService(IHttpsClientHandlerService service, ISettings settings)
        {
            _settings = settings;
#if DEBUG
            _httpsClientHandlerService = service;
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                _client = new HttpClient(handler);
            else
                _client = new HttpClient();
#else
            _client = new HttpClient();
#endif

            _client.DefaultRequestHeaders.Add("Accept", "application/json");

        }

        public async Task<List<Client>> GetAllClients()
        {
            var response = await _client.GetAsync(new Uri(_settings.ServerAddress + _settings.ClientControllerRoute));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(content);

                return clients;
            }

            return new List<Client>();
        }

        public async Task<Client> UpdateClient(Client client)
        {
            var jsonClient = JsonConvert.SerializeObject(client);

            var requestContent = new StringContent(jsonClient, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(new Uri(_settings.ServerAddress + _settings.ClientControllerRoute), requestContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var responseClient = JsonConvert.DeserializeObject<Client>(responseContent);

                return responseClient;
            }

            return null;
        }

        public async Task<Client> GetClientById(int id)
        {
            var response = await _client.GetAsync(new Uri(_settings.ServerAddress + _settings.ClientControllerRoute)+"/"+id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var client = JsonConvert.DeserializeObject<Client>(content);

                return client;
            }

            return null;
        }

        public async Task<List<Transaction>> GetTransactionsByBankAccountId(int bankAccountId)
        {
            var response = await _client.GetAsync(new Uri(_settings.ServerAddress + _settings.TransactionControllerRoute) + "/" + bankAccountId);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var transactions = JsonConvert.DeserializeObject<List<Transaction>> (content);

                return transactions;
            }

            return null;
        }

        public async Task<Client> VerifyLogin(Auth auth)
        {
            var jsonAuth = JsonConvert.SerializeObject(auth);

            var requestContent = new StringContent(jsonAuth, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(new Uri(_settings.ServerAddress + _settings.AuthControllerRoute), requestContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var responseClient = JsonConvert.DeserializeObject<Client>(responseContent);

                return responseClient;
            }

            return null;
        }


    }
}
