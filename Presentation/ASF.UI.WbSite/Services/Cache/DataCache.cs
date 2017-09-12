using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.WbSite.Constants;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Services.Cache
{
    public class DataCache
    {
        #region Singleton
        private static DataCache _instance;
        private static readonly object InstanceLock = new object();
        public static DataCache Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataCache();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        private readonly ICacheService _cacheService;
        private DataCache()
        {
            _cacheService = DependencyResolver.Current.GetService<ICacheService>();
        }

        public List<Category> CategoryList(string id)
        {
            var lista = _cacheService.GetOrAdd(CacheSetting.Category.Key, () =>
            {
                var cp = new CategoryProcess();
                return cp.SelectList();
            },
            CacheSetting.Category.SlidingExpiration);
            return lista;
        }
    }
}