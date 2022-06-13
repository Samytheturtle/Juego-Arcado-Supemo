using ServicioAhorcadoSupremo;
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
    /// Lógica de interacción para EditarInformacionUsuario.xaml
    /// </summary>
    public partial class EditarInformacionUsuario : Window
    {
        private string idJugador;
        public EditarInformacionUsuario(string idJugador)
        {
            InitializeComponent();
            this.idJugador = idJugador;
            mostrarDatos();
        }
        public EditarInformacionUsuario()
        {
            InitializeComponent();
        }

        private void ActualizarInformacionJugador(object sender, RoutedEventArgs e)
        {
            Jugador actualizarJugador = new Jugador();
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();

            serviceAhorcadoClient.ModificarJugadorAsync(actualizarJugador,idJugador);
        }

        private void mostrarDatos()
        {
            Jugador recuperarDatosJugador = new Jugador();
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            recuperarDatosJugador = serviceAhorcadoClient.recuperarJugadorAsync(idJugador).Result;
            tbNombre.Text = recuperarDatosJugador.Nombre;
            tbApellidos.Text = recuperarDatosJugador.Apellidos;
            tbCelular.Text = recuperarDatosJugador.Celular;
            tbContrasena.Text = recuperarDatosJugador.Password;
            cFechaNacimiento.SelectedDate = DateTime.Parse(recuperarDatosJugador.FechaNacimiento);
        }
    }
}
