﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica.Models
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public double PrecioProducto { get; set; }
        public int StockProducto { get; set; }
    }
}