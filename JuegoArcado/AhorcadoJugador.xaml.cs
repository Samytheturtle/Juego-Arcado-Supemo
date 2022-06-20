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
using System.Windows.Threading;
using ServicioAhorcadoSupremo;

namespace JuegoArcado
{
    /// <summary>
    /// Lógica de interacción para AhorcadoJugador.xaml
    /// </summary>
    public partial class AhorcadoJugador : Window
    {
        private int idJugador;
        public int idPartida;
        public String nombreRetador = "";
        public String descripcionPalabra = "";
        public String progresoPalabra = "";
        public int progresoMuñeco = 1;
        public char guion = '-';

        public ServiceAhorcadoClient conexionServicio = new ServiceAhorcadoClient();
        DispatcherTimer timer = new DispatcherTimer();


        public AhorcadoJugador()
        {
            InitializeComponent();
            /*lbNombreRetador.Content = nombreRetador;
            lbDescripcionPalabra.Content = descripcionPalabra;
            lbProgresoPalabra.Content = progresoPalabra;
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += ticker;*/
        }
        public AhorcadoJugador(int idJugador,int idPartida)
        {
            this.idJugador = idJugador;
            this.idPartida = idPartida;
            InitializeComponent();
            InicializarDatos();

            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += ticker;
            
        }

        private void InicializarDatos()
        {
            int idRetador = conexionServicio.RecuperarIdRetadorPartidaAsync(idPartida).Result;
            Jugador retadorTemp = conexionServicio.recuperarJugadorAsync(idRetador.ToString()).Result;
            lbNombreRetador.Content = retadorTemp.Nombre;

            int idPalabra = conexionServicio.RecuperarIdPalabraPartidaAsync(idPartida).Result;
            Palabra palabraTemp = conexionServicio.RecuperarPalabraAsync(idPalabra).Result;
            lbDescripcionPalabra.Content = palabraTemp.descripcion;
        }

        private void ticker(object? sender, EventArgs e)
        {
            ComprobarCambios();
        }

        private void ComprobarCambios()
        {
            if (conexionServicio != null)
            {
                ProgresoPartida progresoPartida = conexionServicio.RecuperarProgresoPartidaAsync(idPartida).Result;
                if (progresoPartida != null)
                {
                    if (progresoPartida.letra == '-')
                    {
                        progresoPalabra = progresoPartida.progresoPalabra;
                        ActualizarProgresoVentana(progresoPartida.validacion);
                        timer.Stop();
                    }
                    if (progresoPartida.estado == 3) { TerminarPartida(3); } // 3 para Partida Ganada
                    if (progresoPartida.estado == 4) { TerminarPartida(4); } // 4 para Partdida Perdida
                }
                else
                {
                    MessageBox.Show("No se pudo comprobar los cambios", "Error de Conexión");
                    timer.Stop();
                }
            }
            else
            {
                MessageBox.Show("Por el momento no se puede enviar la solicitud", "Error de Solicitud");
                timer.Stop();
            }
        }

        private void TerminarPartida(int estadoPartida)
        {
            if(estadoPartida == 4)
            {
                lbInstruccionJugador.Content = "PARTIDA TERMINADA, HAS GANADO!";
                Jugador jugador = conexionServicio.recuperarJugadorAsync(idJugador.ToString()).Result;
                conexionServicio.ActualizarPuntosAsync(idJugador, jugador.Puntaje + 10);
            }
            if(estadoPartida == 3)
            {
                lbInstruccionJugador.Content = "PARTIDA TERMINADA, HAS PERDIDO :C";
            }
            HabilitarBotonesLetras(false);
        }

        private void EnviarLetra(char letra)
        {
            if (conexionServicio != null)
            {

                Boolean resultado = conexionServicio.ActualizarProgresoPartidaAsync(letra, 0, "", idPartida).Result;
                if (resultado)
                {
                    HabilitarBotonesLetras(false);
                    ColocarInstruccion("Esperando al Retador...");
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la partida", "Error de conexión");
                }
            }
            else
            {
                MessageBox.Show("No se pudo enviar la letra", "Error en la petición");
            }
            
        }

        public void ActualizarProgresoVentana(int progresoMu)
        {
            if (progresoMu == 0) { progresoMuñeco++; }
            if (progresoMu == 2) {
                if (progresoMuñeco != 1)
                {
                    progresoMuñeco--;
                } 
            }
            ColocarExtremidadAhorcado();
            lbProgresoPalabra.Content = progresoPalabra;
            if (progresoPalabra.Contains(guion) || progresoMuñeco != 7)
            {
                HabilitarBotonesLetras(true);
                ColocarInstruccion("Selecciona una letra");
            }
            /*else
            {
                if (!progresoPalabra.Contains(guion))
                {
                    ColocarInstruccion("PARTIDA FINALIZADA, HAS GANADO!");
                    
                }
                else if(progresoMuñeco == 7)
                { 
                    ColocarInstruccion("PARTIDA FINALIZADA, HAS PERDIDO :C"); 
                }
                
            }*/
            
        }

        private void ColocarExtremidadAhorcado()
        {
            BitmapImage sprite = new BitmapImage();
            sprite.BeginInit();
            sprite.UriSource = new Uri("/AhorcadoSprite" + progresoMuñeco + ".png", UriKind.Relative);
            sprite.EndInit();
            SpriteAhorcado.Source = sprite;
        }


