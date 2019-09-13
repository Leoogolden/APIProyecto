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


    }
}
