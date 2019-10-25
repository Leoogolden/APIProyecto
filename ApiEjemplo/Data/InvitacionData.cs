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
                n.id = Convert.ToInt32(dataReader["idinv"]);
                n.QuienInvita = dataReader["QuienInvito"].ToString();
                n.NombreGrupo = dataReader["QueGrupo"].ToString();
                listainvitaciones.Add(n);

            }
            return listainvitaciones;
        }
        public static int EnviarInvitacion(int a, int b, int c)
        {

                SqlConnection Conexion = Conectar();
                SqlCommand consulta = Conexion.CreateCommand();
                consulta.CommandText = "InvitarAlGrupo";
                consulta.CommandType = System.Data.CommandType.StoredProcedure;
                consulta.Parameters.AddWithValue("@fkGrupo", a);
                consulta.Parameters.AddWithValue("@fkUsuarioInvitante", b);
                consulta.Parameters.AddWithValue("@fkUsuarioInvitado", c);
                //int regsAfectados = consulta.ExecuteNonQuery();
                return consulta.ExecuteNonQuery();
        }



        public static int AceptarInvitacion(int a, bool b)
        {

            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "EliminarInvitacion";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@IdInvitacion", a);
            consulta.Parameters.AddWithValue("@acepta", b);
            return consulta.ExecuteNonQuery();
        }
        public static int SolicitaUnirse (int idgru, int idsolicita)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "SolicitaUnirse";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@idgrupo", idgru);
            consulta.Parameters.AddWithValue("@idsolicitante", idsolicita);
            return consulta.ExecuteNonQuery();
        }



    }
}