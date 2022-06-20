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
        private int idRetador;
        private Partida partida;

        public int idPartida = 1;
        public Palabra palabra;
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
        public static int PARTIDA_PERDIDA = 3;
        public static int PARTIDA_GANADA = 4;
        ServiceAhorcadoClient conexionServicio = new ServiceAhorcadoClient();
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timerEsperaJugador = new DispatcherTimer();

        public static int ESTADO_PARTIDA_PERDIDA = 0;
        public static int ESTADO_PARTIDA_GANADA = 1;


        public AhorcadoRetador()
        {           
            InitializeComponent();
            /*
            palabraCompleta = "WINDOWS";
            cadenaPalabraCompleta = palabraCompleta.ToCharArray();
            progresoPalabra = palabraCompleta;
            cadenaProgresoPalabra = progresoPalabra.ToCharArray();
            lbPalabra.Content = palabraCompleta;
            InicializarProgresoPalabra();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += ticker;
            timer.Start();*/
        }
        public AhorcadoRetador(int idRetador, Partida partida)
        {

            InitializeComponent();
            this.idRetador = idRetador; 
            this.partida = partida;
            InicializarDatos();
            EsperarJugador();
        }


        private void InicializarDatos()
        {
            idPartida = partida.IdPartida;
            if (conexionServicio != null)
            {
                palabra = conexionServicio.RecuperarPalabraAsync(partida.idPalabra).Result;
                if (palabra != null)
                {
                    palabraCompleta = palabra.palabra;
                    cadenaPalabraCompleta = palabraCompleta.ToCharArray();
                    progresoPalabra = palabraCompleta;
                    cadenaProgresoPalabra = progresoPalabra.ToCharArray(); //Ahora mismo el progreso es igual a la palabra completa
                    InicializarProgresoPalabra(); //Se le colocarán los guiones a el progreso
                    lbPalabra.Content = palabraCompleta;
                    lbDificultad.Content = palabra.dificultad;
                }
                else { MessageBox.Show("No se recupero la información de palabra de la base de datos", "Error de SQL"); }
            }
            else { MessageBox.Show("No se recuperó la información de la palabra, verifique su conexión", "Error de Solicitud"); }       
        }

        private void EsperarJugador()
        {

            timerEsperaJugador.Interval = TimeSpan.FromSeconds(5);
            timerEsperaJugador.Tick += tickerEsperaJugador;
            timerEsperaJugador.Start();

        }

        private void tickerEsperaJugador(object? sender, EventArgs e)
        {
            if (conexionServicio != null)
            {
                DateTime fechaTemp = Convert.ToDateTime(partida.fecha);
                String fechaFormatoTemp = fechaTemp.ToString("yyyy-MM-dd");
                Partida partidaTemp = conexionServicio.RecuperarPartidaAsync(fechaFormatoTemp, partida.idRetador, partida.idPalabra).Result;
                if (partidaTemp != null)
                {
                    int idJugadorTemp = partidaTemp.idJugador;
                    if (idJugadorTemp != 0)
                    {
                        lbInstruccionRetador.Content = "¡Se ha unido un jugador!, Esperando letra...";
                        Jugador jugador = conexionServicio.recuperarJugadorAsync(idJugadorTemp.ToString()).Result;
                        lbNombreJugador.Content = jugador.Nombre;
                        timerEsperaJugador.Stop();
                        ComenzarPartida();
                    }
                }
                else { MessageBox.Show("No se pudo comprobar al jugador", "Error de SQL"); timerEsperaJugador.Stop(); }
            }
            else { MessageBox.Show("No se pudo comprobar al jugador", "Error de Solicitud"); timerEsperaJugador.Stop(); }
        }

        private void ComenzarPartida()
        {
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
                    if(letra != letranueva && letranueva != guion && !letranueva.Equals(null))
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
                ColocarLetrasAPalabra();
                validacion = PALABRA_CORRECTA;
            }
            else
            {
                lbInstruccionRetador.Content = "PENALIZADO, "+palabraCompleta+" No contiene la letra " + letra;
                if (progresoMuñeco != 1) { progresoMuñeco--; }
                validacion = PENALIZACION_RETADOR;
            }

            ValidarProgreso();
            ActualizarProgreso();
        }

        private void ClickBtnIncorrecto(object sender, RoutedEventArgs e)
        {
            BtnCorrecto.IsEnabled = false;
            BtnIncorrecto.IsEnabled = false;
            Boolean existe = ComprobarLetra();
            if (!existe)
            {
                progresoMuñeco++;
                lbInstruccionRetador.Content = "Extremidad Colocada, Esperando al Jugador...";
                validacion = PALABRA_INCORRECTA;
            }
            else
            {             
                lbInstruccionRetador.Content = "PENALIZADO, " + palabraCompleta + " Si Contiene la letra " + letra;
                if (progresoMuñeco != 1) { progresoMuñeco--; }
                ColocarLetrasAPalabra();
                validacion = PENALIZACION_RETADOR;
            }

            ValidarProgreso();
            ActualizarProgreso();
        }

        private void ValidarProgreso()
        {
            //Inicio - Valida si la partida ha terminado
            if (progresoMuñeco == 7)
            {
                lbInstruccionRetador.Content = "Ultima Extremidad Colocada!, FIN DE LA PARTIDA";
                validacion = PARTIDA_PERDIDA;
                GuardarEstadoFinalPartida(ESTADO_PARTIDA_PERDIDA);
            }
            else if (!progresoPalabra.Contains(guion))
            {
                lbInstruccionRetador.Content = "Palabra Completada!, FIN DE LA PARTIDA";
                validacion = PARTIDA_GANADA;
                GuardarEstadoFinalPartida(ESTADO_PARTIDA_GANADA);
            }
            //Fin - Valida si la partida ha terminado;
        }

        private Boolean ComprobarLetra()
        {
            Boolean existe = false;
            int i = 0;
            int tamanoCadena = cadenaPalabraCompleta.Length;
            for(i = 0; i < tamanoCadena; i++)
            {
                if (cadenaPalabraCompleta[i].Equals(letra))
                {
                    existe = true;
                }
            }
            return existe;
        }

        private void ActualizarProgreso()
        {
            if (conexionServicio != null)
            {
                ColocarExtremidadAhorcado(progresoMuñeco);
                lbProgresoPalabra.Content = progresoPalabra;
                Boolean resultado = conexionServicio.ActualizarProgresoPartidaAsync(guion, validacion, progresoPalabra, idPartida).Result;

                if (resultado == false) { MessageBox.Show("No se pudo actualizar el progreso.", "Error al actualizar el Progreso"); }
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

        private void GuardarEstadoFinalPartida(int estadoFinal)
        {
            if (conexionServicio != null)
            {
                Boolean resultado = conexionServicio.ActualizarEstadoPartidaAsync(estadoFinal,idPartida).Result;

                if (resultado == false) { MessageBox.Show("No se pudo Guardar la Partida.", "Error al guardar"); }
            }
            else
            {
                MessageBox.Show("No se pudo Guardar la Partida.", "Error en la peticion");
            }
        }

        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
