using ProyectoGestorEscolar.Logica;
using ProyectoGestorEscolar.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class EstudianteController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Estudiante/Ingresar")]

        public ResIngresarEstudiante Ingresar(ReqIngresarEstudiante req)
        {

            ResIngresarEstudiante res = new ResIngresarEstudiante();
            LogEstudiante miLogica = new LogEstudiante();

            res = miLogica.IngresarEstudiante(req);
            return res;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Estudiante/Actualizar")]

        public ResActualizarEstudiante Actualizar(ReqActualizarEstudiante req)
        {

            ResActualizarEstudiante res = new ResActualizarEstudiante();
            LogEstudiante miLogica = new LogEstudiante();

            res = miLogica.ActualizarEstudiante(req);
            return res;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Estudiante/Buscar")]

        public ResBuscarEstudiante Buscar(ReqBuscarEstudiante req)
        {

            ResBuscarEstudiante res = new ResBuscarEstudiante();
            LogEstudiante miLogica = new LogEstudiante();

            res = miLogica.BuscarEstudiante(req);
            return res;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Estudiante/Eliminar")]

        public ResEliminarEstudiante Eliminar(ReqEliminarEstudiante req)
        {

            ResEliminarEstudiante res = new ResEliminarEstudiante();
            LogEstudiante miLogica = new LogEstudiante();

            res = miLogica.EliminarEstudiante(req);
            return res;
        }

    }
}