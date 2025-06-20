using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Importar
using System.IO;
using Newtonsoft.Json;
using appWeb07.Models;
using System.Runtime.InteropServices.ComTypes;

namespace appWeb07.Controllers
{
    public class PadronController : Controller
    {
        //================================ Variabes y Métodos =========================================
        static List<Proveedor> proveedores = new List<Proveedor>();
        static string ruta = "~/folderJson/proveedores.json";


		// GET: Padron : Página 189
		public ActionResult Index()
		{
			string ruta = @"~/folderJson/proveedores.json";

			string rutaFisica = Server.MapPath(ruta);

			if (!System.IO.File.Exists(rutaFisica))
			{
				return View(proveedores);
			}
			else
			{
				using (FileStream f = new FileStream(rutaFisica, FileMode.Open))
				using (StreamReader lector = new StreamReader(f))
				{
					proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(lector.ReadToEnd());
				}

				return View(proveedores);
			}
		}
    }
}