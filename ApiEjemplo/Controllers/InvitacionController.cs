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
        [HttpPost]
        [Route("api/Invitacion/Invitar/{Grupo}/{Invitante}/{Invitado}")]
        public int InvitarAlGrupo(int Grupo, int Invitante, int Invitado)
        {
            int funca = InvitacionData.EnviarInvitacion(Grupo, Invitante, Invitado);
            return funca;
        }

        [HttpPost]
        [Route("api/Invitacion/Aceptar/{IdInvitacion}/{Acepta}")]
        public int Aceptar(int IdInvitacion, bool Acepta)
        {
            int funca = InvitacionData.AceptarInvitacion(IdInvitacion, Acepta);
            return funca;
        }
        [HttpPost]
        [Route("api/Invitacion/SolicitaUnirse/{Grupo}/{Solicitante}")]
        public int SolicitaUnirse(int Grupo, int Solicitante)
        {
            int funca = InvitacionData.SolicitaUnirse(Grupo, Solicitante);
            return funca;
        }


    }
}
