using appWeb04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appWeb04.Controllers
{
    public class InventarioController : Controller
    {

        private static List<Producto> productos = new List<Producto>()
        { new Producto() { IdProducto = 14546, descripcion = "Jabon", medida = "Unidad", precio = 3, stock = 28 } };

        // GET: Inventario
        public ActionResult Index()
        {
            return View(productos);
        }

        public ActionResult Create()
        {
            return View(new Producto());
        }

        [HttpPost]
        public ActionResult Create(Producto reg)
        {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }

            productos.Add(reg);
            ViewBag.mensaje = "Producto registrado";

            return View(reg);
        }

        public ActionResult Details(int id = 0)
        {
            Producto reg = productos.FirstOrDefault(p => p.IdProducto == id);

            return View(reg);
        }
    }
}