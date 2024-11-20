using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestorEscolar.Logica.Entidades
{
    public class Profesor
    {
        public String NombreUsuario { get; set; }
        public String PSWD { get; set; }
        public int Curso { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Materias { get; set; }
        public String Direccion { get; set; }
        public String Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Telefono { get; set; }
        public String Calificacion { get; set; }
        public String Genero { get; set; }
        public String Correo { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
