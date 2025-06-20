using AppWebT1CondoriAnayaLuis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebT1CondoriAnayaLuis.Controllers
{
    public class PacienteController : Controller
    {

        private static List<Paciente> pacientes = new List<Paciente>() {
            new Paciente()
            {
                nroHistoria = 15979, nomApePaciente = "Hugo Melgar Sancho", dniPaciente = "85469361", direccionPaciente = "Av. Peru 5159", pesoPaciente = 62.5, tallaPaciente = 170
            },
            new Paciente()
            {
                nroHistoria = 89674, nomApePaciente = "Fiorella Contraras", dniPaciente = "70896547", direccionPaciente = "Jr. Lima 159", pesoPaciente = 72.5, tallaPaciente = 178
            }
        };

        // GET: Paciente
        public ActionResult Index()
        {

            return View(pacientes);
        }
        public ActionResult Create()
        {

            return View(new Paciente());
        }

        [HttpPost]
        public ActionResult Create(Paciente reg)
        {
            if (pacientes.Any(dni => dni.dniPaciente == reg.dniPaciente))
            {

                ViewBag.mensaje = "Dni Repetido";
            } else
            {
                pacientes.Add(reg);

                ViewBag.mensaje = "Paciente creado";
            }

            return View();
        }
    }
}