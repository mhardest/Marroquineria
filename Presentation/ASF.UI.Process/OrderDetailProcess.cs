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
    public class OrderDetailProcess : ProcessComponent
    {
        const string baseURL = "rest/OrderDetail/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderDetail> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultOrderDetail;
        }

        public void Add(OrderDetail orderdetail)
        {
            var response = HttpPost<OrderDetail>(baseURL + "Add/", orderdetail, MediaType.Json);
        }

        public void Edit(OrderDetail orderdetail)
        {
            var response = HttpPost<OrderDetail>(baseURL + "Edit/", orderdetail, MediaType.Json);
        }

        public OrderDetail FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultOrderDetail;
        }

        public void Delete(OrderDetail orderdetail)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + orderdetail.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}