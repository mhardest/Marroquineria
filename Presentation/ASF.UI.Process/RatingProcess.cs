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
    public class RatingProcess : ProcessComponent
    {
        const string baseURL = "rest/Rating/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Rating> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultRating;
        }

        public void Add(Rating rating)
        {
            var response = HttpPost<Rating>(baseURL + "Add/", rating, MediaType.Json);
        }

        public void Edit(Rating rating)
        {
            var response = HttpPost<Rating>(baseURL + "Edit/", rating, MediaType.Json);
        }

        public Rating FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultRating;
        }

        public void Delete(Rating rating)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + rating.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}