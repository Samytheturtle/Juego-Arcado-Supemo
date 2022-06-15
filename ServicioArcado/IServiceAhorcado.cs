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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceAhorcado" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceAhorcado
    {
        [OperationContract]
        int VerificarJugador(string correo, string password);

        [OperationContract]
        string RegistrarJugador(Jugador jugador);

        [OperationContract]
        string ModificarJugador(Jugador editarJugador, string idJugador);

        [OperationContract]
        Jugador recuperarJugador(string idJugador);

        [OperationContract]
        string ActualizarPuntos(int idJugador, int puntosNuevos);

        [OperationContract]
        Boolean ActualizarProgresoPartida(char letra, int verificacion, string progresoPalabra, int idPartida);

        [OperationContract]
        string RegistrarPartida(String fecha, int idRetador, int idPalabra);

        [OperationContract]
        string RegistrarJugadorEnPartida(int idPartida, int idJugador);

        [OperationContract]
        List<Partida> RecuperarPartidasDisponibles();

        [OperationContract]
        List<PartidaGanada> RecuperarPartidasJugador(string idJugador);

        [OperationContract]
        Categoria RecuperarCategoria(int idCategoria);

        [OperationContract]
        Palabra RecuperarPalabra(int idPalabra);

        [OperationContract]
        Boolean ActualizarEstadoPartida(int estado, int idPartida);

        [OperationContract]
        ProgresoPartida RecuperarProgresoPartida(int idPartida);
        [OperationContract]
        Palabra RecuperarPalabraCategoria(int idCategoria);

    }
}
