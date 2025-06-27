using AppWeb10.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb10.Controllers
{
    public class MantenimientoController : Controller
    {

        IEnumerable<Cliente> clientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            string query = "exec spU_listar_clientes";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                clientes.Add(new Cliente() {
                    idCliente = rd.GetString(0),
                    nombreCia = rd.GetString(1),
                    direccion = rd.GetString(2),
                    nombrePais = rd.GetString(3),
                    fono = rd.GetString(4),
                    idPais = rd.GetString(5),
                });

            }

            rd.Close();

            conn.Close();

            return clientes;
        }

        IEnumerable<Pais> listarPaises()
        {
            List<Pais> paises = new List<Pais>();

            string query = "exec spU_listar_paises";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                paises.Add(new Pais()
                {
                    idPais = rd.GetString(0),
                    nombrePais = rd.GetString(1),
                });

            }

            rd.Close();

            conn.Close();

            return paises;
        }

        string agregarCliente(Cliente c)
        {
            string query = "EXEC spU_Insertar_Cliente @id, @nomCli, @dirCli, @idPais, @fonoCli";

            string mensaje = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", c.idCliente);
                cmd.Parameters.AddWithValue("@nomCli", c.nombreCia);
                cmd.Parameters.AddWithValue("@dirCli", c.direccion);
                cmd.Parameters.AddWithValue("@idPais", c.idPais);
                cmd.Parameters.AddWithValue("@fonoCli", c.fono);

                int i = cmd.ExecuteNonQuery();

                mensaje = $"Se ha insertado {i} cliente";

            } catch (Exception ex)
            {
                mensaje = ex.Message;
            } finally
            {
                conn.Close();
            }

            return mensaje;
        }

        string actualizarCliente(Cliente c)
        {
            string query = "EXEC spU_actualizar_cliente @id, @nomCli, @dirCli, @idPais, @fonoCli";

            string mensaje = "";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

            try
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", c.idCliente);
                cmd.Parameters.AddWithValue("@nomCli", c.nombreCia);
                cmd.Parameters.AddWithValue("@dirCli", c.direccion);
                cmd.Parameters.AddWithValue("@idPais", c.idPais);
                cmd.Parameters.AddWithValue("@fonoCli", c.fono);

                int i = cmd.ExecuteNonQuery();

                mensaje = $"Se ha actualizado {i} cliente";

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return mensaje;
        }

        // GET: Mantenimiento

        // ===== CREATE =====
        public ActionResult Index()
        {
            return View(clientes());
        }

        // ===== READ =====
        public ActionResult Create()
        {
            ViewBag.paises = new SelectList(listarPaises(), "idPais", "nombrePais");
            return View(new Cliente());
        }

        [HttpPost]
        public ActionResult Create(Cliente c)
        {
            ViewBag.mensaje = agregarCliente(c);

            ViewBag.paises = new SelectList(listarPaises(), "idPais", "nombrePais", c.idPais);

            return View();
        }

        public ActionResult Edit(string id = "")
        {

            Cliente c = clientes().FirstOrDefault(cli => cli.idCliente == id);

            ViewBag.paises = new SelectList(listarPaises(), "idPais", "nombrePais");
        
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(Cliente c)
        {

            ViewBag.mensaje = actualizarCliente(c);

            ViewBag.paises = new SelectList(listarPaises(), "idPais", "nombrePais", c.idPais);

            return View(new Cliente());
        }

        public ActionResult Details(string id = "")
        {
            Cliente c = clientes().FirstOrDefault(cli => cli.idCliente == id);

            return View(c);
        }
    }
}