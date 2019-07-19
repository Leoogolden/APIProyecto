using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiEjemplo.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

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

        public static Usuario VerificarUsuario(string nombreus, string contra)
        {
            Usuario User = new Usuario();
            string contraseñaverif;
            contraseñaverif = CalculateMD5Hash(contra);
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "VerificarLogin";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Usuario", nombreus);
            consulta.Parameters.AddWithValue("@Contra", contraseñaverif);
            SqlDataReader Lector = consulta.ExecuteReader();
            if (Lector.Read())
            {
                User.IdUsuario = Convert.ToInt32(Lector["IdUsuario"]);
                User.Mail = Lector["Mail"].ToString();
                User.NombreUsuario = Lector["Usuario"].ToString();
                User.Nombre = Lector["Nombre"].ToString();
                User.Contraseña = Lector["Contraseña"].ToString();
                User.NroTelefono = Convert.ToInt32(Lector["NumeroTelefono"]);
                User.Edad = Convert.ToInt32(Lector["Edad"]);
            }
            return User;
        }
        public static List <Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "ListarUsuarios";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read()) {
                Usuario aux = new Usuario();
                aux.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                aux.Mail = dataReader["Mail"].ToString();
                aux.NombreUsuario = dataReader["Usuario"].ToString();
                aux.Nombre = dataReader["Nombre"].ToString();
                aux.Contraseña = dataReader["Contraseña"].ToString();
                aux.NroTelefono = Convert.ToInt32(dataReader["NumeroTelefono"]);
                aux.Edad = Convert.ToInt32(dataReader["Edad"]);
                lista.Add(aux);
            }
            Desconectar(Conexion);
                return lista;
        }

        public static string CalculateMD5Hash(string input){
            // step 1, calculate MD5 hash from input
                    MD5 md5 = System.Security.Cryptography.MD5.Create();
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                    byte[] hash = md5.ComputeHash(inputBytes);
                    // step 2, convert byte array to hex string
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }
                    return sb.ToString();
        }
        public static void CrearUsuario(String mail,String Nombre, String nombreus, String Contra, int NumTel, int Edad)
        {
            string contraseñaverif;
            contraseñaverif = CalculateMD5Hash(Contra);
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "CrearUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Usuario", nombreus);
            consulta.Parameters.AddWithValue("@Contraseña", contraseñaverif);
            consulta.Parameters.AddWithValue("@Mail", mail);
            consulta.Parameters.AddWithValue("@Nombre", Nombre);
            consulta.Parameters.AddWithValue("@NroTel",NumTel);
            consulta.Parameters.AddWithValue("@Edad",Edad);
            consulta.ExecuteNonQuery();
        }
        public static void CambiarContra(int id, String Contra)
        {
            string contraseñaverif;
            contraseñaverif = CalculateMD5Hash(Contra);
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "CambiarContrase";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@contra", contraseñaverif);
            consulta.Parameters.AddWithValue("@id", id);
            consulta.ExecuteNonQuery();
        }
    }
}