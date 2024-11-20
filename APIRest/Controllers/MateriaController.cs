using ProyectoGestorEscolar.Logica.Entidades;
using ProyectoGestorEscolar.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class MateriaController : ApiController
    {
        ///Materia/Ingresar
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Materia/Ingresar")]
        public ResAgregarMateria Ingresar(ReqAgregarMateria req)
        {
            LogMateria MiLogica = new LogMateria(); 
            ResAgregarMateria  res = new ResAgregarMateria();
            return res = MiLogica.AgregarMateria(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Materia/Mostrar")] 
        public ResMostrarMaterias MostrarMaterias()
        {
            ResMostrarMaterias res = new ResMostrarMaterias();
            LogMateria miLogica = new LogMateria();
            res = miLogica.MostrarMaterias();
            return res;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Materia/Actualizar")]
        public ResActualizarMateria Actualizar(ReqActualizarMateria req)
        {
            LogMateria miLogica = new LogMateria();
            return miLogica.ActualizarMateria(req);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("API/Materia/Borrar")]
        public ResEliminarMateria Borrar(ReqEliminarMateria req)
        {
            LogMateria miLogica = new LogMateria();
            return miLogica.EliminarMateria(req);
        }
    }
}