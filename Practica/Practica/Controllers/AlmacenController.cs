using Practica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica.Controllers
{
    public class AlmacenController : Controller
    {
        private static List<Productos> productos = new List<Productos>()
        {
            new Productos() {IdProducto = 789, NombreProducto = "Jabon", DescripcionProducto = "Para manos", PrecioProducto = 2.5, StockProducto = 35}
        };

        // GET: Almacen
        public ActionResult Index()
        {
            return View(productos);
        }

        public ActionResult ProductsView(Productos reg)
        {
            return View(reg);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Productos reg)
        {
            productos.Add(reg);
            return View(reg);
        }
    }
}