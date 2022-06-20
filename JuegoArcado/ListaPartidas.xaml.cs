using ServicioAhorcadoSupremo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace JuegoArcado
{
    /// <summary>
    /// Lógica de interacción para ListaPartidas.xaml
    /// </summary>
    public partial class ListaPartidas : Window
    {
        DataTable dataTable = new DataTable();
        public int idJugador;
        Timer timer;
        public ListaPartidas()
        {
            InitializeComponent();
        }
        public ListaPartidas(int idJugador)
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += timer_tick;
            timer.Start();
            this.idJugador = idJugador;
        }

        private void BotonVerPerfil(object sender, RoutedEventArgs e)
        {
            PerfilPrincipal ventanaPerfilPrincial= new PerfilPrincipal(idJugador);
            this.Close();
            ventanaPerfilPrincial.Show();
        }
        public Partida[] actualizarPartidas()
        {
            
            dataTable.Columns.Add("Fecha Partida", typeof(string));
            dataTable.Columns.Add("Nombre Retador", typeof(string));
            dataTable.Columns.Add("Correo Retador", typeof(string));
            dataTable.Columns.Add("Dificultad", typeof(string));
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            Partida[] listaPartida;
            listaPartida = serviceAhorcadoClient.RecuperarPartidasDisponiblesAsync().Result;
            for (int i = 0; i < listaPartida.Length; i++)
            {
                string idJugador = listaPartida[i].idRetador.ToString();
                string idPalabra = listaPartida[i].IdPartida.ToString();
                Palabra palabra = serviceAhorcadoClient.RecuperarPalabraAsync(int.Parse(idPalabra)).Result;
                Jugador jugador = serviceAhorcadoClient.recuperarJugadorAsync(idJugador).Result;
                dataTable.Rows.Add(listaPartida[i].fecha,jugador.Nombre,jugador.CorreoElectronico,palabra.dificultad);
            }
            return listaPartida;

        }
        void timer_tick(object sender, EventArgs e)
        {

           
            if (actualizarPartidas() != null)
            {
                dgPartidasJugadores.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                dgPartidasJugadores.ItemsSource = "Agua";
            }

        }
        private void BotonVerPuntajeGlobal(object sender, RoutedEventArgs e)
        {
            VerPuntajes ventanaPuntajesglobales = new VerPuntajes();
            this.Close();
            ventanaPuntajesglobales.ShowDialog();
        }

        private void BotonCrearPartida(object sender, RoutedEventArgs e)
        {
            NuevaPartida ventanaNuevaPartida = new NuevaPartida(idJugador);
            this.Close();
            ventanaNuevaPartida.Show();
            
        }

        private void BotonIniciarPartida(object sender, RoutedEventArgs e)
        {
           // dgPartidasJugadores
        }

        private void BotonModificarPerfil(object sender, RoutedEventArgs e)
        {
            EditarInformacionUsuario editarInformacionUsuario = new EditarInformacionUsuario(idJugador);
            this.Close();
            editarInformacionUsuario.Show();
        }

        private void BotonSalir(object sender, RoutedEventArgs e)
        {

        }
    }
}
