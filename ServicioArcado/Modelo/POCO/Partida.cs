using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioArcado.Modelo.POCO
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public string fecha{ get; set; }
        public int idRetador { get; set; }
        public int idJugador { get; set; }
        public int estado { get; set; }
        public int idPalabra { get; set; }
        public char letra { get; set; }
        public int validacion { get; set; }


    }
}