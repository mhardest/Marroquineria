using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;

namespace ASF.UI.Process
{
    public class ClientProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        const string baseURL = "rest/Client/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Client> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultClient;
        }

        public void Add(Client client)
        {
            var response = HttpPost<Client>(baseURL + "Add/", client, MediaType.Json);
        }

        public void Edit(Client client)
        {
            var response = HttpPost<Client>(baseURL + "Edit/", client, MediaType.Json);
        }

        public Client FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultClient;
        }

        public Client FindByEmail(string email)
        {
            var response = HttpGet<FindResponse>(baseURL + "FindEmail/", new Dictionary<string, object>() { { "email", email } }, MediaType.Json);
            return response.ResultClient;
        }

        public void Delete(Client client)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + client.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}