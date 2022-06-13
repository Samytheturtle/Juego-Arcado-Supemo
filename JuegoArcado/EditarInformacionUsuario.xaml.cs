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
        public string idJugador;
        Jugador recuperarDatosJugador = new Jugador();
        public EditarInformacionUsuario()
        {
            InitializeComponent();
            MostrarDatos();
        }
        public EditarInformacionUsuario(int idJugador)
        {
            InitializeComponent();
            this.idJugador = idJugador.ToString();
            MostrarDatos();
        }

        private void ActualizarInformacionJugador(object sender, RoutedEventArgs e)
        {
            Jugador actualizarJugador = new Jugador();
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            if (RecuperarDatos() == true)
            {
                actualizarJugador = recuperarDatosJugador;
                serviceAhorcadoClient.ModificarJugadorAsync(actualizarJugador, idJugador);
                MessageBox.Show("Jugador actualizado", "Aviso");
                ListaPartidas listaPartidas = new ListaPartidas(int.Parse(idJugador));
                this.Close();
                listaPartidas.Show();
            }
           
        }

        private void MostrarDatos()
        {
            
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            recuperarDatosJugador = serviceAhorcadoClient.recuperarJugadorAsync(idJugador).Result;
            tbNombre.Text = recuperarDatosJugador.Nombre;
            tbApellidos.Text = recuperarDatosJugador.Apellidos;
            tbCelular.Text = recuperarDatosJugador.Celular;
            tbContrasena.Text = recuperarDatosJugador.Password;
            
        }

        private Boolean RecuperarDatos()
        {
            Boolean validacion = false;
            if (tbNombre.Text.Equals(""))
            {
                MessageBox.Show("Nombre no puede ser vacio", "Error");
                validacion = false;
            }
            else
            {
                recuperarDatosJugador.Nombre = tbNombre.Text;
                validacion = true;
            }
            if (tbApellidos.Text.Equals(""))
            {
                MessageBox.Show("Apellidos no puede ser vacio", "Error");
                validacion = false;
            }
            else
            {
                recuperarDatosJugador.Apellidos = tbApellidos.Text;
                validacion = true;
            }
            if (tbCelular.Text.Equals(""))
            {
                MessageBox.Show("Celular no puede ser vacio", "Error");
                validacion = false;
            }
            else
            {
                recuperarDatosJugador.Celular = tbCelular.Text;
                validacion = true;
            }
            if (cFechaNacimiento.SelectedDate==null)
            {
                MessageBox.Show("Seleccione la fecha", "Error");
                validacion = false;
            }
            else
            {
                recuperarDatosJugador.FechaNacimiento = cFechaNacimiento.SelectedDate.ToString();
                validacion = true;
            }
            return validacion;
        }

        private void CancelarActualizacion(object sender, RoutedEventArgs e)
        {
            ListaPartidas listaPartidas = new ListaPartidas(int.Parse(idJugador));
            this.Close();
            listaPartidas.Show();

        }
    }
}
