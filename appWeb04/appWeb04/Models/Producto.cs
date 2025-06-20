using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appWeb04.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string descripcion { get; set; }
        public string medida { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
    }

    public enum medida
    {
        Unidad,
        Docena,
        Metro,
        Kilo,
        Ciento,
        Libra
    }
}