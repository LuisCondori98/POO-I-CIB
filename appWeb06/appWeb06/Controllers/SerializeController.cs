using AppWeb06.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb06.Controllers
{
    public class SerializeController : Controller
    {
        static string jproducto = @"{
                'idProducto': 1,
                'descripcion': 'Laptop',
                'medida': 'unidad',
                'precio': 1500,
                'stock': 25
            }";

        // GET: Serialize
        public ActionResult SerializeProducto(int op = 0)
        {

            if(op == 0)
            {

                return View(new Producto());
            } else
            {
                Producto p = JsonConvert.DeserializeObject<Producto>(jproducto);

                return View(p);
            }
        }

        [HttpPost]
        public ActionResult SerializeProducto(Producto p)
        {

            string mensaje = "";

            try
            {

                jproducto = JsonConvert.SerializeObject(p);

                mensaje = "Producto Serializado";
            } catch (Exception e)
            {

                mensaje = e.Message;
            }

            ViewBag.mensaje = mensaje;

            return View(p);
        }
    }
}