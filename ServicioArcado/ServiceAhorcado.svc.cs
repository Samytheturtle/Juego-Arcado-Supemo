using ServicioArcado.Modelo.DAO;
using ServicioArcado.Modelo.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioArcado
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceAhorcado" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceAhorcado.svc o ServiceAhorcado.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceAhorcado : IServiceAhorcado
    {
        public Boolean ActualizarProgresoPartida(char letra, int verificacion, int idPartida)
        {
            Boolean respuesta = PartidaDAO.ActualizarProgresoPartida(letra, verificacion, idPartida);
            return respuesta;
        }

        public string ModificarJugador(Jugador editarJugador, string idJugador)
        {
            string modificar = JugadorDAO.ModificarJugador(editarJugador, idJugador);
            return modificar;
        }

        public Jugador recuperarJugador(string idJugador)
        {
            Jugador jugador = new Jugador();
            jugador = JugadorDAO.RecuperarJugador(idJugador);
            return jugador;
        }

        List<Partida> IServiceAhorcado.RecuperarPartidasDisponibles()
        {
            return RecuperarTodasLasPartidasDisponibles();
        }

        private List<Partida> RecuperarTodasLasPartidasDisponibles()
        {
            List<Partida> partidas = new List<Partida>();
            partidas = PartidaDAO.RecuperarPartidasDisponibles();
            return partidas;
        }

        List<PartidaGanada> IServiceAhorcado.RecuperarPartidasJugador(string idJugador)
        {
            return RecuperarPartidasGanadasJugador(idJugador);
        }

        private List<PartidaGanada> RecuperarPartidasGanadasJugador(string idJugador)
        {
            List<PartidaGanada> partidas = PartidaDAO.RecuperarPartidasJugador(idJugador);
            return partidas;
        }

        public string RegistrarPartida(string fecha, int idRetador, int idPalabra)
        {
            string respuesta = PartidaDAO.RegistrarPartida(fecha, idRetador, idPalabra);
            return respuesta;
        }

        public int VerificarJugador(string correo, string password)
        {
            int idJugador = JugadorDAO.VerificarJugador(correo, password);
            return idJugador;
        }

        public string RegistrarJugador(Jugador jugador)
        {
            string registrar = JugadorDAO.RegistrarJugador(jugador);
            return registrar;
        }

        public string RegistrarJugadorEnPartida(int idPartida, int idJugador)
        {
            return PartidaDAO.RegistrarJugadorEnPartida(idPartida, idJugador);
        }

        public Categoria RecuperarCategoria(int idCategoria)
        {
            return CategoriaDAO.RecuperarCategoria(idCategoria);
        }

        public Palabra RecuperarPalabra(int idPalabra)
        {
            return PalabraDAO.RecuperarPalabra(idPalabra);
        }

        public string ActualizarPuntos(int idJugador, int puntosNuevos)
        {
            return JugadorDAO.ActualizarPuntos(idJugador, puntosNuevos);
        }

        public bool ActualizarEstadoPartida(int estado, int idPartida)
        {
            return PartidaDAO.ActualizarEstadoPartida(estado, idPartida);
        }
    }
}
