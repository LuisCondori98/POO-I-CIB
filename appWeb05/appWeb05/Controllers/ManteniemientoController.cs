using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using appWeb05.Models;

namespace appWeb05.Controllers
{
    public class ManteniemientoController : Controller
    {
        // ================== Variables y Métodos ======================

        private static List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente(){Dni="08584751",Nombre = "Hugo Rubio", 
                    Direccion="Lima", Fono = "963254125", Email="hrubio@cibertec.edu.pe"},
            new Cliente(){Dni="21548711",Nombre = "Rosario Saldaña",
                    Direccion="Lima", Fono = "941257841", Email="rsaldaña@cibertec.edu.pe"},
            new Cliente(){Dni="36655414",Nombre = "Viviana Lozano",
                    Direccion="Lima", Fono = "974125414", Email="vlozano@cibertec.edu.pe"},
        };

        // ================== Abajo las Viestas ========================
        // GET : Index
        public async Task<ActionResult> Index()
        {
            return View(await Task.Run(()=>clientes));
        }

        public async Task<ActionResult> Filtro(string nombre = "")
        {
            List<Cliente> temporal;
            if (string.IsNullOrEmpty(nombre))
            {
                temporal = clientes;
            }
            else
            {
                temporal = clientes.Where(c => c.Nombre.StartsWith(nombre)).ToList();
            }
            return View(await Task.Run(() => temporal));
        }

        //--------------------------------------------------------------
        // GET : Create
        public async Task<ActionResult> Create()
        {
            return View(await Task.Run(() => new Cliente()));
        }

        [HttpPost]public async Task<ActionResult> Create(Cliente reg)
        {
            if(!ModelState.IsValid)
                return View(await Task.Run(() => reg));
            clientes.Add(reg);
            ViewBag.mensaje = "Cliente Agregado";
            return View(await Task.Run(() => reg));
        }

        //-------------------------------------------------------------------------------------------
        // GET : Edit
        public async Task<ActionResult> Edit(string dni)
        {
            var cliente = await Task.Run(() => clientes.FirstOrDefault(c => c.Dni == dni));
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }
        [HttpPost] public async Task<ActionResult> Edit(Cliente reg)
        {
            if (!ModelState.IsValid)
                return View(await Task.Run(() => reg));

            var cliente = await Task.Run(() => clientes.FirstOrDefault(c => c.Dni == reg.Dni));
            if (cliente == null)
                return HttpNotFound();

            cliente.Nombre = reg.Nombre;
            cliente.Email = reg.Email;
            cliente.Fono = reg.Fono;
            // Agrega más propiedades según tu modelo

            ViewBag.mensaje = "Cliente Actualizado";
            return View(await Task.Run(() => reg));
        }
        
        //-------------------------------------------------------------------------------------------
        // GET : Details
        public async Task<ActionResult> Details(string dni = "")
        {
            var cliente = await Task.Run(() => clientes.FirstOrDefault(c => c.Dni == dni));
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }
       
        //------------------------------------------------------------------------------------------
        // GET : Delete
        public async Task<ActionResult> Delete(string dni = "")
        {
            var cliente = await Task.Run(() => clientes.FirstOrDefault(c => c.Dni == dni));
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string dni = "")
        {
            var cliente = await Task.Run(() => clientes.FirstOrDefault(c => c.Dni == dni));
            if (cliente == null)
                return HttpNotFound();

            await Task.Run(() => clientes.Remove(cliente));

            TempData["mensaje"] = "Cliente eliminado correctamente";
            return RedirectToAction("Index");  // O a la vista que lista clientes
        }


    }
}