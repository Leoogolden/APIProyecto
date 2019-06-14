using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiEjemplo.Models;
using System.Data.SqlClient;

namespace ApiEjemplo.Data
{
    public class UsuarioData
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

        public static bool VerificarUsuario(string nombreus, string contra)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "VerificarLogin";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Usuario", nombreus);
            consulta.Parameters.AddWithValue("@Constra", contra);
            return (bool)consulta.ExecuteScalar();
        }

        
        
    }
}