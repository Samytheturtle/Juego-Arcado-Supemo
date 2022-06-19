using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioArcado.Modelo.POCO
{
    public class ProgresoPartida
    {
        public int idPartida { get; set; }
        public int estado { get; set; }
        public char letra { get; set; }
        public int validacion { get; set; }
        public string progresoPalabra { get; set; }

    }
}