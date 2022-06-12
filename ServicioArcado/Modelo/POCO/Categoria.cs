using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioArcado.Modelo.POCO
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria{ get; set; }
        public string DescripcionCategoria { get; set; }
    }
}