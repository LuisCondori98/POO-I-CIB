using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb09.Models
{
    public class Pedido
    {
        [Display(Name = "Id Pedido")] public int idPedido { get; set; }
        [Display(Name = "Fecha pedido")] public DateTime fecha { get; set; }
        [Display(Name = "Cliente")] public string nombrecia { get; set; }
        [Display(Name = "Direccion destino")] public string direccion { get; set; }
        [Display(Name = "Ciudad destino")] public string ciudad { get; set; }
    }
}