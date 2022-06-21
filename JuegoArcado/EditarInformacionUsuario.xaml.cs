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
            cFechaNacimiento.SelectedDate = Convert.ToDateTime(recuperarDatosJugador.FechaNacimiento);
            
        }

        private Boolean RecuperarDatos()
        {
            Boolean validacion = false;
            if (tbNombre.Text.Equals(""))
            {
                MessageBox.Show("El nombre no se puede quedar vacío", "Campo Vacío");

            }else if (tbApellidos.Text.Equals(""))
            {
                MessageBox.Show("Los Apellidos no se pueden quedar vacíos", "Campo Vacío");

            }else if (tbCelular.Text.Equals(""))
            {
                MessageBox.Show("El Celular no puede ser vacío", "Campo Vacío");

            }else if (tbContrasena.Text.Equals("")){
                MessageBox.Show("La contraseña no puede ser vacia", "Campo Vacío");

            }else if (cFechaNacimiento.SelectedDate == null)
            {
                MessageBox.Show("Seleccione una fecha", "Fecha Vacía");
            }
            else
            {
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
