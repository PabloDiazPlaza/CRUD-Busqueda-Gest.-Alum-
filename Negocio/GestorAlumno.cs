using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorAlumno
    {
        public bool Crear(Entidades.Alumno alumno)
        {
            // Asegurar que los datos obligatorios existen
            bool Valido = ValidarAlumno(alumno);

            if (Valido)
            {
                // Guardar el Producto

                Repositorio.RAlumno rAlumno = new Repositorio.RAlumno();

                if (rAlumno.Crear(alumno))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        private bool ValidarAlumno(Entidades.Alumno alumno)
            //Validación de Campos Vacios
        {
            if ((alumno.Rut != null) && (alumno.Rut != "") 
                && (alumno.Nombre != null) && (alumno.Nombre != "")
                && (alumno.Apellidos != null) && (alumno.Apellidos != "")
                && (alumno.Edad > 0) && (alumno.Edad < 110) && (alumno.Sexo > 0) && (alumno.Sexo <= 2))
            {
                return true;
            }

            return false;
        }


        public Entidades.Alumno ObtenerAlumno(string Rut)
        {
            Repositorio.RAlumno rAlumno = new Repositorio.RAlumno();
            Entidades.Alumno alumno = rAlumno.Buscar(Rut);

            return alumno;
        }

        public Entidades.Alumno Actualizar(Entidades.Alumno alumno)
        {
            Repositorio.RAlumno rAlumno = new Repositorio.RAlumno();

            return rAlumno.Actualizar(alumno);
        }

        public bool Eliminar(string Rut)
        {
            Repositorio.RAlumno rAlumno = new Repositorio.RAlumno();
            return rAlumno.Eliminar(Rut);
        }
    }
}
