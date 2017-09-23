using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Countries.Controllers
{
    public class CountryController : Controller
    {
        // GET: Countries/Country
        public ActionResult Index()
        {
            CountryProcess countryprocess = new CountryProcess();
            var lista = countryprocess.SelectList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            var cp = new CountryProcess();
            cp.Add(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new CountryProcess();
            var country = cp.FindById(id);
            return View(country);
        }

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            var cp = new CountryProcess();
            cp.Edit(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new CountryProcess();
            var country = cp.FindById(id);
            return View(country);
        }

        [HttpPost]
        public ActionResult Delete(Country country)
        {
            var cp = new CountryProcess();
            cp.Delete(country);
            return RedirectToAction("Index");
        }
    }
}