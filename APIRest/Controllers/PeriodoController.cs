using ProyectoGestorEscolar.Logica.Entidades;
using ProyectoGestorEscolar.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class PeriodoController : ApiController
    {
        ///Periodo/Ingresar
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Periodo/Ingresar")]
        public ResIngresarPeriodo Ingresar(ReqIngresarPeriodo req)
        {
            LogPeriodo MiLogica = new LogPeriodo();
            ResIngresarPeriodo res = new ResIngresarPeriodo();
            return res = MiLogica.IngresarPeriodo(req);
        }
    }
}