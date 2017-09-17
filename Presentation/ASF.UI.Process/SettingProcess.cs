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
    public class SettingProcess : ProcessComponent
    {
        const string baseURL = "rest/Setting/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Setting> SelectList()
        {
            var response = HttpGet<AllResponse>(baseURL + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultSetting;
        }

        public void Add(Setting setting)
        {
            var response = HttpPost<Setting>(baseURL + "Add/", setting, MediaType.Json);
        }

        public void Edit(Setting setting)
        {
            var response = HttpPost<Setting>(baseURL + "Edit/", setting, MediaType.Json);
        }

        public Setting FindById(int id)
        {
            var response = HttpGet<FindResponse>(baseURL + "Find/", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ResultSetting;
        }

        public void Delete(Setting setting)
        {
            var response = HttpGet<FindResponse>(baseURL + "Remove/" + setting.Id, new Dictionary<string, object>(), MediaType.Json);
        }
    }
}