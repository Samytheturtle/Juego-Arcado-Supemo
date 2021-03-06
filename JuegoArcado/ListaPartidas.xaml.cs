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
        public DispatcherTimer timer = new DispatcherTimer();

        //Timer timer;
        public ListaPartidas()
        {
            InitializeComponent();
        }
        public ListaPartidas(int idJugador)
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(7);
            timer.Tick += timer_tick;
            timer.Start();
            this.idJugador = idJugador;
            dataTable.Columns.Add("IdPartida", typeof(string));
            dataTable.Columns.Add("Fecha Partida", typeof(string));
            dataTable.Columns.Add("Nombre Retador", typeof(string));
            dataTable.Columns.Add("Correo Retador", typeof(string));
            dataTable.Columns.Add("Dificultad", typeof(string));
            
        }

        private void BotonVerPerfil(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            PerfilPrincipal ventanaPerfilPrincial= new PerfilPrincipal(idJugador);
            this.Close();
            ventanaPerfilPrincial.Show();
        }
        public Partida[] actualizarPartidas()
        {
            DateTime fecha;
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            Partida[] listaPartida;
            listaPartida = serviceAhorcadoClient.RecuperarPartidasDisponiblesAsync().Result;
            dataTable.Rows.Clear();
            for (int i = 0; i < listaPartida.Length; i++)
            {
                fecha = Convert.ToDateTime(listaPartida[i].fecha);
                string fechaPartida = fecha.ToString("yyyy-MM-dd");
                string idJugador = listaPartida[i].idRetador.ToString();
                string idPalabra = listaPartida[i].idPalabra.ToString();
                Palabra palabra = serviceAhorcadoClient.RecuperarPalabraAsync(int.Parse(idPalabra)).Result;
                Jugador jugador = serviceAhorcadoClient.recuperarJugadorAsync(idJugador).Result;
                dataTable.Rows.Add(listaPartida[i].IdPartida,fechaPartida, jugador.Nombre,jugador.CorreoElectronico,palabra.dificultad);
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
                dgPartidasJugadores.ItemsSource = "Error";
            }

        }

        private void BotonCrearPartida(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NuevaPartida ventanaNuevaPartida = new NuevaPartida(idJugador);
            this.Close();
            ventanaNuevaPartida.Show();
            
            
        }

        private void BotonIniciarPartida(object sender, RoutedEventArgs e)
        {
            if (dgPartidasJugadores.SelectedItems == null)
            {
                MessageBox.Show("Selecciona una partida", "Error");
            }
            else
            {
                timer.Stop();
                ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
                DataRowView dataRowView = (DataRowView)dgPartidasJugadores.SelectedItems[0];
                string idPartida = dataRowView["IdPartida"].ToString();
                AhorcadoJugador ahorcadoJugador = new AhorcadoJugador(idJugador, int.Parse(idPartida));
                serviceAhorcadoClient.RegistrarJugadorEnPartidaAsync(int.Parse(idPartida), idJugador);
                this.Close();
                ahorcadoJugador.Show();
                
            }
            
        }

        private void BotonModificarPerfil(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            EditarInformacionUsuario editarInformacionUsuario = new EditarInformacionUsuario(idJugador);
            this.Close();
            editarInformacionUsuario.Show();
            
        }

        private void BotonSalir(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            InicioSesion ventanaInicioSesion = new InicioSesion();
            this.Close();
            ventanaInicioSesion.Show();
            
        }
    }
}
