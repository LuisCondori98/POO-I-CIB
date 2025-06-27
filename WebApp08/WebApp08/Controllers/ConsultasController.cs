using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using WebApp08.Models;

namespace WebApp08.Controllers
{
    public class ConsultasController : Controller
    {
        //string cadena = @"server=localhost\SQLEXPRESS; database=Negocios2022; integrated security = true";

        IEnumerable<Cliente> clientes()
        {
            List<Cliente> temporal = new List<Cliente>();

            //string query = "SELECT * FROM Clientes";

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                temporal.Add(new Cliente()
                {
                    idCliente = reader.GetString(0),
                    nombrecia = reader.GetString(1),
                    direccion = reader.GetString(2),
                    idpais = reader.GetString(3),
                    fono = reader.GetString(4),
                });
            }

            reader.Close();
            connection.Close();

            return temporal;
        }

        IEnumerable<Cliente> clientes_sp()
        {
            List<Cliente> temporal = new List<Cliente>();

            //string query = "SELECT * FROM Clientes";

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("exec usP_Clientes", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                temporal.Add(new Cliente()
                {
                    idCliente = reader.GetString(0),
                    nombrecia = reader.GetString(1),
                    direccion = reader.GetString(2),
                    idpais = reader.GetString(3),
                    fono = reader.GetString(4),
                });
            }

            reader.Close();
            connection.Close();

            return temporal;
        }

        // GET: Consultas
        public ActionResult Listado()
        {
            return View(clientes());
        }

        public ActionResult Listado_sp()
        {
            return View(clientes_sp());
        }
    }
}