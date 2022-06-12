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

namespace JuegoArcado
{  
    public partial class AhorcadoRetador : Window
    {
        public String palabraCompleta;
        public Char[] cadenaPalabraCompleta;

        public String progresoPalabra = "";
        public Char[] cadenaProgresoPalabra;

        public Char letra = ' ';
        public int progresoMuñeco = 2;
        public char guion = '-';
 

        public AhorcadoRetador()
        {
            
            InitializeComponent();
            palabraCompleta = "WINDOWS";
            cadenaPalabraCompleta = palabraCompleta.ToCharArray();

            progresoPalabra = palabraCompleta;
            cadenaProgresoPalabra = progresoPalabra.ToCharArray();

            lbPalabra.Content = palabraCompleta;
            InicializarProgresoPalabra();
            
        }

        private void InicializarDatos(String nombreJugador, String palabra)
        {
            lbNombreJugador.Content = nombreJugador;
            palabraCompleta = palabra;
        }

        private void InicializarProgresoPalabra()
        {
            progresoPalabra = "";
            for(int i = 0; i < palabraCompleta.Length; i++)
            {
                cadenaProgresoPalabra[i] = guion;
                progresoPalabra = progresoPalabra + " " + cadenaProgresoPalabra[i];
            }
            lbProgresoPalabra.Content = progresoPalabra;
        }

        public void RecibirLetra(Char nuevaLetra)
        {
            letra = nuevaLetra;
            lbInstruccionRetador.Content = "El Jugador ha seleccionado la letra "+nuevaLetra;
            BtnCorrecto.IsEnabled = true;
            BtnIncorrecto.IsEnabled = true;
        }


        private void ClickBtnCorrecto(object sender, RoutedEventArgs e)
        {
            BtnCorrecto.IsEnabled = false;
            BtnIncorrecto.IsEnabled = false;
            Boolean existe = ComprobarLetra();
            if (existe)
            {
                ActualizarProgreso();
                lbInstruccionRetador.Content = "Colocando letras...";                
            }
            else
            {
                if (progresoMuñeco != 1) { progresoMuñeco--; }
                lbInstruccionRetador.Content = "PENALIZADO, "+palabraCompleta+" No contiene la letra " + letra;
                ColocarExtremidadAhorcado(progresoMuñeco);
                ActualizarProgreso();
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
                ActualizarProgreso();
            }
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
            progresoPalabra = "";
            for(int i = 0; i < cadenaPalabraCompleta.Length; i++)
            {
                if (cadenaPalabraCompleta[i].Equals(letra)){
                    cadenaProgresoPalabra[i] = letra;
                }
                progresoPalabra = progresoPalabra + " " + cadenaProgresoPalabra[i];
            }

            return progresoPalabra;
        }

        private void ActualizarProgreso()
        {            
            lbProgresoPalabra.Content = ColocarLetrasAPalabra();
            //ActualizarProgresoJugador(progresoMuñeco, progresoPalabra);
        }

        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            RecibirLetra('H');
            //BtnCorrecto.IsEnabled = true;
            //BtnIncorrecto.IsEnabled = true;
            //this.Close();
        }
    }
}
