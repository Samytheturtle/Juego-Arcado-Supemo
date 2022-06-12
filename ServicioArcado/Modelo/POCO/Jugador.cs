using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioArcado.Modelo.POCO
{
    public class Jugador
    {
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string FechaNacimiento { get; set; }
        public string celular { get; set; }
        public string correoElectronico { get; set; }
        public string password { get; set; }
        public int puntaje { get; set; }
    }
}