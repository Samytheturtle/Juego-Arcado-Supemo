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
    public partial class AhorcadoRetador : Window
    {
        String palabraCompleta = "CASA";

        public Char letra = 'Z';
        public int muñeco = 1;
        public Char[] cadenaPalabraCompleta;

        public AhorcadoRetador()
        {
            
            InitializeComponent();
            cadenaPalabraCompleta = palabraCompleta.ToCharArray();
            lbPalabra.Content = palabraCompleta;
            Console.WriteLine(cadenaPalabraCompleta);
            Console.WriteLine(letra);
        }

        private void BtnCorrecto(object sender, RoutedEventArgs e)
        {
            Boolean existe = ComprobarLetra();
            if (existe)
            {
                lbInstruccionRetador.Content = "Colocando letras...";                
            }
            else
            {
                if (muñeco != 1) { muñeco--; }
                lbInstruccionRetador.Content = "PENALIZADO, Si existe " + letra;
                ColocarExtremidadAhorcado(muñeco);
            }
        }

        private void BtnIncorrecto(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(cadenaPalabraCompleta);
            Boolean existe = ComprobarLetra();
            if (!existe)
            {
                muñeco++;
                ColocarExtremidadAhorcado(muñeco);
            }
            else
            {
                if (muñeco != 1) { muñeco--; }
                lbInstruccionRetador.Content = "PENALIZADO, Si existe "+letra;
                ColocarExtremidadAhorcado(muñeco);
            }
        }

        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ColocarExtremidadAhorcado(int numSprite)
        {
            BitmapImage sprite = new BitmapImage();
            sprite.BeginInit();
            sprite.UriSource = new Uri("/AhorcadoSprite"+numSprite+".png", UriKind.Relative);
            sprite.EndInit();
            SpriteAhorcado.Source = sprite;
        }

        private Boolean ComprobarLetra()
        {
            Boolean existe = false;
            int i = 0;
            int tamanoCadena = cadenaPalabraCompleta.Length;
            tamanoCadena--;
            do
            {
                if (cadenaPalabraCompleta[i].Equals(letra))
                {
                    existe = true;
                }
                i++;

            } while (i <  tamanoCadena);
            return existe;
            
        }

        private void enviarProgresoPalabra(String progreso)
        {

        }
    }
}
