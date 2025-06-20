using AppWeb03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb03.Controllers
{
    public class OrdenesController : Controller
    {
        // GET: Ordenes
        public ActionResult Registro()
        {
            return View(new OServicio());
        }

        [HttpPost]
        public ActionResult Registro(OServicio reg)
        {
            string mensaje = "";

            try
            {
                if (string.IsNullOrEmpty(reg.nservicio)) throw new ArgumentException();
                if (reg.fservicio > DateTime.Today) throw new Exception();
                if (reg.costo <= 0) throw new FormatException();
            }
            catch (ArgumentException)
            {
                mensaje = "nservicio no puede estar vacio";
            }
            catch (FormatException)
            {
                mensaje = "Costo debe ser mayor a cero";
            }
            catch (Exception)
            {
                mensaje = "Fecha menor o igual a hoy";
            }

            ViewBag.mensaje = mensaje;

            return View(reg);
        }
    }
}