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
            String direccion = "ahorcadoSprite2.png";

            BitmapImage sprite = new BitmapImage();
            sprite.BeginInit();
            sprite.UriSource = new Uri(direccion, UriKind.Relative);
            sprite.EndInit();
            spriteAhorcado.Source = sprite;

        }

        private void clickBtnIncorrecto(object sender, RoutedEventArgs e)
        {
            lbProgresoPalabra.Content = "- - - - - - - - -";
            //< Image x: Name = "spriteAhorcado" Source = "/ahorcado_sprite_1.png" HorizontalAlignment = "Left" Height = "338" Width = "338" Margin = "302,0,0,0" Grid.Row = "1" VerticalAlignment = "Top" />
            //        <Rectangle x:Name="spriteAhorcado" HorizontalAlignment="Left" Height="338" Width="338" Margin="302,0,0,0" Grid.Row="1" Stroke="Black" VerticalAlignment="Top"/>
            //"C:/Users/ThinkPad/Source/Repos/Samytheturtle/Juego-Arcado-Supemo/JuegoArcado/ImagenesJuegos/AhorcadoSprites/ahorcado_sprite_7.png"
        }
    }
}
