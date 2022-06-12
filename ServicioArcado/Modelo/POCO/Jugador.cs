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
        public string Celular { get; set; }
        public string CorreoElectronico { get; set; }
        public string Password { get; set; }
        public int Puntaje { get; set; }
    }
}