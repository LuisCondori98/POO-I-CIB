using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWebT1CondoriAnayaLuis.Models
{
    public class Obrero
    {
        public string idObrero { get; set; }
        public string nomApeObrero { get; set; }
        public string cateObrero { get; set; }
        public int nHoras { get; set; }
        public int nHijos { get; set; }
        public string tipoContrato { get; set; }

        public Obrero()
        {
            cateObrero = string.Empty;
            nHoras = 0;
            nHijos = 0;
            tipoContrato = string.Empty;
        }

        public double calcularSueldoBasico()
        {
            double tarifa;

            switch (cateObrero)
            {
                case "Ayudante":
                {
                    tarifa = nHoras * 12;
                }; break;
                case "Albañil":
                {
                    tarifa = nHoras * 15;
                }; break;
                case "Maestro":
                {
                    tarifa = nHoras * 25;
                };break;
                default:

                    tarifa = nHoras * 25;
                ; break;
            }

            return tarifa;
        }

        public double retornarEscolaridad()
        {

            return nHijos * 50;
        }

        public double calcularBonificacion()
        {
            double bonificacion = 0;

            if(tipoContrato == "Indefinido")
            {

                return calcularSueldoBasico() * 0.05;
            } else if(tipoContrato == "Contratado")
            {

                return calcularSueldoBasico() * 0.08;
            }

            return bonificacion;
        }

        public double calcularMontoAPagar()
        {

            return calcularSueldoBasico() + retornarEscolaridad() + calcularBonificacion();
        }
    }

    public enum cateObrero
    {
        Ayudante,
        Albañil,
        Maestro
    }

    public enum tipoContrato
    {
        Indefinido,
        Contratado
    }
}