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
    public class UsuarioController : ApiController
    {
        [Route("api/Usuario/{NombreU}&{Pwd}")]
        public bool CeckLogin(string NombreU, string Pwd)
        {
            bool ingresado = UsuarioData.VerificarUsuario(NombreU, Pwd);

            return ingresado;
        }



    }
}
