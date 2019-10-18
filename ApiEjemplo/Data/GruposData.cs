using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ApiEjemplo.Models;

namespace ApiEjemplo.Data
{
    public class GruposData
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

        public static int insertarGrupo(string Nombre, string Descripcion, int idUsuario)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "AgregarGrupo";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Nombre" , Nombre);
            consulta.Parameters.AddWithValue("@Descrpcion" , Descripcion);
            consulta.Parameters.AddWithValue("@idus", idUsuario);
            int regsAfectados = Convert.ToInt32(consulta.ExecuteScalar());
            Desconectar(Conexion);
            return regsAfectados;
        }
        public static bool EsAdmin(int idus, int idgrupo)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "EsAdminDelGrupo";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@id", idus);
            consulta.Parameters.AddWithValue("@idgrupo", idgrupo);
            bool asd = false;
            int quepaso = Convert.ToInt32(consulta.ExecuteScalar());
            if (quepaso == 0){
                asd = true;
            }

            Desconectar(Conexion);
            return asd;
        }
        public static bool EstaEnGrupo(int idus, int idgrupo)
        {
            bool blnReturnValue = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "EstaEnGrupo";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idGrupo"     , idgrupo);
            consulta.Parameters.AddWithValue("@idUsuario"   , idus);

            try
            {
                blnReturnValue = Convert.ToBoolean(consulta.ExecuteScalar());
            }
            catch (Exception e)
            {

            }
            
            Desconectar(Conexion);
            return blnReturnValue;
        }


        public static int EditarGrupo(int id, int idgru, String nombre, String desc)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "EditarGrupo";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idgru", idgru);
            consulta.Parameters.AddWithValue("@nombre", nombre);
            consulta.Parameters.AddWithValue("@desc", desc);
            int regsAfectados = Convert.ToInt32(consulta.ExecuteScalar());
            Desconectar(Conexion);
            return regsAfectados;
        }


        public static List<Grupos> ObtenerGruposxUsuario(int id)
        {
            List<Grupos> aux = new List<Grupos>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ListarGruposxUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idus", id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while(dataReader.Read())
            {
                Grupos g = new Grupos();
                g.Nombre = dataReader["Nombre"].ToString();
                
                g.Descripcion = dataReader["Descripcion"].ToString();
                g.IdGrupo = Convert.ToInt32(dataReader["IdGrupo"]);
                aux.Add(g);
            }
            Desconectar(Conexion);
            return aux;
        }
        public static List<Usuario> ObtenerMiembrosGrupo(int id)
        {
            List<Usuario> aux = new List<Usuario>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ListarMiembrosDelGrupo";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                Usuario m = new Usuario();
                m.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                m.Nombre = dataReader["Nombre"].ToString();
                m.Mail = dataReader["Mail"].ToString();
                m.NombreUsuario= dataReader["Usuario"].ToString();
                m.Contraseña = dataReader["Contraseña"].ToString();
                m.NroTelefono = Convert.ToInt32(dataReader["NumeroTelefono"]);
                m.Edad= Convert.ToInt32(dataReader["Edad"]);
                aux.Add(m);
            }
            Desconectar(Conexion);
            return aux;
        }
        public static int EliminarDelGrupo(int idus, int idgru) 
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "EliminarDelGrupo";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idgru", idgru);
            consulta.Parameters.AddWithValue("@idus", idus);
            int regsAfectados = Convert.ToInt32(consulta.ExecuteScalar());

            Desconectar(Conexion);
            return regsAfectados;
        }
        public static int HacerAdmin(int idus, int idgru)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "HacerAdmin";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idgru", idgru);
            consulta.Parameters.AddWithValue("@idus", idus);
            int regsAfectados = Convert.ToInt32(consulta.ExecuteScalar());

            Desconectar(Conexion);
            return regsAfectados;


        }

    }
}