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
    public class CartProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        const string baseURL = "rest/Cart/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Cart> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultCart;
        }

        public void Add(Cart cart)
        {
            var response = HttpPost<Cart>(baseURL + "Add/", cart, MediaType.Json);
        }

        public void Edit(Cart cart)
        {
            var response = HttpPost<Cart>(baseURL + "Edit/", cart, MediaType.Json);
        }

        public Cart FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultCart;
        }

        public void Delete(Cart cart)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + cart.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}