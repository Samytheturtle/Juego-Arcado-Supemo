using MySql.Data.MySqlClient;
using ServicioArcado.Modelo.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ServicioArcado.Modelo.DAO
{
    public class JugadorDAO
    {
        public static string ModificarJugador(Jugador editarJugador, string idJugador)
        {
            string jugador = "";
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "UPDATE jugador SET nombre=@nombre, apellidos=@apellidos, fechaNacimiento=@fechaNacimiento, celular=@celular, password=@password where idJugador=@idJugador";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nombre", editarJugador.Nombre);
                    mySqlCommand.Parameters.AddWithValue("@apellidos", editarJugador.Apellidos);
                    mySqlCommand.Parameters.AddWithValue("@fechaNacimiento", editarJugador.FechaNacimiento);
                    mySqlCommand.Parameters.AddWithValue("@celular", editarJugador.Celular);
                    mySqlCommand.Parameters.AddWithValue("@password", editarJugador.Password);
                    mySqlCommand.Parameters.AddWithValue("@idJugador", idJugador);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        jugador = "Jugador editado";
                    }
                    else
                    {
                        jugador = "Error al editar";
                    }
                }
                catch (Exception ex)
                {
                    jugador = ex.Message;
                }
            }
            else
            {
                jugador = "No hay conexión con la base";
            }
            return jugador;

        }

        public static Jugador RecuperarJugador(string idJugador)
        {
            Jugador consultarJugador = new Jugador();
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * from jugador where idJugador=@idJugador";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idJugador", idJugador);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    if (respuestaBD.Read())
                    {
                        consultarJugador.IdJugador = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        consultarJugador.Nombre = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        consultarJugador.Apellidos = (respuestaBD.IsDBNull(2) ? "" : respuestaBD.GetString(2));
                        consultarJugador.FechaNacimiento = (respuestaBD.IsDBNull(3) ?"": respuestaBD.GetString(3));
                        consultarJugador.Celular = ((respuestaBD.IsDBNull(4)) ? "" : respuestaBD.GetString(4));
                        consultarJugador.CorreoElectronico = ((respuestaBD.IsDBNull(5)) ? "" : respuestaBD.GetString(5));
                        consultarJugador.Password = ((respuestaBD.IsDBNull(6)) ? "" : respuestaBD.GetString(6));
                        consultarJugador.Puntaje = ((respuestaBD.IsDBNull(7)) ? 0 : respuestaBD.GetInt32(7));
                    }
                    else
                    {
                        consultarJugador = null;
                    }

                }
                catch (Exception ex)
                {
                    consultarJugador = null;
                }
            }
            else
            {
                consultarJugador = null;
            }

            return consultarJugador;
        }
    }
}