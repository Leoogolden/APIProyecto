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
        [Route("api/Invitacion/SolicitaUnirse/{Grupo}/{Solicitante}/{idactiv}")]
        public int SolicitaUnirse(int Grupo, int Solicitante, int idactiv)
        {
            int funca = InvitacionData.SolicitaUnirse(Grupo, Solicitante, idactiv);
            return funca;
        }
        [HttpGet]
        [Route("api/Invitacion/Solicitudes/{idadmin}")]
        public List<Notificaciones> Solicitudes(int idadmin)
        {
            List<Notificaciones> lista = new List<Notificaciones>();
            lista = InvitacionData.ListarSolicitudes(idadmin);

            return lista;
        }
        [HttpPost]
        [Route("api/Invitacion/AceptaSolicitud/{idadm}/{idsol}/{aceptaono}")]
        public int AceptaSolicitud(int idadm, int idsol, bool aceptaono)
        {
            int funca = InvitacionData.AceptarSolicitud(idadm, idsol,aceptaono);
            return funca;
        }
        [HttpGet]
        [Route("api/Invitacion/Solicitudes/VerPendientes/{idsol}")]
        public List<Notificaciones> VerPendientes(int idsol)
        {
            List<Notificaciones> lista = new List<Notificaciones>();
            lista = InvitacionData.VerSolPen(idsol);

            return lista;
        }

    }
}
