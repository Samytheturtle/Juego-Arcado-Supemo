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
        public static int VerificarJugador(string correo, string password)
        {
            int idJugador = 0;
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * from jugador where correoElectronico=@correo AND password=@password";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@correo", correo);
                    mySqlCommand.Parameters.AddWithValue("@password", password);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    if (respuestaBD.Read())
                    {
                        idJugador = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                    }
                }
                catch (Exception ex)
                {
                    idJugador = 0;
                }
            }
            else
            {
                idJugador = 0;
            }

            return idJugador;
        }

        public static string RegistrarJugador(Jugador jugador)
        {
            string jugadorMensaje = "";
            //Mensaje mensaje = new Mensaje();
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    //fechaNacimiento=@fechaNacimiento, celular=@celular, password=@password where idJugador=@idJugador
                    string sentencia = "INSERT INTO jugador (nombre, apellidos, fechaNacimiento,celular,correoElectronico, password, puntaje) " +
                                       "VALUES(@nombre,@apellidos,@fechaNacimiento,@celular,@correoElectronico,@password,@puntaje)";
                    MySqlCommand mySqlCommand = new MySqlCommand(sentencia, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@nombre", jugador.Nombre);
                    mySqlCommand.Parameters.AddWithValue("@apellidos", jugador.Apellidos);
                    mySqlCommand.Parameters.AddWithValue("@fechaNacimiento", jugador.FechaNacimiento);
                    mySqlCommand.Parameters.AddWithValue("@celular", jugador.Celular);
                    mySqlCommand.Parameters.AddWithValue("@correoElectronico", jugador.CorreoElectronico);
                    mySqlCommand.Parameters.AddWithValue("@password", jugador.Password);
                    mySqlCommand.Parameters.AddWithValue("@puntaje", jugador.Puntaje);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        jugadorMensaje = "Usuario registrado con éxito";
                    }
                    else
                    {
                        jugadorMensaje = "Error al registrar el usuario";
                    }

                }
                catch (Exception ex)
                {
                    jugadorMensaje = ex.Message;
                }
            }
            else
            {
                jugadorMensaje = "Por el momento no hay conexión con los servicios...";
            }
            return jugadorMensaje;
        }

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

        public static string ActualizarPuntos(int idJugador, int puntosNuevos)
        {
            string puntos = "";
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "UPDATE jugador SET puntaje=@puntaje where idJugador=@idJugador";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@puntaje", puntosNuevos);
                    mySqlCommand.Parameters.AddWithValue("@idJugador", idJugador);
                    mySqlCommand.Prepare();
                    int filasAfectadas = mySqlCommand.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        puntos = "Puntos Actualizados";
                    }
                    else
                    {
                        puntos = "Puntos No Actualizados";
                    }
                }
                catch (Exception ex)
                {
                    puntos = ex.Message;
                }
            }
            else
            {
                puntos = "No hay conexión con la base";
            }
            return puntos;
        }
    }
}