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
using ServicioAhorcadoSupremo;
using System.Windows.Threading;

namespace JuegoArcado
{  
    public partial class AhorcadoRetador : Window
    {
        public int idPartida = 1;
        public String palabraCompleta;
        public Char[] cadenaPalabraCompleta;

        public String progresoPalabra = "";
        public Char[] cadenaProgresoPalabra;

        public Char letra = 'A';
        public int progresoMuñeco = 1;
        public char guion = '-';
        public int validacion;

        public static int PALABRA_INCORRECTA = 0;
        public static int PALABRA_CORRECTA = 1;
        public static int PENALIZACION_RETADOR = 2;
        ServiceAhorcadoClient conexionServicio = new ServiceAhorcadoClient();

        DispatcherTimer timer = new DispatcherTimer();


        public AhorcadoRetador()
        {
            
            InitializeComponent();
            palabraCompleta = "WINDOWS";
            cadenaPalabraCompleta = palabraCompleta.ToCharArray();

            progresoPalabra = palabraCompleta;
            cadenaProgresoPalabra = progresoPalabra.ToCharArray();

            lbPalabra.Content = palabraCompleta;
            InicializarProgresoPalabra();

            timer.Interval = TimeSpan.FromSeconds(5);

            timer.Tick += ticker;
            timer.Start();
        }

        private void ticker(object? sender, EventArgs e)
        {
            ComprobarSiHayNuevaLetra();
        }

        private void ComprobarSiHayNuevaLetra()
        {
            if(conexionServicio != null)
            {
                ProgresoPartida progresoPartida = conexionServicio.RecuperarProgresoPartidaAsync(idPartida).Result;
                if(progresoPartida != null)
                {
                    Char letranueva = progresoPartida.letra;
                    if(letra != letranueva && letranueva != guion)
                    {
                        RecibirLetra(letranueva);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo comprobar la letra del jugador", "Error de Conexión");
                    timer.Stop();
                }
            }
            else
            {
                MessageBox.Show("Por el momento no se puede enviar la solicitud", "Error de Solicitud");
                timer.Stop();
            }
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
                lbInstruccionRetador.Content = "Letras Colocadas, Esperando al Jugador...";
                validacion = PALABRA_CORRECTA;
            }
            else
            {
                lbInstruccionRetador.Content = "PENALIZADO, "+palabraCompleta+" No contiene la letra " + letra;
                if (progresoMuñeco != 1) { progresoMuñeco--; }
                validacion = PENALIZACION_RETADOR;
            }
            ActualizarProgreso();
        }

        private void ClickBtnIncorrecto(object sender, RoutedEventArgs e)
        {
            BtnCorrecto.IsEnabled = false;
            BtnIncorrecto.IsEnabled = false;
            Boolean existe = ComprobarLetra();
            if (!existe)
            {
                lbInstruccionRetador.Content = "Extremidad Colocada, Esperando al Jugador...";
                progresoMuñeco++;
                validacion = PALABRA_INCORRECTA;
            }
            else
            {             
                lbInstruccionRetador.Content = "PENALIZADO, " + palabraCompleta + " Si Contiene la letra " + letra;
                if (progresoMuñeco != 1) { progresoMuñeco--; }             
                validacion = PENALIZACION_RETADOR;
            }
            ActualizarProgreso();
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

            } while (i < tamanoCadena);
            return existe;

        }

        private void ActualizarProgreso()
        {
            if (conexionServicio != null)
            {

                Boolean resultado = conexionServicio.ActualizarProgresoPartidaAsync(guion, validacion, progresoPalabra, idPartida).Result;
                if (resultado)
                {
                    ColocarExtremidadAhorcado(progresoMuñeco);
                    lbProgresoPalabra.Content = ColocarLetrasAPalabra();
                }
                else
                {
                    MessageBox.Show("No se pudo conectar con la base de datos", "Error de conexion");
                }
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el progreso.","Error en la peticion");
            }
        }

        private void ColocarExtremidadAhorcado(int numSprite)
        {
            BitmapImage sprite = new BitmapImage();
            sprite.BeginInit();
            sprite.UriSource = new Uri("/AhorcadoSprite" + numSprite + ".png", UriKind.Relative);
            sprite.EndInit();
            SpriteAhorcado.Source = sprite;
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

        

        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
