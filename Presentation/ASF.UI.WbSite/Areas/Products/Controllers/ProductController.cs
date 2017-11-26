using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;
using System.IO;

namespace ASF.UI.WbSite.Areas.Products.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Products/Product
        public ActionResult Index()
        {
            ProductProcess productprocess = new ProductProcess();
            var lista = productprocess.SelectList();
            return View(lista);
        }


        public ActionResult Shop()
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
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            var cp = new ProductProcess();

            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();

                    product.Image = array;
                }

            }

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

        
         public ActionResult Images(int id)
         {
             var cp = new ProductProcess();
             byte[] imageData = cp.FindById(id).Image;
             if (imageData != null)
             {
                 return File(imageData, "image/png", "image/jpg");
             }
             return null;

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