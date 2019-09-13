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
        [Route("api/ActivsGrupo/CrearActiv/{Nombre}/{Descripcion}/{Fecha}/{EdadMin}/{EdadMax}/{LimPer}/{Calle}/{Dir}/{idg}")]
        public int CrearActiv(string Nombre, string Descripcion,DateTime Fecha, int EdadMin, int EdadMax, int LimPer, string Calle, int Dir, int idg)
        {
            int funciono = ActividadData.insertarActividad(Nombre, Descripcion, EdadMin, EdadMax, LimPer, Calle, Dir, Fecha, idg);
            return funciono;
        }


    }
}
