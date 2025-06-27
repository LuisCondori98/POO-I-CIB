using AppWeb09.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb09.Controllers
{
    public class ConsultasController : Controller
    {
        IEnumerable<Cliente> busqueda(string nombre)
        {
            List<Cliente> temporal = new List<Cliente>();

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand("EXEC usP_buscar_cliente @nombre", connection);

            cmd.Parameters.AddWithValue("@nombre", nombre);

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

        public ActionResult ConsultaNombre(string nombre = "")
        {

            return View(busqueda(nombre));
        }

        IEnumerable<Pedido> pedidosYear(int y)
        {
            List<Pedido> temporal = new List<Pedido>();

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand("EXEC usP_pedidos_year @y", connection);

            cmd.Parameters.AddWithValue("@y", y);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                temporal.Add(new Pedido()
                {
                    idPedido = reader.GetInt32(0),
                    fecha = reader.GetDateTime(1),
                    nombrecia = reader.GetString(2),
                    direccion = reader.GetString(3),
                    ciudad = reader.GetString(4),
                });
            }

            reader.Close();
            connection.Close();

            return temporal;
        }

        public ActionResult ConsultaYear(int y = 0)
        {

            return View(pedidosYear(y));
        }
    }
}