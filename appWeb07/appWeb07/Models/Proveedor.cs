using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appWeb07.Models
{
	public class Proveedor
	{
		// Página 182
		public int IdProveedor { get; set; }
		public string Nombre { get; set; }
		public string Ruc { get; set; }
		public string Direccion { get; set; }
		public string Fono { get; set; }
		public string Email { get; set; }
	}
}