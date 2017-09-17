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
    public class OrderNumberProcess : ProcessComponent
    {
        const string baseURL = "rest/OrderNumber/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderNumber> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultOrderNumber;
        }

        public void Add(OrderNumber ordernumber)
        {
            var response = HttpPost<OrderNumber>(baseURL + "Add/", ordernumber, MediaType.Json);
        }

        public void Edit(OrderNumber ordernumber)
        {
            var response = HttpPost<OrderNumber>(baseURL + "Edit/", ordernumber, MediaType.Json);
        }

        public OrderNumber FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultNumber;
        }

        public void Delete(OrderNumber ordernumber)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + ordernumber.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}