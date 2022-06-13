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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JuegoArcado.VentanasDeAlerta;
namespace JuegoArcado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class InicioSesion : Window
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void CajainteraccionCorreo(object sender, RoutedEventArgs e)
        {
            if (CajaDTextoContrasenia.Text == "")
            {
                CajaDTextoContrasenia.Text = "Ingresa tu contraseña";
            }
            else
            {
                CajaDTextoCorreo.Clear();
            }
        }

        private void CajainteraccionContrasenia(object sender, RoutedEventArgs e)
        {
            if (CajaDTextoCorreo.Text == "")
            {
                CajaDTextoCorreo.Text = "Correo electronico";
            }
            else
            {
                CajaDTextoContrasenia.Clear();
            }
        }

        private void BotonIniciarSesion(object sender, RoutedEventArgs e)
        {
            Boolean camposVacios = validarCamposVacios();
            validarCorreoContrasenia();
            if (!camposVacios)
            {
                AlertaExitoso ventanaAlertaExitoso = new AlertaExitoso();
                ventanaAlertaExitoso.ventanaApertura = 1;
                ventanaAlertaExitoso.labeltipoExito.Content = "INICIO DE SESION EXITOSO";
                ventanaAlertaExitoso.LabeltextoAlerta.Content = "Jugador ingreso al sistema exitosamente :D";
                this.Close();
                ventanaAlertaExitoso.ShowDialog();
            }
        }

        private void BotonClicRegistrarse(object sender, RoutedEventArgs e)
        {
            
            RegistroUsuario ventanaRegistroUsuario= new RegistroUsuario();
            this.Close();
            ventanaRegistroUsuario.ShowDialog();
        }
        private Boolean validarCamposVacios()
        {
            ServicioAhorcadoSupremo.ServiceAhorcadoClient serviceAhorcadoClient = new ServicioAhorcadoSupremo.ServiceAhorcadoClient();
            Boolean camposVacios = false;
            if (CajaDTextoCorreo.Text == "")
            {
                labelCamposInvalidosCorreo.Content="Por favor, introduzca un correo";
                camposVacios=true;
            }
            if (CajaDTextoContrasenia.Text == "")
            {
                labelCamposInvalidosContrasenia.Content = "Por favor, introduzca su contrasenia";
                camposVacios = true;
            }
            return camposVacios;
        }
        private void validarCorreoContrasenia()
        {

        }
    }
}
