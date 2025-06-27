using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb10.Models
{
    public class Cliente
    {
        [Display(Name = "Id")] public string idCliente { get; set; }
        [Display(Name = "Nombre")] public string nombreCia { get; set; }
        [Display(Name = "Direccion")] public string direccion { get; set; }
        [Display(Name = "Id Pais")] public string idPais { get; set; }
        [Display(Name = "Nombre Pais")] public string nombrePais { get; set; }
        [Display(Name = "Telefono")] public string fono { get; set; }
    }
}