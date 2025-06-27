using appWeb_T2_CondoriAnaya.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appWeb_T2_CondoriAnaya.Controllers
{
    public class ProductsController : Controller
    {

        IEnumerable<Products> listarProducts_SP(int n1, int n2)
        {
            var temporal = new List<Products>();

            String cadena= "server = (local); database = Northwind; Integrated Security = True";

            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();

            SqlCommand cmd = new SqlCommand("sp_Lista_registros", cn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MinPrice", n1);
            cmd.Parameters.AddWithValue("@MaxPrice", n2);

            SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Products()
                    {
                        ProductId = dr.GetInt32(0),
                        ProductName = dr.GetString(1),
                        CategoryName = dr.GetString(2),
                        CompanyName = dr.GetString(3),
                        UnitPrice = dr.GetDouble(4),
                        UnitsInStock = dr.GetInt32(5),
                        StockValorizado = dr.GetDouble(6),
                    });
                }
            dr.Close();
            cn.Close();

            return temporal;
        }

        public ActionResult Consulta(int n1 = 0, int n2 = 0)
        {
            return View(listarProducts_SP(n1, n2));
        }
    }
}