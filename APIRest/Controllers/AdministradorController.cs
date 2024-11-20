using ProyectoGestorEscolar.Logica.Entidades;
using ProyectoGestorEscolar.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class AdministradorController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Adminstrador/Ingresar")]

        public ResIngresarAdministrador Ingresar(ReqInsertarAdministrador req)
        {

            LogAdministrador MiLogica = new LogAdministrador();
            ResIngresarAdministrador res = new ResIngresarAdministrador();

            return res = MiLogica.InsertarAdministrador(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Administrador/Actualizar")]

        public ResActualizarAdministrador Actualizar(ReqActualizarAdministrador req)
        {

            ResActualizarAdministrador res = new ResActualizarAdministrador();
            LogAdministrador miLogica = new LogAdministrador();

            res = miLogica.ActualizarAdministrador(req);
            return res;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Administrador/Buscar")]

        public ResBuscarAdministrador Buscar(ReqBuscarAdministrador req)
        {

            ResBuscarAdministrador res = new ResBuscarAdministrador();
            LogAdministrador miLogica = new LogAdministrador();

            res = miLogica.BuscarAdministrador(req);
            return res;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Administrador/Eliminar")]

        public ResEliminarAdministrador EliminarA(ReqEliminarAdministrador req)
        {

            ResEliminarAdministrador res = new ResEliminarAdministrador();
            LogAdministrador miLogica = new LogAdministrador();

            res = miLogica.EliminarAdministrador(req);
            return res;
        }
    }
}