using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestorEscolar.Logica.Entidades
{
    public class Estudiante
    {
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Cedula { get; set; }
        public String Direccion { get; set; }
        public String Genero { get; set; }
        public String Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime PrimerMatricula { get; set; }
        public String NombrePadre { get; set; }
        public String ApellidosPadre { get; set; }
        public String TelefonoPadre { get; set; }
        public String Grado { get; set; }
        public String Usuario { get; set; }
        public String Pswd { get; set; }
    }
}
