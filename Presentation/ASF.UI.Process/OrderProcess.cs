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
    public class OrderProcess : ProcessComponent
    {
        const string baseURL = "rest/Order/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultOrder;
        }

        public List<Order> SelectListXCliente(int ClienteId)
        {
            var response = HttpGet<AllResponse>(baseURL + "AllCliente", new Dictionary<string, object>() { { "ClienteId", ClienteId }}, MediaType.Json);
            return response.ResultOrder;
        }

        public void Add(Order order)
        {
            var response = HttpPost<Order>(baseURL + "Add/", order, MediaType.Json);
            
        }

        public void Edit(Order order)
        {
            var response = HttpPost<Order>(baseURL + "Edit/", order, MediaType.Json);
        }

        public Order FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultOrder;
        }

        public int FindMax()
        {
            var response = HttpGet<FindResponse>(baseURL + "FindMax/", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultOrderMax;
        }

        public void Delete(Order order)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + order.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}