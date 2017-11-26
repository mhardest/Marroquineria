using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Orders.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        
        // GET: Orders/Order
        public ActionResult Index()
        {
            OrderProcess orderprocess = new OrderProcess();
            var lista = orderprocess.SelectList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            var cp = new OrderProcess();
            cp.Add(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult VerPorCliente()
        {
            var emailusuario = User.Identity.Name;
            var clientproces = new ClientProcess();
            Client ClienteTest = new Client();
            ClienteTest = clientproces.FindByEmail(emailusuario);

            OrderProcess orderprocess = new OrderProcess();
            var lista = orderprocess.SelectListXCliente(ClienteTest.Id);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new OrderProcess();
            var order = cp.FindById(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            var cp = new OrderProcess();
            cp.Edit(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new OrderProcess();
            var order = cp.FindById(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Delete(Order order)
        {
            var cp = new OrderProcess();
            cp.Delete(order);
            return RedirectToAction("Index");
        }

        #region Create jquery - autocomplete

        ClientProcess clientprocess = new ClientProcess();

        public JsonResult GetClients(string Areas, string term = "")
        {
            var empleados = from Client in clientprocess.SelectList()
                            where Client.LastName.StartsWith(term)
                            select new { Client.LastName, Client.FirstName, Client.Id };
            return Json(empleados, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}