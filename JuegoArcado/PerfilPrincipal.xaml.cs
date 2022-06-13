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
        }

        public void MostrarDatosJugador()
        {
            Jugador jugador = new Jugador();
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            jugador = serviceAhorcadoClient.recuperarJugadorAsync(idJugador.ToString()).Result;
            lbNombre.Content = jugador.Nombre + " " + jugador.Apellidos;
            lbCorreo.Content = jugador.CorreoElectronico;
            lbFecha.Content = jugador.FechaNacimiento;
            lbCelular.Content = jugador.Celular;
        }

        public void MostrarPartidasGanadas()
        {

        }
    }
}
