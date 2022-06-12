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
    /// Lógica de interacción para ListaPartidas.xaml
    /// </summary>
    public partial class ListaPartidas : Window
    {
        public ListaPartidas()
        {
            InitializeComponent();
        }

        private void BotonVerPerfil(object sender, RoutedEventArgs e)
        {
            PerfilPrincipal ventanaPerfilPrincial= new PerfilPrincipal();
            this.Close();
            ventanaPerfilPrincial.ShowDialog();
        }

        private void BotonVerPuntajeGlobal(object sender, RoutedEventArgs e)
        {
            VerPuntajes ventanaPuntajesglobales = new VerPuntajes();
            this.Close();
            ventanaPuntajesglobales.ShowDialog();
        }

        private void BotonCrearPartida(object sender, RoutedEventArgs e)
        {
            NuevaPartida ventanaNuevaPartida = new NuevaPartida();
            this.Close();
            ventanaNuevaPartida.ShowDialog();
        }

        private void BotonIniciarPartida(object sender, RoutedEventArgs e)
        {
           // dgPartidasJugadores
        }

        private void BotonModificarPerfil(object sender, RoutedEventArgs e)
        {

        }

        private void BotonSalir(object sender, RoutedEventArgs e)
        {

        }
    }
}
