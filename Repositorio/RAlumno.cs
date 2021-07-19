using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RAlumno
    {
        public bool Crear(Entidades.Alumno alumno)
        {
            
            DataAlumno.Rut = alumno.Rut;
            DataAlumno.Nombre = alumno.Nombre;
            DataAlumno.Apellidos = alumno.Apellidos;
            DataAlumno.Edad = alumno.Edad;
            DataAlumno.Sexo = alumno.Sexo;
            

            return true;
        }


        public Entidades.Alumno Buscar(string Rut)
        {
            Entidades.Alumno alumno = new Entidades.Alumno();
            if (Rut == DataAlumno.Rut)
            {
                alumno = new Entidades.Alumno
                {
                    Rut = DataAlumno.Rut,
                    Nombre = DataAlumno.Nombre,
                    Apellidos = DataAlumno.Apellidos,
                    Edad = DataAlumno.Edad,
                    Sexo = DataAlumno.Sexo,
                 };

                return alumno;
            }
            // El err representa que no se encontró el rut del alumno
            alumno.Rut = "err"; 

            return alumno;
        }

        public Entidades.Alumno Actualizar(Entidades.Alumno alumno)
        {
            if (alumno.Rut == DataAlumno.Rut)
            {
                DataAlumno.Rut = alumno.Rut;
                DataAlumno.Nombre = alumno.Nombre;
                DataAlumno.Apellidos = alumno.Apellidos;
                DataAlumno.Edad = alumno.Edad;
                DataAlumno.Sexo = alumno.Sexo;
                
                alumno = new Entidades.Alumno
                {
                    Rut = DataAlumno.Rut,
                    Nombre = DataAlumno.Nombre,
                    Apellidos = DataAlumno.Apellidos,
                    Edad = DataAlumno.Edad,
                    Sexo = DataAlumno.Sexo,
                };

                return alumno;
            }

            alumno.Rut = "err"; // El err representa que no se actualizaron los Datos del Alumno

            return alumno;
        }



        public bool Eliminar(string Rut)
        {
            if (Rut == DataAlumno.Rut)
            {
                DataAlumno.Rut = null;
                DataAlumno.Nombre = null;
                DataAlumno.Apellidos = null;
                DataAlumno.Edad = 0;
                DataAlumno.Sexo = 0;
                
                return true;
            }

            return false;
        }
    }
}


