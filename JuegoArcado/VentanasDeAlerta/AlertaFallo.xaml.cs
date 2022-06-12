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

namespace JuegoArcado.VentanasDeAlerta
{
    /// <summary>
    /// Lógica de interacción para AlertaRegistroExitoso.xaml
    /// </summary>
    /// 
    
    public partial class AlertaFallo : Window
    {
        public int ventanaApertura;
        public AlertaFallo()
        {
            InitializeComponent();
        }
        private void BotonClicAceptar(object sender, RoutedEventArgs e)
        {
            switch (ventanaApertura)
            {
                case 1:
                    RegistroUsuario ventanaRegistroUsuario = new RegistroUsuario();
                    this.Close();
                    ventanaRegistroUsuario.ShowDialog();

                    break;
                case 2:
                    InicioSesion ventanaIniciarSesion = new InicioSesion();
                    this.Close();
                    ventanaIniciarSesion.ShowDialog();
                    break;

            }
        }
    }
}
