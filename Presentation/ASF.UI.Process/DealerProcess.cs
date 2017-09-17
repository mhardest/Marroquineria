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
    public class DealerProcess : ProcessComponent
    {
        const string baseURL = "rest/Dealer/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Dealer> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultDealer;
        }

        public void Add(Dealer dealer)
        {
            var response = HttpPost<Dealer>(baseURL + "Add/", dealer, MediaType.Json);
        }

        public void Edit(Dealer dealer)
        {
            var response = HttpPost<Dealer>(baseURL + "Edit/", dealer, MediaType.Json);
        }

        public Dealer FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultDealer;
        }

        public void Delete(Dealer dealer)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + dealer.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}