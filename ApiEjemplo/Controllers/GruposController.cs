using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiEjemplo.Models;
using ApiEjemplo.Data;

namespace ApiEjemplo.Controllers
{
    public class GruposController : ApiController
    {
        [HttpGet]
        [Route("api/Grupos/{idus}")]        
        public List<Grupos> ListarGrupos(int idus)
        {
            List<Grupos> ListaDeGrupos  = GruposData.ObtenerGruposxUsuario(idus);

            return ListaDeGrupos;
        }


    }
}
