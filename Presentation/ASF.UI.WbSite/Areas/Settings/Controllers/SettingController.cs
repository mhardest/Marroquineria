using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Settings.Controllers
{
    public class SettingController : Controller
    {
        // GET: Settings/Setting
        public ActionResult Index()
        {
            SettingProcess settingprocess = new SettingProcess();
            var lista = settingprocess.SelectList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Setting setting)
        {
            var cp = new SettingProcess();
            cp.Add(setting);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new SettingProcess();
            var setting = cp.FindById(id);
            return View(setting);
        }

        [HttpPost]
        public ActionResult Edit(Setting setting)
        {
            var cp = new SettingProcess();
            cp.Edit(setting);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new SettingProcess();
            var setting = cp.FindById(id);
            return View(setting);
        }

        [HttpPost]
        public ActionResult Delete(Setting setting)
        {
            var cp = new SettingProcess();
            cp.Delete(setting);
            return RedirectToAction("Index");
        }
    }
}