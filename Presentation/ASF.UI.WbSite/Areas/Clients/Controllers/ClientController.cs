using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Clients.Controllers
{
    public class ClientController : Controller
    {
        // GET: Clients/Client
        public ActionResult Index()
        {
            ClientProcess clientprocess = new ClientProcess();
            var lista = clientprocess.SelectList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            var cp = new ClientProcess();
            cp.Add(client);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new ClientProcess();
            var client = cp.FindById(id);
            return View(client);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            var cp = new ClientProcess();
            cp.Edit(client);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new ClientProcess();
            var client = cp.FindById(id);
            return View(client);
        }

        [HttpPost]
        public ActionResult Delete(Client client)
        {
            var cp = new ClientProcess();
            cp.Delete(client);
            return RedirectToAction("Index");
        }
    }
}