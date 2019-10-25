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

        [HttpGet]
        [Route("api/Grupos/MiembrosGrupo/{id}")]
        public List<Usuario> ListarMiembros(int id)
        {
            List<Usuario> ListaDeMiembros = GruposData.ObtenerMiembrosGrupo(id);

            return ListaDeMiembros;
        }


        [HttpGet]
        [Route("api/Grupos/Estaono/{idus}/{idgru}")]
        public bool Estaono(int idus, int idgru)
        {
            bool esta = GruposData.EstaEnGrupo(idus, idgru);
            return esta;

        }


        [HttpPost]
       [Route("api/Grupos/CrearGrupo/{Nombre}/{Descripcion}/{idus}")]
        public int CrearGrupo(string Nombre, string Descripcion, int idus)
        {
            int funciono = GruposData.insertarGrupo(Nombre, Descripcion, idus);
            return funciono;
        }
        [HttpGet]
        [Route("api/Grupos/EsAdmin/{idgru}")]
        public int EsAdmin(int idgru)
        {
            int idadmin = GruposData.EsAdmin(idgru);
            return idadmin;
        }
        [HttpPost]
        [Route("api/Grupos/EditGrupo/{Nombre}/{Descripcion}/{idgru}/{idus}")]
        public int EditGrupo(string Nombre, string Descripcion, int idgru, int idus)
        {
            int funciono = GruposData.EditarGrupo(idus, idgru, Nombre, Descripcion);
            return funciono;
        }

        [HttpPost]
        [Route("api/Grupos/EliminarUsDelGrupo/{idus}/{idgru}")]
        public int EliminarUsuario(int us, int idg)
        {
            int funciono = GruposData.EliminarDelGrupo(us, idg);
            return funciono;
        }
        [HttpPost]
        [Route("api/Grupos/HacerAdminDelGrupo/{idus}/{idgru}")]
        public int HacerAdminDelGrupo(int us, int idg)
        {
            int funciono = GruposData.HacerAdmin(us, idg);
            return funciono;
        }



    }
}
