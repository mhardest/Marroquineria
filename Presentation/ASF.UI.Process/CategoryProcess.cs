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
    public class CategoryProcess : ProcessComponent
    {
        const string baseURL = "rest/Category/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Category/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public void Add(Category category)
        {
            var response = HttpPost<Category>(baseURL + "Add/", category, MediaType.Json);
        }

        public void Edit(Category category)
        {
            var response = HttpPost<Category>(baseURL + "Edit/", category, MediaType.Json);
        }

        public Category FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id} }, MediaType.Json);
            return response.Result;
        }
    }
}
