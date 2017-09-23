using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Products.Controllers
{
    public class ProductController : Controller
    {
        // GET: Products/Product
        public ActionResult Index()
        {
            ProductProcess productprocess = new ProductProcess();
            var lista = productprocess.SelectList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            var cp = new ProductProcess();
            cp.Add(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new ProductProcess();
            var product = cp.FindById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var cp = new ProductProcess();
            cp.Edit(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new ProductProcess();
            var product = cp.FindById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var cp = new ProductProcess();
            cp.Delete(product);
            return RedirectToAction("Index");
        }
    }
}