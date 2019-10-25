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
    public class ActividadController : ApiController
    {
        [HttpGet]
        [Route("api/Activs")]
        public List<Actividad> Activs()
        {
            List<Actividad> ListaDeActivs = ActividadData.TraerActividades();

            return ListaDeActivs;
        }
        [HttpGet]
        [Route("api/Activs/TraerGrupo/{id}")]
        public Grupos TraerGrupo(int id)
        {
            Grupos grupardo = ActividadData.ObtenerGrupo(id);

            return grupardo;
        }



    }
}
