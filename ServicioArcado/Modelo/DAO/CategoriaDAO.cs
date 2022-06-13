using MySql.Data.MySqlClient;
using ServicioArcado.Modelo.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioArcado.Modelo.DAO
{
    public class CategoriaDAO
    {
        public static Categoria RecuperarCategoria(int idCategoria)
        {
            Categoria recuperarCategoria = new Categoria();
            MySqlConnection conexionBD = ConexionBaseDatos.obtenerConexion();
            if (conexionBD != null)
            {
                try
                {
                    string sql = "SELECT * from categoria where idCategoria=@idCategoria";
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, conexionBD);
                    mySqlCommand.Parameters.AddWithValue("@idCategoria", idCategoria);
                    MySqlDataReader respuestaBD = mySqlCommand.ExecuteReader();
                    if (respuestaBD.Read())
                    {
                        recuperarCategoria.IdCategoria = ((respuestaBD.IsDBNull(0)) ? 0 : respuestaBD.GetInt32(0));
                        recuperarCategoria.NombreCategoria = ((respuestaBD.IsDBNull(1)) ? "" : respuestaBD.GetString(1));
                        recuperarCategoria.DescripcionCategoria = (respuestaBD.IsDBNull(2) ? "" : respuestaBD.GetString(2));
                    }
                    else
                    {
                        recuperarCategoria = null;
                    }
                }
                catch (Exception ex)
                {
                    recuperarCategoria = null;
                }
            }
            else
            {
                recuperarCategoria = null;
            }
            return recuperarCategoria;
        }
    }
}