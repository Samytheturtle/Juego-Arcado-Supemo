using ServicioAhorcadoSupremo;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para PerfilPrincipal.xaml
    /// </summary>
    public partial class PerfilPrincipal : Window
    {
        private int idJugador;
        public PerfilPrincipal()
        {
            InitializeComponent();
        }
        public PerfilPrincipal(int idJugador)
        {
            InitializeComponent();
            this.idJugador = idJugador;
            MostrarDatosJugador();
            MostrarPartidasGanadas();
        }

        public void MostrarDatosJugador()
        {
            DateTime fecha;
            Jugador jugador = new Jugador();
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            jugador = serviceAhorcadoClient.recuperarJugadorAsync(idJugador.ToString()).Result;
            lbNombre.Content = jugador.Nombre + " " + jugador.Apellidos;
            lbCorreo.Content = jugador.CorreoElectronico;
            fecha = Convert.ToDateTime(jugador.FechaNacimiento);
            string fechaNacimiento = fecha.ToString("yyyy-MM-dd");
            lbFecha.Content = fechaNacimiento;
            lbCelular.Content = jugador.Celular;
            lbPunatje.Content = jugador.Puntaje;
        }

        public void MostrarPartidasGanadas()
        {
            DateTime fecha;
            PartidaGanada[] partidaGanadas;
            DataTable dataTable = new DataTable();
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServiceAhorcadoClient();
            partidaGanadas = serviceAhorcadoClient.RecuperarPartidasJugadorAsync(idJugador.ToString()).Result;
            dataTable.Columns.Add("Fecha Partida", typeof(string));
            dataTable.Columns.Add("Jugador Vencido", typeof(string));
            for(int i = 0; i < partidaGanadas.Length; i++)
            {
                MessageBox.Show(partidaGanadas.Length.ToString());
                fecha = Convert.ToDateTime(partidaGanadas[i].fechaPartida);
                dataTable.Rows.Add(fecha.ToString("yyyy-MM-dd") ,partidaGanadas[i].jugadorVencido);
            }
            dgPartidas.ItemsSource = dataTable.DefaultView;
            
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            ListaPartidas listaPartidas = new ListaPartidas(idJugador);
            this.Close();
            listaPartidas.Show();
        }
    }
}
