using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.CartItems.Controllers
{
    public class CartItemController : Controller
    {
        // GET: CartItems/CartItem
        public ActionResult Index()
        {
            CartItemProcess cartitemprocess = new CartItemProcess();
            var lista = cartitemprocess.SelectList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CartItem cartitem)
        {
            var cp = new CartItemProcess();
            cp.Add(cartitem);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AgregarCarrito(int id)
        {
            if (Session["carrito"] == null)
            {
                List<CartItem> compras = new List<CartItem>();
                CartItem CI = new CartItem();
                CI.ProductId = id;
                CI.Quantity = 1;

                compras.Add(CI);

                Session["carrito"] = compras;
            }
            else
            {
                List<CartItem> compras = (List<CartItem>)Session["carrito"];
                int IndexExistente = getIndex(id);
                
                if (IndexExistente == -1)
                {
                    CartItem CI = new CartItem();
                    CI.ProductId = id;
                    CI.Quantity = 1;
                    compras.Add(CI);
                }
                else
                {
                    compras[IndexExistente].Quantity++;
                }
    

                Session["carrito"] = compras;
            }
            return View();
        }

        private int getIndex(int id)
        {
            List<CartItem> compras = (List<CartItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].ProductId == id)
                    return i;
            }
            return -1;
        }

        [HttpGet]
        public ActionResult Borrar(int id)
        {
            List<CartItem> compras = (List<CartItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            return View("AgregarCarrito");
        }

        [HttpGet]
        public ActionResult FinalizaCompra()
        {
            List<CartItem> compras = (List<CartItem>)Session["carrito"];
            if (compras != null && compras.Count > 0)
            {
                Order NuevaOrden = new Order();
                NuevaOrden.OrderDate = DateTime.Now;
                NuevaOrden.TotalPrice = compras.Sum(x =>  100 * x.Quantity);
                NuevaOrden.ItemCount = compras.Count;
                NuevaOrden.ClientId = 6275;
                NuevaOrden.OrderNumber = 122;
                NuevaOrden.ChangedOn = DateTime.Now;
                NuevaOrden.CreatedOn = DateTime.Now;

                var cp = new OrderProcess();
                cp.Add(NuevaOrden);

                var cpMax = new OrderProcess();
                var ultimoid = cpMax.FindMax();

                OrderDetail NuevaDetalleOrden = new OrderDetail();
                NuevaDetalleOrden.OrderId = ultimoid;
                NuevaDetalleOrden.ProductId = 2;
                NuevaDetalleOrden.Quantity = 1;
                NuevaDetalleOrden.Price = 100;
                NuevaDetalleOrden.ChangedOn = DateTime.Now;
                NuevaDetalleOrden.CreatedOn = DateTime.Now;

                var ODP = new OrderDetailProcess();
                ODP.Add(NuevaDetalleOrden);

            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new CartItemProcess();
            var cartitem = cp.FindById(id);
            return View(cartitem);
        }

        [HttpPost]
        public ActionResult Edit(CartItem cartitem)
        {
            var cp = new CartItemProcess();
            cp.Edit(cartitem);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new CartItemProcess();
            var cartitem = cp.FindById(id);
            return View(cartitem);
        }

        [HttpPost]
        public ActionResult Delete(CartItem cartitem)
        {
            var cp = new CartItemProcess();
            cp.Delete(cartitem);
            return RedirectToAction("Index");
        }
    }
}