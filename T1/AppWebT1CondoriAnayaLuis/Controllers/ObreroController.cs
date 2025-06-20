using AppWebT1CondoriAnayaLuis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebT1CondoriAnayaLuis.Controllers
{
    public class ObreroController : Controller
    {
        private static List<Obrero> obreros = new List<Obrero>();

        public ActionResult RegistrarObrero()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarObrero(Obrero reg)
        {
            ViewBag.calcularSueldoBasico = reg.calcularSueldoBasico().ToString();
            ViewBag.retornarEscolaridad = reg.retornarEscolaridad().ToString();
            ViewBag.calcularBonificacion = reg.calcularBonificacion().ToString();
            ViewBag.calcularMontoAPagar = reg.calcularMontoAPagar().ToString();

            return View(reg);
        }
    }
}