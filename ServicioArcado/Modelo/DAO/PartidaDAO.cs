using MySql.Data.MySqlClient;
using ServicioArcado.Modelo.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioArcado.Modelo.DAO
{
    public class PartidaDAO
    {
        public static String SELECT_PARTIDAS_DISPONIBLES = "SELECT idPartida, fecha, idRetador, idPalabra FROM partida WHERE idJugador = 0";


        public static string RegistrarPartida(String fecha, int idRetador, int idPalabra)
        {
            string partida = "";
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "INSERT partida SET fecha=@fecha, idRetador=@idRetador, idPalabra=@idPalabra";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@fecha", fecha);
                    mySqlCommand.Parameters.AddWithValue("@idRetador", idRetador);
                    mySqlCommand.Parameters.AddWithValue("@idPalabra", idPalabra);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        partida = "Partida Creada";
                    }
                    else
                    {
                        partida = "Partida No ha sido creada";
                    }

                }
                catch (Exception ex)
                {
                    partida = ex.Message;
                }
            }
            else
            {
                partida = "No hay conexión";
            }
            return partida;
        }

        public static Boolean ActualizarProgresoPartida(char letra, int validacion, string progresoPalabra, int idPartida)
        {
            Boolean respuestaConexion = false;
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "UPDATE partida SET letra=@letra, validacion=@validacion, progresoPalabra=@progresoPalabra where idPartida=@idPartida";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@letra", letra);
                    mySqlCommand.Parameters.AddWithValue("@validacion", validacion);
                    mySqlCommand.Parameters.AddWithValue("@progresoPalabra", progresoPalabra);
                    mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        respuestaConexion = true;
                    }
                    else
                    {
                        respuestaConexion = false;
                    }
                }
                catch (Exception ex)
                {
                    respuestaConexion = false;
                }
            }
            else
            {
                respuestaConexion = false;
            }
            return respuestaConexion;

        }



        public static List<Partida> RecuperarPartidasDisponibles()
        {
            List<Partida> partidasDisponibles = new List<Partida>();
            MySqlConnection conexion = ConexionBaseDatos.obtenerConexion();
            if (conexion != null)
            {
                try
                {
                    MySqlCommand sqlCommand = new MySqlCommand(SELECT_PARTIDAS_DISPONIBLES);
                    sqlCommand.Connection = conexion;
                    sqlCommand.Prepare();
                    MySqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Partida partida = new Partida();
                            partida.IdPartida = reader.GetUInt16(0);
                            partida.fecha = reader.GetString(1);
                            partida.idRetador = reader.GetInt16(2);
                            partida.idPalabra = reader.GetInt16(3);
                            partidasDisponibles.Add(partida);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    conexion.Close();
                }
            }
            return partidasDisponibles;
        }

        public static List<PartidaGanada> RecuperarPartidasJugador(string idJugador)
        {
            List<PartidaGanada> partidasGanadas = new List<PartidaGanada>();
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT fecha, nombre FROM partida INNER JOIN jugador ON partida.idRetador = jugador.IdJugador WHERE partida.idJugador = @idJugador AND estado = 1 ";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idJugador", idJugador);
                    mySqlCommand.Prepare();
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    if (respuestaBD.HasRows)
                    {
                        while (respuestaBD.Read())
                        {
                            PartidaGanada partidaGanadasRecuperadas = new PartidaGanada();
                            partidaGanadasRecuperadas.fechaPartida = respuestaBD.GetString(0);
                            partidaGanadasRecuperadas.jugadorVencido = respuestaBD.GetString(1);

                            partidasGanadas.Add(partidaGanadasRecuperadas);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return partidasGanadas;
        }

        public static string RegistrarJugadorEnPartida(int idPartida, int idJugador)
        {
            string partida = "";
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "UPDATE partida SET idJugador=@idJugador where idPartida=@idPartida";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idJugador", idJugador);
                    mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        partida = "Jugador Listo";
                    }
                    else
                    {
                        partida = "Jugador No listo";
                    }
                }
                catch (Exception ex)
                {
                    partida = ex.Message;
                }
            }
            else
            {
                partida = null;
            }
            return partida;
        }

        public static Boolean ActualizarEstadoPartida(int estado, int idPartida)
        {
            Boolean respuesta = false;
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "UPDATE partida SET estado=@estado WHERE idPartida=@idPartida";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@estado", estado);
                    mySqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    mySqlCommand.Prepare();
                    int resultado = mySqlCommand.ExecuteNonQuery();
                    respuesta = (resultado > 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return respuesta;
        }

        public static ProgresoPartida RecuperarProgresoPartida(int idPartida)
        {
            ProgresoPartida partida = null;
            MySqlConnection connection = ConexionBaseDatos.obtenerConexion();
            if (connection != null)
            {
                try
                {
                    string sql = "SELECT idPartida, letra, validacion, progresoPalabra, estado FROM partida WHERE idPartida = @idPartida";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    sqlCommand.Prepare();
                    MySqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        partida = new ProgresoPartida();
                        partida.idPartida = reader.GetInt32(0);
                        partida.letra = reader.GetChar(1);
                        partida.validacion = reader.GetInt32(2);
                        partida.progresoPalabra = reader.GetString(3);
                        partida.estado = reader.GetInt32(4);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return partida;
        }

        public static Partida RecuperarPartida(String fecha, int idRetador, int idPalabra)
        {
            Partida partida = null;
            MySqlConnection connection = ConexionBaseDatos.obtenerConexion();
            if (connection != null)
            {
                try
                {
                    string sql = "SELECT idPartida, fecha, idRetador, idJugador, idPalabra FROM partida WHERE fecha=@fecha and idRetador=@idRetador and idPalabra=@idPalabra";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@fecha", fecha);
                    sqlCommand.Parameters.AddWithValue("@idRetador", idRetador);
                    sqlCommand.Parameters.AddWithValue("@idPalabra", idPalabra);
                    sqlCommand.Prepare();
                    MySqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        partida = new Partida();
                        partida.IdPartida = reader.GetInt32(0);
                        partida.fecha = reader.GetString(1);
                        partida.idRetador = reader.GetInt32(2);
                        partida.idJugador = reader.GetInt32(3);
                        partida.idPalabra = reader.GetInt32(4);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return partida;
        }
        public static int RecuperarIdJugadorPartida(int idPartida)
        {
            int idJugador = 0;
            ProgresoPartida partida = null;
            MySqlConnection connection = ConexionBaseDatos.obtenerConexion();
            if (connection != null)
            {
                try
                {
                    string sql = "SELECT idJugador FROM partida WHERE idPartida = @idPartida";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    sqlCommand.Prepare();
                    MySqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        
                        idJugador = reader.GetInt32(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return idJugador;
        }
        public static int RecuperarIdRetadorPartida(int idPartida)
        {
            int idRetador = 0;
            ProgresoPartida partida = null;
            MySqlConnection connection = ConexionBaseDatos.obtenerConexion();
            if (connection != null)
            {
                try
                {
                    string sql = "SELECT idRetador FROM partida WHERE idPartida = @idPartida";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    sqlCommand.Prepare();
                    MySqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {

                        idRetador = reader.GetInt32(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return idRetador;
        }
        public static int RecuperarIdPalabraPartida(int idPartida)
        {
            int idPalabra = 0;
            ProgresoPartida partida = null;
            MySqlConnection connection = ConexionBaseDatos.obtenerConexion();
            if (connection != null)
            {
                try
                {
                    string sql = "SELECT idPalabra FROM partida WHERE idPartida = @idPartida";
                    MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@idPartida", idPartida);
                    sqlCommand.Prepare();
                    MySqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {

                        idPalabra = reader.GetInt32(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return idPalabra;
        }
    }
}