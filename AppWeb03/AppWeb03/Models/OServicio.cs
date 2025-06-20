using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb03.Models
{
    public class OServicio
    {
        public string nservicio { get; set; }
        public DateTime fservicio { get; set; }
        public string cliente { get; set; }
        public string descripcion { get; set; }
        public double costo { get; set; }
        public double igv { get { return 0.18 * costo; } }
        public double monto { get { return igv * costo; } }
    }
}