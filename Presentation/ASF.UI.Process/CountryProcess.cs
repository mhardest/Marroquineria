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
    public class CountryProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        const string baseURL = "rest/Country/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Country> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultCountry;
        }

        public void Add(Country country)
        {
            var response = HttpPost<Country>(baseURL + "Add/", country, MediaType.Json);
        }

        public void Edit(Country country)
        {
            var response = HttpPost<Country>(baseURL + "Edit/", country, MediaType.Json);
        }

        public Country FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultCountry;
        }

        public void Delete(Country country)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + country.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}