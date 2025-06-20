using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Importar el Modelo y la librería Json
using appWeb06.Models;
using Newtonsoft.Json;


namespace appWeb06.Controllers
{
    public class InventarioController : Controller
    {
        //===================== Variables y Métodos ==========================

        static string jsonColeccionProducto = @"[
            {
                'IdProducto':1,
                'Descripcion':'Tablet Xioami',
                'Medida':'Unidad',
                'Precio':699.90,
                'Stock':10
            },
            {
                'IdProducto':2,
                'Descripcion':'Tablet Samsung',
                'Medida':'Unidad',
                'Precio':899.90,
                'Stock':15
            }]";



        // GET: Inventario
        public ActionResult Index()
        {
            List<Producto> temporal;
            if (string.IsNullOrEmpty(jsonColeccionProducto))
                temporal = new List<Producto>();
            else
                temporal = JsonConvert.DeserializeObject<List<Producto>>(jsonColeccionProducto);

            return View(temporal);
        }

		//=============================== CREATE =============================================

		// GET
		public ActionResult Create()
		{
			return View(new Producto());
		}

		[HttpPost]	public ActionResult Create(Producto reg)
		{
			string mensaje = "";
			if (!ModelState.IsValid) return View(reg);

			try
			{
				List<Producto> temporal = JsonConvert.DeserializeObject<List<Producto>>(jsonColeccionProducto);
				temporal.Add(reg);
				jsonColeccionProducto = JsonConvert.SerializeObject(temporal);
    			mensaje = "Producto Registrado";
			}
			catch (JsonException ex) { mensaje = ex.Message; }
			ViewBag.mensaje = mensaje;
			return View(reg);
		}

		//=============================== DETAILS =============================================

		public ActionResult Details(int id = 0)
		{
			List<Producto> temporal = JsonConvert.DeserializeObject<List<Producto>>(jsonColeccionProducto);
			Producto reg = temporal.FirstOrDefault(p => p.IdProducto == id);
			return View(reg);
		}
	}
}
