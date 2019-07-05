using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiEjemplo.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int NroTelefono { get; set; }
        public int Edad { get; set; }

        public Usuario()
        {
            IdUsuario = -1;
        }
    }
}