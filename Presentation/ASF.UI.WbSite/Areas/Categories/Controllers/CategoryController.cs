using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Categories.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Categories/Category
        public ActionResult Index()
        {
            CategoryProcess categoryprocess = new CategoryProcess();
            var lista = categoryprocess.SelectList();           
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            var cp = new CategoryProcess();
            cp.Add(category);
            return RedirectToAction("Index");
        }
    }
}