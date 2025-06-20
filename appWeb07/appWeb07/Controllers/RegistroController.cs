using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using Newtonsoft.Json;
using appWeb07.Models;

namespace appWeb07.Controllers
{
    public class RegistroController : Controller
    {
        static string carpeta = "~/folderJson/";

        // GET: Registro
        public ActionResult Index()
        {
            return View();
        }

		// GET: Registro

		public ActionResult Registrar()
		{
			return View(new Proveedor());
		}

		[HttpPost]	public ActionResult Registrar(Proveedor reg)
		{
			if (!ModelState.IsValid)
			{
				return View(reg);
			}
			string cadena = JsonConvert.SerializeObject(reg);
			FileStream f = new FileStream($"{Server.MapPath(carpeta)}{reg.IdProveedor}.json", FileMode.Create);
			StreamWriter escritor = new StreamWriter(f);
			escritor.Write(cadena);
			escritor.Close();
			f.Close();
			ViewBag.mensaje = "Proveedor Registrado";
			return View(reg);
		}

		//==============================================================================================
	}
}