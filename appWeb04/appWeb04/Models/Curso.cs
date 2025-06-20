using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace appWeb04.Models
{
    public class Curso
    {
        [Key]public int IdCurso { get; set; }
        public string descripcion { get; set; }
        public int creditos { get; set; }
    }
}