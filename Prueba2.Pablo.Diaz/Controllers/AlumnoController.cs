using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Prueba2.Pablo.Diaz.Models;

namespace Prueba2.Pablo.Diaz.Controllers
{
    public class AlumnoController : Controller
    { 

     // GET: Producto
    public ActionResult Index()
    {
        return View();
    }

    //GET
    public ActionResult Crear()
    {
        ViewBag.Mensaje = "";
        return View(new AlumnoModel());
    }

    //POST
    [HttpPost]
    public ActionResult Crear(AlumnoModel amodel)
    {
        AlumnoModel alumnoModel = new AlumnoModel();
        alumnoModel = amodel;

        Entidades.Alumno alumno = new Entidades.Alumno
        {
            Rut = alumnoModel.Rut,
            Nombre = alumnoModel.Nombre,
            Apellidos = alumnoModel.Apellidos,
            Edad = alumnoModel.Edad,
            Sexo = alumnoModel.Sexo,
            
        };

        Negocio.GestorAlumno gestorAlumno = new Negocio.GestorAlumno();
        bool result = gestorAlumno.Crear(alumno);

        ViewBag.Mensaje = result ? "Alumno Creado" : "Error, No se pudo Crear al Alumno";

        return View(alumnoModel);
    }

    //GET
    public ActionResult Buscar()
    {
        return View(new Models.AlumnoModel());
    }

    [HttpPost]
    public ActionResult Buscar(Models.AlumnoModel amodel)
    {
        Negocio.GestorAlumno gestorAlumno = new Negocio.GestorAlumno();

        Entidades.Alumno alumno = gestorAlumno.ObtenerAlumno(amodel.Rut);

        if (alumno.Rut != "err")
        {
            return RedirectToAction("Detalle", alumno);
            }
            else
            {
                Response.Write("Error, No se ha Logrado Encontrar al Alumno");
            }

        return View(new Models.AlumnoModel());
    }

    public ActionResult Detalle(Models.AlumnoModel amodel)
    {
        return View(amodel);
    }

    public ActionResult Editar(string Rut)
    {
        Negocio.GestorAlumno gestorAlumno = new Negocio.GestorAlumno();

        Entidades.Alumno alumno = gestorAlumno.ObtenerAlumno(Rut);
        Models.AlumnoModel alumnoModel = new AlumnoModel
        {
            Rut = alumno.Rut,
            Nombre = alumno.Nombre,
            Apellidos = alumno.Apellidos,
            Edad = alumno.Edad,
            Sexo = alumno.Sexo,
            
        };

        if (alumno.Rut != "err")
        {
            return View(alumnoModel);
            }
            else
            {
                Response.Write("Error, No se ha Logrado Modificar al Alumno");

            }

        return RedirectToAction("Buscar", new AlumnoModel());
    }

    [HttpPost]
    public ActionResult Editar(Models.AlumnoModel amodel)
    {
        AlumnoModel alumnoModel = new AlumnoModel();
        alumnoModel = amodel;

        Entidades.Alumno alumno = new Entidades.Alumno
        {
            Rut = alumnoModel.Rut,
            Nombre = alumnoModel.Nombre,
            Apellidos = alumnoModel.Apellidos,
            Edad = alumnoModel.Edad,
            Sexo = alumnoModel.Sexo,

        };

        Negocio.GestorAlumno gestorAlumno = new Negocio.GestorAlumno();
        alumno = gestorAlumno.Actualizar(alumno);

        if (alumno.Rut != "err")
        {
            return RedirectToAction("Detalle", alumno);
        }

        return View();
    }

    public ActionResult Eliminar(string Rut)
    {
        Negocio.GestorAlumno gestorAlumno = new Negocio.GestorAlumno();

        Entidades.Alumno alumno = gestorAlumno.ObtenerAlumno(Rut);
        Models.AlumnoModel alumnoModel = new AlumnoModel
        {
            Rut = alumno.Rut,
            Nombre = alumno.Nombre,
            Apellidos = alumno.Apellidos,
            Edad = alumno.Edad,
            Sexo = alumno.Sexo,
            
        };

        if (alumno.Rut != "err")
        {
            return View(alumnoModel);
        }
            else
            {
                Response.Write("Error, No se ha Logrado Encontrar al Alumno");
            }

            return RedirectToAction("Buscar", new AlumnoModel());
    }

    [HttpPost]
    public ActionResult Eliminar(AlumnoModel amodel)
    {
        Negocio.GestorAlumno gestorAlumno = new Negocio.GestorAlumno();
        bool resultado = gestorAlumno.Eliminar(amodel.Rut);

        if (resultado)
        {
            return RedirectToAction("Index");
        }
            else
            {
                Response.Write("Error, No se ha Logrado Encontrar al Alumno");
            }

            return View();
    }



}
}