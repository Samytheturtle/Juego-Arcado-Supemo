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
using JuegoArcado.VentanasDeAlerta;

namespace JuegoArcado
{
    /// <summary>
    /// Lógica de interacción para RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void cajaInteraccionNombre(object sender, RoutedEventArgs e)
        {
            cajaDTextoNombre.Clear();
        }

        private void cajaInteraccionTelefono(object sender, RoutedEventArgs e)
        {
            cajaDTextoTelfono.Clear();
        }

        private void cajaInteraccionApellidos(object sender, RoutedEventArgs e)
        {
           cajaDTextoApellidos.Clear();
        }

        private void cajaInteraccionCorreo(object sender, RoutedEventArgs e)
        {
            cajaDTextoCorreo.Clear();
        }

        private void cajaInteraccionContrasenia(object sender, RoutedEventArgs e)
        {
            cajaDTextoContrasenia.Clear();
        }

        private void botonClicCancelar(object sender, RoutedEventArgs e)
        {
            InicioSesion ventanaInicioSesion = new InicioSesion();
            this.Close();
            ventanaInicioSesion.ShowDialog();
        }

        private void botonClicRegistrarse(object sender, RoutedEventArgs e)
        {
            if (!validarCamposVacios())
            {
                AlertaExitoso ventanaAlertaExitoso = new AlertaExitoso();
                ventanaAlertaExitoso.ventanaApertura = 2;
                ventanaAlertaExitoso.labeltipoExito.Content = "REGISTRO EXITOSO";
                ventanaAlertaExitoso.LabeltextoAlerta.Content = "Jugador registrado al sistema exitosamente :D";
                this.Close();
                ventanaAlertaExitoso.ShowDialog();
            }
        }
        private Boolean validarCamposVacios()
        {
            Boolean camposVacios = false;
            if (cajaDTextoNombre.Text == "")
            {
                labelCamposInvalidosNombre.Content = "Por favor, introduzca un nombre";
                camposVacios = true;
            }
            if (cajaDTextoTelfono.Text == "")
            {
                labelCamposInvalidosTelefonos.Content = "Por favor, introduzca su telefono";
                camposVacios = true;
            }
            if (cajaDTextoApellidos.Text == "")
            {
                labelCamposInvalidosApellidos.Content = "Por favor, introduzca su apellido";
                camposVacios = true;
            }
            if (cajaDTextoCorreo.Text == "")
            {
                labelCamposInvalidosCorreo.Content = "Por favor, introduzca su correo";
                camposVacios = true;
            }
            if (cajaDTextoContrasenia.Text == "")
            {
                labelCamposInvalidosContrasenia.Content = "Por favor, introduzca su contraseña";
                camposVacios = true;
            }
            if (calendarioInformacion.SelectedDate==null)
            {
                labelCamposInvalidosCalendario.Content = "Por favor, introduzca una fecha";
                camposVacios = true;
            }
            return camposVacios;
        }
    }
}
