using appWeb_T2_CondoriAnaya.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appWeb_T2_CondoriAnaya.Controllers
{
    public class PacienteController : Controller
    {
        static List<Paciente> pacientes = new List<Paciente>();
        static string rutas = "~/folderJson/pacientes";
        static string carpeta = "~/folderJson/";


        public ActionResult Index()
        {
            string ruta = @"~/folderJson/pacientes.json";

            string rutaFisica = Server.MapPath(ruta);

            if (!System.IO.File.Exists(rutaFisica))
            {
                return View(pacientes);
            }
            else
            {
                using (FileStream f = new FileStream(rutaFisica, FileMode.Open))
                using (StreamReader lector = new StreamReader(f))
                {
                    pacientes = JsonConvert.DeserializeObject<List<Paciente>>(lector.ReadToEnd());
                }

                return View(pacientes);
            }
        }

        /*static string jsonColeccionPaciente = @"[
            {
                'idPaciente':1,
                'nombresPaciente':'Javier Loayza',
                'direccionPaciente':'Av Peru',
                'telefonoPaciente': 986754821,
                'correoPaciente':'javi@gmail.com'
            },
            {
                'idPaciente':2,
                'nombresPaciente':'Hugo Terreros',
                'direccionPaciente':'Jr Fresas',
                'telefonoPaciente': 987658432,
                'correoPaciente':'huguito_85@hotmail.com'
            }]";*/



        // GET: Inventario
        /*public ActionResult Index()
        {
            List<Paciente> temporal;
            if (string.IsNullOrEmpty(jsonColeccionPaciente))
                temporal = new List<Paciente>();
            else
                temporal = JsonConvert.DeserializeObject<List<Paciente>>(jsonColeccionPaciente);

            return View(temporal);
        }*/

        public ActionResult Create()
        {

            return View(new Paciente());
        }

        [HttpPost]
        public ActionResult Create(Paciente reg)
        {
            string mensaje = "";

            if (!ModelState.IsValid) return View(reg);

            try
            {
                List<Paciente> temporal = pacientes;

                temporal.Add(reg);

                mensaje = "Paciente Registrado";
            }
            catch (JsonException ex) { mensaje = ex.Message; }

            ViewBag.mensaje = mensaje;

            return View(reg);
        }

        [HttpDelete]
        public ActionResult Eliminar(string id)
        {

            string mensajeD = "";

            List<Paciente> temporal = pacientes;

            int pac = temporal.FindIndex(i => i.idPaciente == id);

            temporal.RemoveAt(pac);

            ViewBag.mensajeD = "Borrado";

            return View();
        }

        /*[HttpPost]
        public ActionResult Registrar(Proveedor reg)
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
    }*/

    public ActionResult SerializaPaciente()
    {

            String mensaje = "";

        ViewBag.mensaje = "Paciente Registrado";

        return View(new Paciente());
    }

    [HttpPost]
    public ActionResult SerializaPaciente(Paciente reg)
    {
            if (!ModelState.IsValid)
            {
                return View(reg);
            }
            string cadena = JsonConvert.SerializeObject(reg);
            FileStream f = new FileStream($"{Server.MapPath(carpeta)}.json", FileMode.Create);
            StreamWriter escritor = new StreamWriter(f);
            escritor.Write(cadena);
            escritor.Close();
            f.Close();
            ViewBag.mensaje = "Paciente Registrado";
            return View(reg);
        }
}
}