using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioArcado.Modelo
{
    public class ConexionBaseDatos
    {
        private static string SERVIDOR = "ahorcado.mysql.database.azure.com";
        private static string PUERTO = "3306";
        private static string BASE_DATOS = "ahorcado";
        private static string USUARIO_BD = "ElderBike4";
        private static string PASSWORD = "Ahorcado25";

        public static MySqlConnection obtenerConexion()
        {
            MySqlConnection conexionBD = null;
            try
            {
                string urlConexion = string.Format("server={0};" +
                                                   "database={1};" +
                                                   "username={2};" +
                                                   "password={3};" +
                                                   "port={4};", SERVIDOR, BASE_DATOS,
                                                   USUARIO_BD, PASSWORD, PUERTO);
                conexionBD = new MySqlConnection(urlConexion);
                conexionBD.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conexionBD = null;
            }
            return conexionBD;
        }
    }
}