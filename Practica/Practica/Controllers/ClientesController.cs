using Practica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica.Controllers
{
    public class ClientesController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public ActionResult ClientesList(Cliente reg)
        {
            return View(clientes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente reg)
        {
            clientes.Add(reg);
            return View(reg);
        }
    }
}