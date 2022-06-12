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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Media;
//using JuegoArcado.AhorcadoSprites;

namespace JuegoArcado
{
    /// <summary>
    /// Lógica de interacción para AhorcadoRetador.xaml
    /// </summary>
    public partial class AhorcadoRetador : Window
    {

        public AhorcadoRetador()
        {
            
            InitializeComponent();

            String direccion = "/ImagenesJuegos/FondoAhorcado.jpg";
            BitmapImage sprite = new BitmapImage();
            sprite.BeginInit();
            sprite.UriSource = new Uri(direccion, UriKind.Relative);
            sprite.EndInit();
            ImagenJuego.Source = sprite;

        }

        private void clickBtnIncorrecto(object sender, RoutedEventArgs e)
        {
            lbProgresoPalabra.Content = "- - - - - - - - -";
            InitializeComponent();

            String direccion = "/ImagenesPartidas/ahorcadoSprite2.png";
            BitmapImage sprite = new BitmapImage();
            sprite.BeginInit();
            sprite.UriSource = new Uri(direccion, UriKind.Relative);
            sprite.EndInit();
            ImagenJuego.Source = sprite;
        }
    }
}
