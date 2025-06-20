using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWebT1CondoriAnayaLuis.Models
{
    public class Paciente
    {
        public int nroHistoria { get; set; }
        public string nomApePaciente { get; set; }
        public string dniPaciente { get; set; }
        public string direccionPaciente { get; set; }
        public double pesoPaciente { get; set; }
        public double tallaPaciente { get; set; }
    }
}