using ProyectoGestorEscolar.Logica.Entidades;
using ProyectoGestorEscolar.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class GradoController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Grado/Ingresar")]
        public ResAgregarGrado Ingresar(ReqAgregarGrado req)
        {
            LogGrado MiLogica = new LogGrado();
            ResAgregarGrado res = new ResAgregarGrado();
            return res = MiLogica.AgregarGrado(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Grado/Borrar")]
        public ResEliminarGrado Borrar(ReqEliminarGrado req)
        {
            LogGrado miLogica = new LogGrado();
            return miLogica.EliminarGrado(req);
        }
    }
}