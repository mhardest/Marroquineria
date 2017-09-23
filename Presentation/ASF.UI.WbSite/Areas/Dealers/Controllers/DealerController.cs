using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Dealers.Controllers
{
    public class DealerController : Controller
    {
        // GET: Dealers/Dealer
        public ActionResult Index()
        {
            DealerProcess dealerprocess = new DealerProcess();
            var lista = dealerprocess.SelectList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dealer dealer)
        {
            var cp = new DealerProcess();
            cp.Add(dealer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new DealerProcess();
            var dealer = cp.FindById(id);
            return View(dealer);
        }

        [HttpPost]
        public ActionResult Edit(Dealer dealer)
        {
            var cp = new DealerProcess();
            cp.Edit(dealer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new DealerProcess();
            var dealer = cp.FindById(id);
            return View(dealer);
        }

        [HttpPost]
        public ActionResult Delete(Dealer dealer)
        {
            var cp = new DealerProcess();
            cp.Delete(dealer);
            return RedirectToAction("Index");
        }
    }
}