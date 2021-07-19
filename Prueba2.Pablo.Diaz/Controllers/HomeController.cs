using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba2.Pablo.Diaz.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            string Rut = "";
            Negocio.GestorAlumno gestorAlumno = new Negocio.GestorAlumno();
            var producto = gestorAlumno.ObtenerAlumno(Rut);

            return View();
        }
    }
}