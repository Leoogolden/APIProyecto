using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ApiEjemplo.Models;


namespace ApiEjemplo.Data
{
    public class InvitacionData
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

        public static List<Notificaciones> TraerInvitaciones(int idusuario)
        {
             List<Notificaciones> listainvitaciones;
            listainvitaciones = new List<Notificaciones>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "Notificaciones";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@IdUsuarioInvitado", idusuario);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                Notificaciones n= new Notificaciones();
                n.QuienInvita = dataReader["QuienInvito"].ToString();
                n.NombreGrupo = dataReader["QueGrupo"].ToString();
                listainvitaciones.Add(n);

            }
            return listainvitaciones;
        }
        public static int EnviarInvitacion(int a, int b, int c)
        {

        }


    }
}