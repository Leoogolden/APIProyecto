﻿using ApiEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiEjemplo.Data
{
    public class ActividadData
    {

        private static string conexionString = "Server=10.128.8.16;Database=VoyBD;User ID=usr_voybd ;pwd=proyectoort2019+ ;";
        private static SqlConnection Conectar()
        {
            SqlConnection a = new SqlConnection(conexionString);
            a.Open();
            return a;
        }
        private static void Desconectar(SqlConnection conector)
        {
            conector.Close();
        }
        public static int insertarActividad(string nombre, string descripcion, int edadMin, int edadMax, int limPer, string calle, int direccion, DateTime fecha, int idgrupo, int idus)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "AgregarActivDelGrupo";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Fecha", fecha);
            consulta.Parameters.AddWithValue("@EdadMin", edadMin);
            consulta.Parameters.AddWithValue("@EdadMax",edadMax );
            consulta.Parameters.AddWithValue("@LimPer",limPer );
            consulta.Parameters.AddWithValue("@Calle",calle );
            consulta.Parameters.AddWithValue("@Dir",direccion );
            consulta.Parameters.AddWithValue("@Nom",nombre );
            consulta.Parameters.AddWithValue("@Desc",descripcion );
            consulta.Parameters.AddWithValue("@idgru", idgrupo);
            consulta.Parameters.AddWithValue("@idus", idus);
            int regsAfectados = Convert.ToInt32(consulta.ExecuteScalar());
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static List<Actividad> ActividadesGrupo (int idgru)
        {
            List<Actividad> listaactivs;
            listaactivs = new List<Actividad>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ActivsxGrupos";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idgru", idgru);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                Actividad n = new Actividad();
                n.IdActiv = Convert.ToInt32(dataReader["idactividad"]);
                n.Nombre=dataReader["nombre"].ToString();
                n.Descripcion=dataReader["descripcion"].ToString();
                n.Fecha=Convert.ToDateTime(dataReader["fecha"]);
                n.EdadMin=Convert.ToInt32(dataReader["edadmin"]);
                n.EdadMax=Convert.ToInt32(dataReader["edadmax"]);
                    n.LimPer=Convert.ToInt32(dataReader["limitepersonas"]);
                n.Calle=dataReader["calle"].ToString();
                n.Direccion=(Convert.ToInt32(dataReader["direccion"]));
                listaactivs.Add(n);
            }
            return listaactivs;
        }
        public static int ConfirmacionAsistencia(int idgrupo, int idactiv , int idus)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "AltaAsistencia";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idgru", idgrupo);
            consulta.Parameters.AddWithValue("@idactiv", idactiv);
            consulta.Parameters.AddWithValue("@idus", idus);
            int regsAfectados = Convert.ToInt32(consulta.ExecuteScalar());
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static List<Usuario> ObtenerParticipantesActiv(int id)
        {
            List<Usuario> aux = new List<Usuario>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ListaParticipanActiv";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@IdActiv", id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                Usuario m = new Usuario();
                m.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                m.Nombre = dataReader["Nombre"].ToString();
                m.Mail = dataReader["Mail"].ToString();
                m.NombreUsuario = dataReader["Usuario"].ToString();
                m.Contraseña = dataReader["Contraseña"].ToString();
                m.NroTelefono = Convert.ToInt32(dataReader["NumeroTelefono"]);
                m.Edad = Convert.ToInt32(dataReader["Edad"]);
                aux.Add(m);
            }
            Desconectar(Conexion);
            return aux;
        }
        public static List<Actividad> TraerActividades()
        {
            List<Actividad> listaactivs;
            listaactivs = new List<Actividad>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "TraerActivs";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                Actividad n = new Actividad();
                n.IdActiv = Convert.ToInt32(dataReader["idactividad"]);
                n.Nombre = dataReader["nombre"].ToString();
                n.Descripcion = dataReader["descripcion"].ToString();
                n.Fecha = Convert.ToDateTime(dataReader["fecha"]);
                n.EdadMin = Convert.ToInt32(dataReader["edadmin"]);
                n.EdadMax = Convert.ToInt32(dataReader["edadmax"]);
                n.LimPer = Convert.ToInt32(dataReader["limitepersonas"]);
                n.Calle = dataReader["calle"].ToString();
                n.Direccion = (Convert.ToInt32(dataReader["direccion"]));
                listaactivs.Add(n);
            }
            Desconectar(Conexion);
            return listaactivs;
        }

        public static Grupos ObtenerGrupo(int id)
        {

            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "TraerGrupoDeActiv";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idactiv", id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            Grupos g = new Grupos();
            while (dataReader.Read()) { 
                      
                      g.Nombre = dataReader["Nombre"].ToString();
                      g.Descripcion = dataReader["Descripcion"].ToString();
                      g.IdGrupo = Convert.ToInt32(dataReader["IdGrupo"]);
            }
            
            Desconectar(Conexion);
            return g;
        }
        public static int BajaActividad(int idus, int idac) 
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "BajaActiv";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idactiv", idac);
            consulta.Parameters.AddWithValue("@idus", idus);
            int regsAfectados = Convert.ToInt32(consulta.ExecuteScalar());
            Desconectar(Conexion);
            return regsAfectados;
        }
    }
}