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

        public static int insertarGrupo(Grupos g)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "AgregarGrupo";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Nombre" , g.Nombre);
            consulta.Parameters.AddWithValue("@Descrpcion" , g.Descripcion);
            //int regsAfectados = consulta.ExecuteNonQuery();
            return consulta.ExecuteNonQuery();
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





    }
}