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
    public class SerializaController : Controller
    {
        //===================== Variables y Métodos ==========================

        static string jsonProducto = @"{
            'IdProducto':1,
            'Descripcion':'Tablet Xioami',
            'Medida':'Unidad',
            'Precio':699.90,
            'Stock':10,
        }";

		//===================== Métodos para Vistas ==========================

		// GET: Serializa
		public ActionResult SerializaProducto(int op = 0)
        {
            if (op == 0) { return View(new Producto()); }
            else
            {
                Producto p = JsonConvert.DeserializeObject<Producto>(jsonProducto);
				return View(p);
			}
        }
        [HttpPost]
		public ActionResult SerializaProducto(Producto reg)
		{
            string mensaje = "";
            try { 
                jsonProducto = JsonConvert.SerializeObject(reg);
                mensaje = "Producto Serializado a JSON";
            }
            catch(JsonException ex) { mensaje = ex.Message; }
            ViewBag.mensaje = mensaje;  
            return View(reg);
		}
	}
}