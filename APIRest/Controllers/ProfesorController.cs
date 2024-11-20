using ProyectoGestorEscolar.Logica.Entidades;
using ProyectoGestorEscolar.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class ProfesorController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Profesor/Ingresar")]

        public ResIngresarProfesor Ingresar(ReqIngresarProfesor req)
        {

            LogProfesor MiLogica = new LogProfesor();
            ResIngresarProfesor res = new ResIngresarProfesor();

            return res = MiLogica.IngresarProfesor(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Profesor/Actualizar")]

        public ResActualizarProfesor Actualizar(ReqActualizarProfesor req)
        {

            LogProfesor MiLogica = new LogProfesor();
            ResActualizarProfesor res = new ResActualizarProfesor();

            return res = MiLogica.ActualizarProfesor(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Profesor/Buscar")]

        public ResBuscarProfesor Buscar(ReqBuscarProfesor req)
        {

            LogProfesor MiLogica = new LogProfesor();
            ResBuscarProfesor res = new ResBuscarProfesor();

            return res = MiLogica.BuscarProfesor(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Profesor/Eliminar")]

        public ResEliminarProfesor Eliminar(ReqEliminarProfesor req)
        {

            LogProfesor MiLogica = new LogProfesor();
            ResEliminarProfesor res = new ResEliminarProfesor();

            return res = MiLogica.EliminarProfesor(req);
        }
    }
}