using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGestorEscolar.Logica.Entidades
{
    public  class Administrador
    {
        public String Usuario {  get; set; }
        public String Pswd { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Cedula { get; set; }
        public DateTime FechaInico { get; set; }
    }
}
