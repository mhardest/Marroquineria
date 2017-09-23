using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.OrderNumbers.Controllers
{
    public class OrderNumberController : Controller
    {
        // GET: OrderNumbers/OrderNumber
        public ActionResult Index()
        {
            OrderNumberProcess categoryprocess = new OrderNumberProcess();
            var lista = categoryprocess.SelectList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderNumber ordernumber)
        {
            var cp = new OrderNumberProcess();
            cp.Add(ordernumber);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new OrderNumberProcess();
            var ordernumber = cp.FindById(id);
            return View(ordernumber);
        }

        [HttpPost]
        public ActionResult Edit(OrderNumber ordernumber)
        {
            var cp = new OrderNumberProcess();
            cp.Edit(ordernumber);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new OrderNumberProcess();
            var ordernumber = cp.FindById(id);
            return View(ordernumber);
        }

        [HttpPost]
        public ActionResult Delete(OrderNumber ordernumber)
        {
            var cp = new OrderNumberProcess();
            cp.Delete(ordernumber);
            return RedirectToAction("Index");
        }
    }
}