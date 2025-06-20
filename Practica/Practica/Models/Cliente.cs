using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public int EdadCliente { get; set; }
        public string DireccionCliente { get; set; }
        public int NumeroCliente { get; set; }
    }
}