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
        public static int insertarActividad(string nombre, string descripcion, int edadMin, int edadMax, int limPer, string calle, int direccion, DateTime fecha)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "AgregarActiv";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Fecha", fecha);
            consulta.Parameters.AddWithValue("@EdadMin", edadMin);
            consulta.Parameters.AddWithValue("@EdadMax",edadMax );
            consulta.Parameters.AddWithValue("@LimPer",limPer );
            consulta.Parameters.AddWithValue("@Calle",calle );
            consulta.Parameters.AddWithValue("@Dir",direccion );
            consulta.Parameters.AddWithValue("@Nom",nombre );
            consulta.Parameters.AddWithValue("@Desc",descripcion );
            int regsAfectados = Convert.ToInt32(consulta.ExecuteScalar());
            Desconectar(Conexion);
            return regsAfectados;
        }

    }
}