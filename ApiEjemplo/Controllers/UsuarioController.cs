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

        [HttpGet]
        [Route("api/Usuario/{NombreU}/{Pwd}")]
        public Usuario CheckLogin(string NombreU, string Pwd)
        {
            Usuario User = UsuarioData.VerificarUsuario(NombreU, Pwd);
            
            return User;
        }
        [HttpPost]
        [Route("api/Usuario/Register/{NombreUs}/{Pwd}/{mail}/{nombre}/{NroTel}/{edad}")]
        public void Register(String NombreUs, String Pwd, String mail, String nombre, int NroTel, int edad)
        {
            UsuarioData.CrearUsuario(mail, nombre, NombreUs, Pwd, NroTel, edad);
        }
    }
}
