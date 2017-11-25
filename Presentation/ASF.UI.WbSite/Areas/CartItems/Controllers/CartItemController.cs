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
        public ActionResult VerCarrito()
        {
            if (Session["carrito"] == null)
            {
                
            }
            else
            {
                List<CartItem> compras = (List<CartItem>)Session["carrito"];
    
            }
            return View();
        }


        [HttpGet]
        public ActionResult AgregarCarrito(int Id, double Precio, string Descripcion)
        {
            if (Session["carrito"] == null)
            {
                List<CartItem> compras = new List<CartItem>();
                CartItem CI = new CartItem();
                CI.ProductId = Id;
                CI.Price = Precio;
                CI.Descripcion = Descripcion;
                CI.Quantity = 1;

                compras.Add(CI);

                Session["carrito"] = compras;
            }
            else
            {
                List<CartItem> compras = (List<CartItem>)Session["carrito"];
                int IndexExistente = getIndex(Id);

                if (IndexExistente == -1)
                {
                    CartItem CI = new CartItem();
                    CI.ProductId = Id;
                    CI.Price = Precio;
                    CI.Descripcion = Descripcion;
                    CI.Quantity = 1;
                    compras.Add(CI);
                }
                else
                {
                    compras[IndexExistente].Quantity++;
                }

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
                NuevaOrden.TotalPrice = compras.Sum(x => x.Price * x.Quantity);
                NuevaOrden.ItemCount = compras.Count;
                
                NuevaOrden.OrderNumber = 122;
                NuevaOrden.ChangedOn = DateTime.Now;
                NuevaOrden.CreatedOn = DateTime.Now;
                var emailusuario = User.Identity.Name;
                var clientproces = new ClientProcess();
                Client ClienteTest = new Client();
                ClienteTest = clientproces.FindByEmail(emailusuario);
                NuevaOrden.ClientId = ClienteTest.Id;


                var cp = new OrderProcess();
                cp.Add(NuevaOrden);

                var cpMax = new OrderProcess();
                var ultimoid = cpMax.FindMax();

                for (int i = 0; i < compras.Count; i++)
                {
                    OrderDetail NuevaDetalleOrden = new OrderDetail();
                NuevaDetalleOrden.OrderId = ultimoid;
                NuevaDetalleOrden.ProductId = compras[i].ProductId;
                NuevaDetalleOrden.Quantity = compras[i].Quantity;
                NuevaDetalleOrden.Price = compras[i].Price;
                NuevaDetalleOrden.ChangedOn = DateTime.Now;
                NuevaDetalleOrden.CreatedOn = DateTime.Now;

                var ODP = new OrderDetailProcess();
                ODP.Add(NuevaDetalleOrden);
                }


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