using MySql.Data.MySqlClient;
using ServicioArcado.Modelo.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioArcado.Modelo.DAO
{
    public class PalabraDAO
    {
        public static Palabra RecuperarPalabra(int idPalabra)
        {
            Palabra recuperarPalabra = new Palabra();
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * from palabra where idPalabra=@idPalabra";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idPalabra", idPalabra);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    if (respuestaBD.Read())
                    {
                        recuperarPalabra.IdPalabra = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        recuperarPalabra.palabra = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        recuperarPalabra.descripcion = (respuestaBD.IsDBNull(2) ? "" : respuestaBD.GetString(2));
                        recuperarPalabra.dificultad = (respuestaBD.IsDBNull(3) ? "" : respuestaBD.GetString(3));
                        recuperarPalabra.IdCategoria = (respuestaBD.IsDBNull(4) ? 0 : respuestaBD.GetInt32(4));
                    }
                    else
                    {
                        recuperarPalabra = null;
                    }
                }
                catch (Exception ex)
                {
                    recuperarPalabra = null;
                }
            }
            else
            {
                recuperarPalabra = null;
            }
            return recuperarPalabra;
        }

        public static List<Palabra> RecuperarPalabaraCategoria(int idCategoria)
        {
            List<Palabra> listaPalabaras = new List<Palabra>();
            
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * from palabra where idCategoria=@idCategoria";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idCategoria", idCategoria);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    while (respuestaBD.Read())
                    {
                        Palabra recuperarPalabra = new Palabra();
                        recuperarPalabra.IdPalabra = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        recuperarPalabra.palabra = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        recuperarPalabra.descripcion = (respuestaBD.IsDBNull(2) ? "" : respuestaBD.GetString(2));
                        recuperarPalabra.dificultad = (respuestaBD.IsDBNull(3) ? "" : respuestaBD.GetString(3));
                        recuperarPalabra.IdCategoria = (respuestaBD.IsDBNull(4) ? 0 : respuestaBD.GetInt32(4));
                        listaPalabaras.Add(recuperarPalabra);
                    }
                }
                catch (Exception ex)
                {
                    listaPalabaras = null;
                }
            }
            else
            {
                
            }
            return listaPalabaras;
        }
    }

   

}