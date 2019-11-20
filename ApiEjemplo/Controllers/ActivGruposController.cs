using ApiEjemplo.Data;
using ApiEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiEjemplo.Controllers
{
    public class ActivGruposController : ApiController
    {
        [HttpGet]
        [Route("api/ActivsGrupo/{idgru}")]
        public List<Actividad> TraerActivs(int idgru)
        {
            List<Actividad> ListaDeActivs = ActividadData.ActividadesGrupo(idgru);

            return ListaDeActivs;
        }
        [HttpPost]
        [Route("api/ActivsGrupo/CrearActiv/{Nombre}/{Descripcion}/{Fecha}/{EdadMin}/{EdadMax}/{LimPer}/{Calle}/{Dir}/{idg}/{idus}")]
        public int CrearActiv(string Nombre, string Descripcion, DateTime Fecha, int EdadMin, int EdadMax, int LimPer, string Calle, int Dir, int idg, int idus)
        {
            int funciono = ActividadData.insertarActividad(Nombre, Descripcion, EdadMin, EdadMax, LimPer, Calle, Dir, Fecha, idg, idus);
            return funciono;
        }
        [HttpPost]
        [Route("api/ActivsGrupo/ConfAsis/{idgru}/{idactiv}/{idus}")]
        public int ConfAsis(int idgru, int idactiv, int idus)
        {
            int funciono = ActividadData.ConfirmacionAsistencia(idgru,idactiv,idus);
            return funciono;

        }
        [HttpGet]
        [Route("api/ActivsGrupo/TraerMiembrosActv/{idactiv}")]
        public List<Usuario> TraerMiembrosActv (int idactiv)
        {
            List<Usuario> ListaDeMiembros = ActividadData.ObtenerParticipantesActiv(idactiv);

            return ListaDeMiembros;
        }
        [HttpPost]
        [Route("api/ActivsGrupo/BajaDeActiv/{idus}/{idactiv}")]
        public int BajaDeActiv(int idactiv, int idus)
        {
            int regsafec = ActividadData.BajaActividad(idus, idactiv);

            return regsafec;
        }
        

    }
}
