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
    public class ProductProcess : ProcessComponent
    {
        const string baseURL = "rest/Product/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Product> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultProduct;
        }

        public void Add(Product product)
        {
            var response = HttpPost<Product>(baseURL + "Add/", product, MediaType.Json);
        }

        public void Edit(Product product)
        {
            var response = HttpPost<Product>(baseURL + "Edit/", product, MediaType.Json);
        }

        public Product FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultProduct;
        }

        public void Delete(Product product)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + product.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}