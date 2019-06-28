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
    public class InvitacionController : ApiController
    {
        [HttpGet]
        [Route("api/Invitacion/{idusr}")]
        public List<Notificaciones> TraerInvitacionesAGrupos(int idusr){
            List<Notificaciones> lista = new List<Notificaciones>();
            lista = InvitacionData.TraerInvitaciones(idusr);

            return lista;
        }
    }
}
