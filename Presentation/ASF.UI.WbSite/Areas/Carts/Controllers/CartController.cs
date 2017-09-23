using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Carts.Controllers
{
    public class CartController : Controller
    {
        // GET: Carts/Cart
        public ActionResult Index()
        {
            CartProcess cartprocess = new CartProcess();
            var lista = cartprocess.SelectList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cart cart)
        {
            var cp = new CartProcess();
            cp.Add(cart);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new CartProcess();
            var cart = cp.FindById(id);
            return View(cart);
        }

        [HttpPost]
        public ActionResult Edit(Cart cart)
        {
            var cp = new CartProcess();
            cp.Edit(cart);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new CartProcess();
            var cart = cp.FindById(id);
            return View(cart);
        }

        [HttpPost]
        public ActionResult Delete(Cart cart)
        {
            var cp = new CartProcess();
            cp.Delete(cart);
            return RedirectToAction("Index");
        }
    }
}