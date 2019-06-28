using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiEjemplo.Models
{
    public class Invitacion
    {
        public int IdGrupo { get; set; }
        public int IdInvitado { get; set; }
        public int IdInvitante { get; set; }
        public int IdInvitacion { get; set; }

    }
}