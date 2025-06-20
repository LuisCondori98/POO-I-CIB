using appWeb04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appWeb04.Controllers
{
    public class AcademicoController : Controller
    {
        private List<Curso> cursos = new List<Curso>()
        {
            new Curso() { IdCurso = 1, descripcion = "Java", creditos = 4 },
            new Curso() { IdCurso = 2, descripcion = "Javascript", creditos = 3 },
            new Curso() { IdCurso = 3, descripcion = "PHP", creditos = 4 },
            new Curso() { IdCurso = 4, descripcion = "SQL", creditos = 5 },
            new Curso() { IdCurso = 5, descripcion = "SQL Programacion", creditos = 4 },
            new Curso() { IdCurso = 6, descripcion = "SQL Plus", creditos = 5 },
            new Curso() { IdCurso = 7, descripcion = "Python", creditos = 8 },
            new Curso() { IdCurso = 8, descripcion = "AWS", creditos = 2 },
            new Curso() { IdCurso = 9, descripcion = "Golang", creditos = 6 },
            new Curso() { IdCurso = 10, descripcion = "C++", creditos = 3 },
            new Curso() { IdCurso = 11, descripcion = "Docker", creditos = 4 },
            new Curso() { IdCurso = 12, descripcion = "Kubernetes", creditos = 6 }
        };

        // GET: Academico
        public ActionResult Listado()
        {
            return View(cursos);
        }

        public ActionResult FiltrarCurso(string nombre = "")
        {
            if (string.IsNullOrEmpty(nombre))
            {

                return View(cursos);
            } else
            {
                return View(cursos.Where(c => c.descripcion.StartsWith(nombre, StringComparison.CurrentCultureIgnoreCase)));
            }
        }
    }
}