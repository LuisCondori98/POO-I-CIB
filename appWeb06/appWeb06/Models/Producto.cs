using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appWeb06.Models
{
	public class Producto
	{
		// Página 160
		public int IdProducto { get; set; }
		public string Descripcion { get; set; }
		public string Medida { get; set; }
		public decimal Precio { get; set; }
		public int Stock { get; set; }
	}
}