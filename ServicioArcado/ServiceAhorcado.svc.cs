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
    }
}
