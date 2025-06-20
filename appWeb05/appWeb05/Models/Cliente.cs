using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appWeb05.Models
{
    public class Cliente
    {
        public string Dni { set; get; }
        public string Nombre { set; get; }
        public string Direccion { set; get; }
        public string Fono { set; get; }
        public string Email { set; get; }
    }
}