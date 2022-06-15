using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JuegoArcado
{
    /// <summary>
    /// Lógica de interacción para NuevaPartida.xaml
    /// </summary>
    public partial class NuevaPartida : Window
    {
        private int idJugador;
        public NuevaPartida()
        {
            InitializeComponent();
        }
        public NuevaPartida(int idJugador)
        {
            InitializeComponent();
        }

        public void RecuperarCategoria()
        {
            string categoria = cbCategoria.Text;
            if(categoria=="Ciencias Naturales")
            {

            }
        }
    }
}
