using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Ratings
{
    public class RatingController : Controller
    {
        // GET: Ratings/Rating
        public ActionResult Index()
        {
            RatingProcess ratingprocess = new RatingProcess();
            var lista = ratingprocess.SelectList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rating rating)
        {
            var cp = new RatingProcess();
            cp.Add(rating);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new RatingProcess();
            var rating = cp.FindById(id);
            return View(rating);
        }

        [HttpPost]
        public ActionResult Edit(Rating rating)
        {
            var cp = new RatingProcess();
            cp.Edit(rating);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new RatingProcess();
            var rating = cp.FindById(id);
            return View(rating);
        }

        [HttpPost]
        public ActionResult Delete(Rating rating)
        {
            var cp = new RatingProcess();
            cp.Delete(rating);
            return RedirectToAction("Index");
        }
    }
}