        private void BtnRendirse(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HabilitarBotonesLetras(Boolean accion)
        {
            BtnA.IsEnabled = accion;
            BtnB.IsEnabled = accion;
            BtnC.IsEnabled = accion;
            BtnD.IsEnabled = accion;
            BtnE.IsEnabled = accion;
            BtnF.IsEnabled = accion;
            BtnG.IsEnabled = accion;
            BtnH.IsEnabled = accion;
            BtnI.IsEnabled = accion;
            BtnJ.IsEnabled = accion;
            BtnK.IsEnabled = accion;
            BtnL.IsEnabled = accion;
            BtnM.IsEnabled = accion;
            BtnN.IsEnabled = accion;
            BtnÑ.IsEnabled = accion;
            BtnO.IsEnabled = accion;
            BtnP.IsEnabled = accion;
            BtnQ.IsEnabled = accion;
            BtnR.IsEnabled = accion;
            BtnS.IsEnabled = accion;
            BtnT.IsEnabled = accion;
            BtnU.IsEnabled = accion;
            BtnV.IsEnabled = accion;
            BtnW.IsEnabled = accion;
            BtnX.IsEnabled = accion;
            BtnY.IsEnabled = accion;
            BtnZ.IsEnabled = accion;
        }

        private void ClickBtnA(object sender, RoutedEventArgs e) { BtnA.Visibility = Visibility.Hidden; EnviarLetra('A'); }
        private void ClickBtnB(object sender, RoutedEventArgs e) { BtnB.Visibility = Visibility.Hidden; EnviarLetra('B'); }
        private void ClickBtnC(object sender, RoutedEventArgs e) { BtnC.Visibility = Visibility.Hidden; EnviarLetra('C'); }
        private void ClickBtnD(object sender, RoutedEventArgs e) { BtnD.Visibility = Visibility.Hidden; EnviarLetra('D'); }
        private void ClickBtnE(object sender, RoutedEventArgs e) { BtnE.Visibility = Visibility.Hidden; EnviarLetra('E'); }
        private void ClickBtnF(object sender, RoutedEventArgs e) { BtnF.Visibility = Visibility.Hidden; EnviarLetra('F'); }
        private void ClickBtnG(object sender, RoutedEventArgs e) { BtnG.Visibility = Visibility.Hidden; EnviarLetra('G'); }
        private void ClickBtnH(object sender, RoutedEventArgs e) { BtnH.Visibility = Visibility.Hidden; EnviarLetra('H'); }
        private void ClickBtnI(object sender, RoutedEventArgs e) { BtnI.Visibility = Visibility.Hidden; EnviarLetra('I'); }
        private void ClickBtnJ(object sender, RoutedEventArgs e) { BtnJ.Visibility = Visibility.Hidden; EnviarLetra('J'); }
        private void ClickBtnK(object sender, RoutedEventArgs e) { BtnK.Visibility = Visibility.Hidden; EnviarLetra('K'); }
        private void ClickBtnL(object sender, RoutedEventArgs e) { BtnL.Visibility = Visibility.Hidden; EnviarLetra('L'); }
        private void ClickBtnM(object sender, RoutedEventArgs e) { BtnM.Visibility = Visibility.Hidden; EnviarLetra('M'); }
        private void ClickBtnN(object sender, RoutedEventArgs e) { BtnN.Visibility = Visibility.Hidden; EnviarLetra('N'); }
        private void ClickBtnÑ(object sender, RoutedEventArgs e) { BtnÑ.Visibility = Visibility.Hidden; EnviarLetra('Ñ'); }
        private void ClickBtnO(object sender, RoutedEventArgs e) { BtnO.Visibility = Visibility.Hidden; EnviarLetra('O'); }
        private void ClickBtnP(object sender, RoutedEventArgs e) { BtnP.Visibility = Visibility.Hidden; EnviarLetra('P'); }
        private void ClickBtnQ(object sender, RoutedEventArgs e) { BtnQ.Visibility = Visibility.Hidden; EnviarLetra('Q'); }
        private void ClickBtnR(object sender, RoutedEventArgs e) { BtnR.Visibility = Visibility.Hidden; EnviarLetra('R'); }
        private void ClickBtnS(object sender, RoutedEventArgs e) { BtnS.Visibility = Visibility.Hidden; EnviarLetra('S'); }
        private void ClickBtnT(object sender, RoutedEventArgs e) { BtnT.Visibility = Visibility.Hidden; EnviarLetra('T'); }
        private void ClickBtnU(object sender, RoutedEventArgs e) { BtnU.Visibility = Visibility.Hidden; EnviarLetra('U'); }
        private void ClickBtnV(object sender, RoutedEventArgs e) { BtnV.Visibility = Visibility.Hidden; EnviarLetra('V'); }
        private void ClickBtnW(object sender, RoutedEventArgs e) { BtnW.Visibility = Visibility.Hidden; EnviarLetra('W'); }
        private void ClickBtnX(object sender, RoutedEventArgs e) { BtnX.Visibility = Visibility.Hidden; EnviarLetra('X'); }
        private void ClickBtnY(object sender, RoutedEventArgs e) { BtnY.Visibility = Visibility.Hidden; EnviarLetra('Y'); }
        private void ClickBtnZ(object sender, RoutedEventArgs e) { BtnZ.Visibility = Visibility.Hidden; EnviarLetra('Z'); }

        private void ColocarInstruccion(String instruccion)
        {
            lbInstruccionJugador.Content = instruccion;
        }


    }
}
