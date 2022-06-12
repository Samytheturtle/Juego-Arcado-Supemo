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
        public String palabraCompleta = "CASA";
        public Char[] cadenaPalabraCompleta;

        public String progresoPalabra = "";
        public Char[] cadenaProgresoPalabra;

        public Char letra = 'Z';
        public int progresoMuñeco = 1;
 

        public AhorcadoRetador()
        {
            
            InitializeComponent();
            cadenaPalabraCompleta = palabraCompleta.ToCharArray();
            lbPalabra.Content = palabraCompleta;
            Console.WriteLine(cadenaPalabraCompleta);
            Console.WriteLine(letra);
        }

        private void ClickBtnCorrecto(object sender, RoutedEventArgs e)
        {
            BtnCorrecto.IsEnabled = false;
            BtnIncorrecto.IsEnabled = false;
            Boolean existe = ComprobarLetra();
            if (existe)
            {
                lbInstruccionRetador.Content = "Colocando letras...";                
            }
            else
            {
                if (progresoMuñeco != 1) { progresoMuñeco--; }
                lbInstruccionRetador.Content = "PENALIZADO, "+palabraCompleta+" No contiene la letra " + letra;
                ColocarExtremidadAhorcado(progresoMuñeco);
            }
        }

        private void ClickBtnIncorrecto(object sender, RoutedEventArgs e)
        {
            BtnCorrecto.IsEnabled = false;
            BtnIncorrecto.IsEnabled = false;
            Boolean existe = ComprobarLetra();
            if (!existe)
            {
                lbInstruccionRetador.Content = "Colocando Extremidad...";
                progresoMuñeco++;
                ColocarExtremidadAhorcado(progresoMuñeco);
                //ActualizarProgresoJugador(muñeco, palabraActualizada);
            }
            else
            {
                if (progresoMuñeco != 1) { progresoMuñeco--; }
                lbInstruccionRetador.Content = "PENALIZADO, " + palabraCompleta + " Si Contiene la letra " + letra;
                ColocarExtremidadAhorcado(progresoMuñeco);
            }
        }

        private void EnviarProgresoPalabra(String progreso)
        {

            //EnviarProgreso(estadoMuñeco, progresoPalabra
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

        private String ColocarLetrasAPalabra()
        {
            String palabraActualizada = "";


            return palabraActualizada;
        }

        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            BtnCorrecto.IsEnabled = true;
            BtnIncorrecto.IsEnabled = true;
            //this.Close();
        }
    }
}
