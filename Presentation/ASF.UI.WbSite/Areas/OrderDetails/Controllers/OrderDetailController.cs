using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.OrderDetails.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: OrderDetails/OrderDetail
        public ActionResult Index()
        {
            OrderDetailProcess orderdetailprocess = new OrderDetailProcess();
            var lista = orderdetailprocess.SelectList();
            return View(lista);
        }


        public ActionResult VerOrderDetalle(int OrderId)
        {
            OrderDetailProcess orderdetailprocess = new OrderDetailProcess();
            var lista = orderdetailprocess.SelectListOrder(OrderId);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderDetail orderdetail)
        {
            var cp = new OrderDetailProcess();
            cp.Add(orderdetail);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new OrderDetailProcess();
            var orderdetail = cp.FindById(id);
            return View(orderdetail);
        }

        [HttpPost]
        public ActionResult Edit(OrderDetail orderdetail)
        {
            var cp = new OrderDetailProcess();
            cp.Edit(orderdetail);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new OrderDetailProcess();
            var orderdetail = cp.FindById(id);
            return View(orderdetail);
        }

        [HttpPost]
        public ActionResult Delete(OrderDetail orderdetail)
        {
            var cp = new OrderDetailProcess();
            cp.Delete(orderdetail);
            return RedirectToAction("Index");
        }
    }
}