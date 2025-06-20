using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace appWeb05.Controllers
{
    public class ProcesosController : Controller
    {
        //================ Variables y Métodos ===================
        
        int Qdivisores(int n)
        {
            int q = 0;  
            for(int i = 1; i <= n; i++) { 
                if(n % i == 0)
                   q++;
            }
            return q;
        }
        int Sdivisores(int n)
        {
            int q = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    q+=i;
            }
            return q;
        }
        int SDigitos(int n)
        {
            int s = 0;
            while(n > 0) {
                int digito = n % 10;
                s += digito;
                n = n / 10;
            }
            return s;
        }

        int Factorial(int n)  {
            int fact = 1;
            for(int cont=1; cont <= n; cont++)
                fact *= cont;
            return fact;    
        }

        int sumaPares(int n) {
            int s = 0;
            for (int cont = 1; cont <= n; cont++)
            {
                if (cont % 2 == 0)
                    s += cont;
            }
            return s;
        }
        int sumaImpares(int n)
        {
            int s = 0;
            for (int cont = 1; cont <= n; cont++)
            {
                if (cont % 2 == 1)
                    s += cont;
            }
            return s;
        }


        // =============== Métodos para las Vistas ===============
        // GET: Procesos
        public async Task<ActionResult> Operaciones(int n = 0)
        {
            ViewBag.qdivisores = await Task.Run(() => Qdivisores(n));
            ViewBag.sdivisores = await Task.Run(() => Sdivisores(n));
            ViewBag.sdigitos   = await Task.Run(() => SDigitos(n));
            ViewBag.factorial  = await Task.Run(() => Factorial(n));
            ViewBag.sumpares = await Task.Run(() => sumaPares(n));
            ViewBag.sumimpares = await Task.Run(() => sumaImpares(n));
            return View();
        }
    }
}