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
    public class CartItemProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        const string baseURL = "rest/CartItem/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CartItem> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultCartItem;
        }

        public void Add(CartItem cartitem)
        {
            var response = HttpPost<CartItem>(baseURL + "Add/", cartitem, MediaType.Json);
        }

        public void Edit(CartItem cartitem)
        {
            var response = HttpPost<CartItem>(baseURL + "Edit/", cartitem, MediaType.Json);
        }

        public CartItem FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultCartItem;
        }

        public void Delete(CartItem cartitem)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + cartitem.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}