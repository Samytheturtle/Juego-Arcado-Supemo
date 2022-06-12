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

        private void BotonClicInicio(object sender, RoutedEventArgs e)
        {

        }
        
        private void BotonClicCancelar(object sender, RoutedEventArgs e)
        {

        }

        private void CajaDeTextoCorreo(object sender, RoutedEventArgs e)
        {
            CajaDTextoCorreo.Clear();


        }

        private void CajaDeTextoContrasenia(object sender, RoutedEventArgs e)
        { 
            CajaDTextoContrasenia.Clear();
        }
    }
}
