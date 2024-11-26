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
        public ResIngresarPeriodo IngresarPeriodo(ReqIngresarPeriodo req)
        {
            LogPeriodo MiLogica = new LogPeriodo();
            ResIngresarPeriodo res = new ResIngresarPeriodo();
            return res = MiLogica.IngresarPeriodo(req);
        }

        ///Periodo/Mostrar
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Periodo/Mostrar")]
        public ResMostrarPeriodos MostrarPeriodos(ReqMostrarPeriodos req)
        {
            LogPeriodo MiLogica = new LogPeriodo();
            ResMostrarPeriodos res = new ResMostrarPeriodos();
            return res = MiLogica.MostrarPeriodos();
        }

        //Periodo/Eliminar
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Periodo/Eliminar")]
        public ResEliminarPeriodo Eliminar(ReqEliminarPeriodo req)
        {
            LogPeriodo MiLogica = new LogPeriodo();
            ResEliminarPeriodo res = new ResEliminarPeriodo();
            return res = MiLogica.EliminarPeriodo(req);
        }


    }
}