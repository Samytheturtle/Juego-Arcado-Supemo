using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioArcado.Modelo.POCO
{
    public class Palabra
    {
        public int IdPalabra { get; set; }
        public string palabra { get; set; }
        public string descripcion { get; set; }
        public string dificultad { get; set; }
        public int IdCategoria { get; set; }
    }
}